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
                    Url = _grapheneConfig.GrapheneWallet1Ws,
                    Username = "lycmainwallet",
                    Password = "p"
                },
                new CliCredential()
                {
                    Url = _grapheneConfig.GrapheneWallet2Ws,
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


            //    createLimitOrder(account, sellAmount, sellAsset, buyAmount, buyAsset, expiration, isFillOrKill, fee_asset_id)
            //    {

            //        var tr = wallet_api.new_transaction();

            //        let feeAsset = ChainStore.getAsset(fee_asset_id);
            //        if (feeAsset.getIn(["options", "core_exchange_rate", "base", "asset_id"]) === "1.3.0" && feeAsset.getIn(["options", "core_exchange_rate", "quote", "asset_id"]) === "1.3.0" ) {
            //            fee_asset_id = "1.3.0";
            //        }

            //        tr.add_type_operation("limit_order_create", {
            //            fee:
            //            {
            //                amount: 0,
            //            asset_id: fee_asset_id
            //            },
            //        "seller": account,
            //        "amount_to_sell": {
            //                "amount": sellAmount,
            //            "asset_id": sellAsset.get("id")
            //        },
            //        "min_to_receive": {
            //                "amount": buyAmount,
            //            "asset_id": buyAsset.get("id")
            //        },
            //        "expiration": expiration,
            //        "fill_or_kill": isFillOrKill
            //        });

            //        return (dispatch) => {
            //            return WalletDb.process_transaction(tr, null, true).then(result => {
            //                dispatch(true);
            //                return true;
            //            })
            //            .catch (error => {
            //                console.log("order error:", error);
            //                dispatch({ error});
            //                return { error};
            //            });
            //            };
            //        }

            //createLimitOrder2(order) {
            //            var tr = wallet_api.new_transaction();

            //            // let feeAsset = ChainStore.getAsset(fee_asset_id);
            //            // if( feeAsset.getIn(["options", "core_exchange_rate", "base", "asset_id"]) === "1.3.0" && feeAsset.getIn(["options", "core_exchange_rate", "quote", "asset_id"]) === "1.3.0" ) {
            //            //     fee_asset_id = "1.3.0";
            //            // }

            //            order.setExpiration();
            //            order = order.toObject();

            //            tr.add_type_operation("limit_order_create", order);

            //            return WalletDb.process_transaction(tr, null, true).then(result => {
            //                return true;
            //            })
            //            .catch (error => {
            //                console.log("order error:", error);
            //                return { error};
            //            });
            //            }

            //            createPredictionShort(order, collateral, account, sellAmount, sellAsset, buyAmount, collateralAmount, buyAsset, expiration, isFillOrKill, fee_asset_id = "1.3.0") {

            //                var tr = wallet_api.new_transaction();

            //                // Set the fee asset to use
            //                fee_asset_id = accountUtils.getFinalFeeAsset(order.seller, "call_order_update", order.fee.asset_id);

            //                order.setExpiration();

            //                tr.add_type_operation("call_order_update", {
            //                    "fee": {
            //                        amount: 0,
            //            asset_id: fee_asset_id
            //                    },
            //        "funding_account": order.seller,
            //        "delta_collateral": collateral.toObject(),
            //        "delta_debt": order.amount_for_sale.toObject(),
            //        "expiration": order.getExpiration()
            //                });

            //                tr.add_type_operation("limit_order_create", order.toObject());

            //                return WalletDb.process_transaction(tr, null, true).then(result => {
            //                    return true;
            //                })
            //                    .catch (error => {
            //                    console.log("order error:", error);
            //                    return { error};
            //                });
            //                }

            //                cancelLimitOrder(accountID, orderID) {
            //                    // Set the fee asset to use
            //                    let fee_asset_id = accountUtils.getFinalFeeAsset(accountID, "limit_order_cancel");

            //                    var tr = wallet_api.new_transaction();
            //                    tr.add_type_operation("limit_order_cancel", {
            //                        fee:
            //                        {
            //                            amount: 0,
            //            asset_id: fee_asset_id
            //                        },
            //        "fee_paying_account": accountID,
            //        "order": orderID
            //                    });
            //                    return WalletDb.process_transaction(tr, null, true)
            //                    .catch (error => {
            //                        console.log("cancel error:", error);
            //                    });
            //                    }

            //                    cancelLimitOrderSuccess(orderID) {
            //                        return (dispatch) => {
            //                            /* In the case of many cancel orders being issued at the same time,
            //                            * we batch them here and dispatch them all at once at a frequency
            //                            * defined by "dispatchCancelTimeout"
            //                            */
            //                            if (!dispatchCancelTimeout)
            //                            {
            //                                cancelBatchIDs = cancelBatchIDs.push(orderID);
            //                                dispatchCancelTimeout = setTimeout(() => {
            //                                    dispatch(cancelBatchIDs.toJS());
            //                                    dispatchCancelTimeout = null;
            //                                    cancelBatchIDs = cancelBatchIDs.clear();
            //                                }, cancelBatchTime);
            //                            }
            //                            else
            //                            {
            //                                cancelBatchIDs = cancelBatchIDs.push(orderID);
            //                            }
            //                        };
            //                    }
        }
}
