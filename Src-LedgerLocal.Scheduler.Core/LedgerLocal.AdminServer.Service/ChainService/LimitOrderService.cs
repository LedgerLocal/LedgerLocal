using AutoMapper;
using LedgerLocal.Dto.Chain;
using LedgerLocal.Service.GrapheneLogic;
using LedgerLocal.Service.GrapheneLogic.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using LedgerLocal.AdminServer.Service.Contract;
using LedgerLocal.AdminServer.Service;

namespace LedgerLocal.Service.ChainService
{
    public class LimitOrderService : ILimitOrderService
    {

        private IWebSocketClientFactory _webSocketClientFactory;
        private IMapper _mapper;
        private List<CliCredential> _lstCreds;
        private IGrapheneConfig _grapheneConfig;
        private object _sync = new object();
        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

        private readonly ILogger<LimitOrderService> _logger;

        public LimitOrderService(ILogger<LimitOrderService> logger,
            MapperConfiguration mapperConfiguration,
            IWebSocketClientFactory webSocketClientFactory,
            IGrapheneConfig grapheneConfig)
        {
            _grapheneConfig = grapheneConfig;

            _logger = logger;
            _mapper = mapperConfiguration.CreateMapper();
            _webSocketClientFactory = webSocketClientFactory;

            _lstCreds = new List<CliCredential>()
            {
                new CliCredential()
                {
                    Url = _grapheneConfig.GrapheneWalletWs,
                    Username = "lycmainwallet",
                    Password = "p"
                },
                new CliCredential()
                {
                    Url = _grapheneConfig.GrapheneBlockchainWs,
                    Username = "lycblockchain",
                    Password = "p"
                }
            };
        }

        public async Task<ExchangeLimitOrderDescription> CreateExchange(string account, decimal sellAmount, 
            string sellAsset, decimal buyAmount, string buyAsset, 
            string expiration, bool isFillOrKill, string fee_asset_id, 
            string feeAssetSymbol, string guidLabel, int timeoutInMilliSecond)
        {
            _logger.LogInformation($"[BlockchainApi] Creating Exchange: account {account}, sellAmount {sellAmount}, sellAsset {sellAsset}, buyAmount {buyAmount}, buyAsset {buyAsset}, expiration {expiration}, isFillOrKill {isFillOrKill}, fee_asset_id {fee_asset_id}, feeAssetSymbol {feeAssetSymbol}, guidLabel {guidLabel}, timeoutInMilliSecond {timeoutInMilliSecond}");

            ExchangeLimitOrderDescription returnVal = null;
            var lastDt = DateTime.Now;

            ManualResetEvent oSignalEvent = new ManualResetEvent(false);

            var notifier = new GrapheneWitnessNotifier(_webSocketClientFactory, _grapheneConfig);
            WebSocketSession ws = null;

            await semaphoreSlim.WaitAsync();
            try
            {
                ws = await notifier.InitNotifierForMarket(sellAsset, buyAsset);

                if (ws == null)
                {
                    return null;
                }

                //var resPast = ws.OnTickCollection.Where(x => {

                //    JToken token = JObject.Parse(x.Item2);

                //    var guidFromWs = token.SelectToken("params[1][0][0][0][1].strguidone");
                //    if (guidFromWs != null && guidFromWs.ToString().Contains(guidLabel))
                //    {
                //        return true;
                //    }

                //    return false;
                //});

                //if (resPast.Any())
                //{
                //    var rF = resPast.First();
                //    JToken tokenT = JObject.Parse(rF.Item2);
                //    returnVal = tokenT.SelectToken("params[1][0][0][0][1]").ToObject<ExchangeLimitOrderDescription>();

                //    lastDt = rF.Item1;

                //    oSignalEvent.Set();
                //}

                EventHandler<Tuple<DateTime, string>> eventH1 = (object sender, Tuple<DateTime, string> e) =>
                {
                    JToken token = JObject.Parse(e.Item2);

                    var guidFromWs = token.SelectToken("params[1][0][0][0][1].strguidone");
                    if (guidFromWs != null && guidFromWs.ToString().Equals(guidLabel, StringComparison.CurrentCultureIgnoreCase))
                    {
                        returnVal = token.SelectToken("params[1][0][0][0][1]").ToObject<ExchangeLimitOrderDescription>();
                        lastDt = e.Item1;

                        oSignalEvent.Set();
                    }
                };

                ws.SubscribeConsumePublic += eventH1;

                var orderRes = await CreateLimitOrder(account, sellAmount, sellAsset, buyAmount, buyAsset, expiration, isFillOrKill, fee_asset_id, feeAssetSymbol, guidLabel, true);

                oSignalEvent.WaitOne(timeoutInMilliSecond);

                ws.SubscribeConsumePublic -= eventH1;

                ws.IsBusy = false;
                return returnVal;
            }
            finally
            {
                //When the task is ready, release the semaphore. It is vital to ALWAYS release the semaphore when we are ready, or else we will end up with a Semaphore that is forever locked.
                //This is why it is important to do the Release within a try...finally clause; program execution may crash or take a different path, this way you are guaranteed execution
                semaphoreSlim.Release();
            }
        }

        public async Task<GrapheneOrder[]> GetLimitOrderHistory(string baseSymbol, string quoteSymbol, int limit)
        {
            var cli = new GrapheneWallet(_webSocketClientFactory);
            await cli.StartAndConnect(_lstCreds);

            var lh = cli.LimitOrders(baseSymbol, quoteSymbol, limit);
            return lh;
        }

        public async Task<TransactionLimitOrderDescription> CreateLimitOrder(string account, decimal sellAmount, string sellAsset, 
            decimal buyAmount, string buyAsset, string expiration, 
            bool isFillOrKill, string fee_asset_id, string feeAssetSymbol, string labelGuid, bool broadcast)
        {
            _logger.LogInformation($"[BlockchainApi] CreateLimitOrder: account {account}, sellAmount {sellAmount}, sellAsset {sellAsset}, buyAmount {buyAmount}, buyAsset {buyAsset}, expiration {expiration}, isFillOrKill {isFillOrKill}, fee_asset_id {fee_asset_id}, feeAssetSymbol {feeAssetSymbol}, guidLabel {labelGuid}, broadcast {broadcast}");


            var cli = new GrapheneWallet(_webSocketClientFactory);
            await cli.StartAndConnect(_lstCreds);

            //begin_builder_transaction,
            //add_operation_to_builder_transaction,
            //replace_operation_in_builder_transaction,
            //set_fees_on_builder_transaction,
            //preview_builder_transaction,
            //sign_builder_transaction,
            //propose_builder_transaction,
            //remove_builder_transaction,

            var resTransId = cli.ApiCall<int>(GrapheneMethodEnum.begin_builder_transaction, GrapheneApi.@public);

            //var feeAsset = cli.GetAsset(fee_asset_id);

            var feeObj = new JObject();
            feeObj.Add("amount", 0);
            feeObj.Add("asset_id", fee_asset_id);

            var jObj = new JObject();

            jObj.Add("fee", JObject.FromObject(new GrapheneAmount()
            {
                Amount = 0,
                Asset_id = fee_asset_id
            }));

            jObj.Add("seller", account);

            jObj.Add("amount_to_sell", JObject.FromObject(new GrapheneAmount()
            {
                Amount = Convert.ToUInt64(sellAmount),
                Asset_id = sellAsset
            }));

            jObj.Add("min_to_receive", JObject.FromObject(new GrapheneAmount()
            {
                Amount = Convert.ToUInt64(buyAmount),
                Asset_id = buyAsset
            }));

            jObj.Add("expiration", expiration);

            jObj.Add("fill_or_kill", isFillOrKill);

            jObj.Add("strguid", labelGuid);

            var jArr = new JArray();

            jArr.Add(1);
            jArr.Add(jObj);

            var resAddOp = cli.ApiCall<string>(GrapheneMethodEnum.add_operation_to_builder_transaction, GrapheneApi.@public, resTransId, jArr);

            var resAddFee = cli.ApiCall<GrapheneAmount>(GrapheneMethodEnum.set_fees_on_builder_transaction, GrapheneApi.@public, resTransId, feeAssetSymbol);

            var resAddSign = cli.ApiCall<GrapheneTransactionRecord<GrapheneLimitOrderBody>>(GrapheneMethodEnum.sign_builder_transaction, GrapheneApi.@public, resTransId, broadcast);

            return _mapper.Map<GrapheneTransactionRecord<GrapheneLimitOrderBody>, TransactionLimitOrderDescription>(resAddSign);
        }


    }
}
