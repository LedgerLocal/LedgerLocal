using IO.Swagger.Models;
using LedgerLocal.AdminServer.Api.Web.Models;
using LedgerLocal.AdminServer.Data.FullDomain;
using LedgerLocal.AdminServer.Data.FullDomain.Infrastructure;
using LedgerLocal.AdminServer.Service.BusinessImplService.Contract;
using LedgerLocal.AdminServer.Service.Contract;
using LedgerLocal.Blockchain.Service.LycServiceContract;
using LedgerLocal.Service.ChainService;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LedgerLocal.AdminServer.Service.BusinessImplService
{
    public class ParticipateBusinessService : IParticipateBusinessService
    {
        private readonly IDbContextService _dbContextService;
        private readonly IBlockTradeService _blockTradeService;
        private readonly IAccountService _accountService;
        private readonly ICommonMessageService _commonMessageService;
        private readonly ILimitOrderService _limitOrderService;

        private readonly ILedgerLocalDbFullDomainRepository<Transactions> _transRepository;
        private readonly ILedgerLocalDbFullDomainRepository<Tokenprice> _tokenpriceRepository;
        private readonly ILedgerLocalDbFullDomainUnitOfWork _unitOfWork;

        private readonly ILogger<ParticipateBusinessService> _logger;

        private Dictionary<string, string> _mappingTradingExchange = new Dictionary<string, string>()
        {
            { "btc", "bitusd" },
            { "dash", "bts" },
            { "doge", "bts" },
            { "eth", "bts" },
            { "ltc", "bts" },
            { "steem", "bitusd" }
        };

        private Dictionary<string, string> _mappingTradingdev = new Dictionary<string, string>()
        {
            { "bitcoin", "btc" },
            { "bitusd", "bitusd" },
            { "dash", "dash" },
            { "bitshares2", "bts" },
            { "dogecoin", "doge" },
            { "ethereum", "eth" },
            { "litecoin", "ltc" },
            { "steem", "steem" }
        };

        public ParticipateBusinessService(IBlockTradeService blockTradeService,
            ICommonMessageService commonMessageService,
            ILimitOrderService limitOrderService,
            ILedgerLocalDbFullDomainRepository<Transactions> transRepository,
            ILedgerLocalDbFullDomainRepository<Tokenprice> tokenpriceRepository,
            IAccountService accountService,
            IDbContextService dbContextService,
            ILedgerLocalDbFullDomainUnitOfWork unitOfWork,
            ILogger<ParticipateBusinessService> logger)
        {
            _accountService = accountService;
            _blockTradeService = blockTradeService;
            _commonMessageService = commonMessageService;
            _tokenpriceRepository = tokenpriceRepository;
            _transRepository = transRepository;
            _unitOfWork = unitOfWork;

            _dbContextService = dbContextService;

            _limitOrderService = limitOrderService;

            _logger = logger;
        }

        public async Task<List<string>> ListPaymentCrypto()
        {
            var lst1 = await _blockTradeService.GetActiveWalletType();
            return lst1.Select(x => _mappingTradingdev.ContainsKey(x) ? _mappingTradingdev[x] : x).ToList();
        }

        public async Task<OutputEstimateInfo> CalculateOutputBitshares2(string cryptoInput, decimal amountInput)
        {
            var t1 = await _blockTradeService.EstimateOutputAmount(amountInput, cryptoInput, "bitshares2");
            return t1;
        }

        public async Task<SimpleTradeInfo> InitiateTrade(string inputCoinType, decimal? amount)
        {
            _logger.LogInformation($"[InitiateTrade] Starting InitiateTrade with inputCoinType: {inputCoinType} and amount: {amount}");

            var now = DateTime.UtcNow;
            var memoGuid = Guid.NewGuid().ToString();

            var r1 = await _blockTradeService.InitiateTrade(inputCoinType, _mappingTradingExchange[inputCoinType], "tst-ll-reception", memoGuid);

            _logger.LogInformation($"[InitiateTrade] Blocktrade reply: {JsonConvert.SerializeObject(r1, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })}");

            var objTrans = new Transactions();

            //if (amount.HasValue)
            //{
            //    objTrans.Amount = amount.Value;
            //}

            objTrans.Cryptoconfirmed = false;

            objTrans.Cryptoaddress = r1.InputAddress;
            objTrans.Cryptocurrency = r1.InputCoinType;
            objTrans.Memobc = memoGuid;

            objTrans.Modifiedby = "System";
            objTrans.Createdby = "System";
            objTrans.Createdon = now;
            objTrans.Modifiedon = now;

            await _transRepository.AddAsync(objTrans);
            var error1 = _unitOfWork.CommitHandled();
            if (!error1)
            {
                _logger.LogError($"Can't Add Transaction ! {JsonConvert.SerializeObject(error1, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })} ");
            }

            _logger.LogInformation($"[InitiateTrade] Transaction created in DB: {JsonConvert.SerializeObject(objTrans, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })}");

            var guidString = Guid.NewGuid().ToString();
            await _commonMessageService.SendMessage<ActionEventDefinition>("llc-event-broadcast", guidString,
                new ActionEventDefinition()
                {
                    ActionName = "InitiateTradeTriggered",
                    Message = string.Format($"New participation initiated => {objTrans.Transactionid} => {r1.InputAddress}"),
                    Timestamp = DateTime.UtcNow,
                    Success = true,
                    Reason = "Subscription"
                });

            return r1;
        }

        private List<Tuple<long, decimal, Tokenprice>> CalculateTokenAmountAndPrice(decimal amountUsd)
        {
            var res1 = new List<Tuple<long, decimal, Tokenprice>>();

            var allPrices = _tokenpriceRepository.DbSet.OrderBy(x1 => x1.Priceusd).ToList();
            var allTransactionsValid = _transRepository.DbSet.Where(x1 => x1.Cryptoconfirmed).ToList();

            decimal cursAmountUsd = amountUsd;

            foreach (var it1 in allPrices)
            {
                var qty = Convert.ToInt64(cursAmountUsd / it1.Priceusd.Value);

                if (qty < it1.Remainingtokens.Value)
                {
                    res1.Add(new Tuple<long, decimal, Tokenprice>(qty, it1.Priceusd.Value, it1));
                    break;
                }
                else
                {
                    res1.Add(new Tuple<long, decimal, Tokenprice>(it1.Remainingtokens.Value, it1.Priceusd.Value, it1));
                    cursAmountUsd = cursAmountUsd - (it1.Remainingtokens.Value * it1.Priceusd.Value);
                    continue;
                }
            }

            return res1;
        }

        public async Task FinalizeTrades(string currencyId)
        {
            try
            {
                _logger.LogInformation("[FinalizeTrades] starting...");

                var now = DateTime.UtcNow;

                var obj22 = (IAccountService)ServiceLocatorSingleton.Instance.ServiceProvider.GetService(typeof(IAccountService));

                var lstTrades = await obj22.ListHistory("tst-ll-reception", 4);
                var lstTransNotFilled = _transRepository.DbSet.Where(x1 => !x1.Cryptoconfirmed).ToList();
                var lstTradesOrdered = lstTrades.OrderByDescending(x1 => x1.Op.BlockNum);
                var itemToProcess = lstTransNotFilled.Where(x1 => lstTradesOrdered.Select(x2 => x2.Memo).Contains(x1.Memobc));

                _logger.LogInformation($"[FinalizeTrades] Transactions to be processed: {JsonConvert.SerializeObject(itemToProcess, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })}");

                foreach (var a1 in itemToProcess)
                {
                    var t1 = lstTrades.First(xx1 => xx1.Memo == a1.Memobc);

                    if (currencyId == "1.3.0")
                    {
                        a1.Amount = Convert.ToInt64(t1.Op.Op.First().Value.Amount.Amount / 100000);
                        a1.AmountDecimal = t1.Op.Op.First().Value.Amount.Amount / 100000;
                        var tradeExchange1 = (await _limitOrderService.GetLimitOrderHistory("1.3.0", "1.3.121", 1)).First();
                        a1.Amountusd = a1.AmountDecimal * tradeExchange1.Price;
                    }
                    else
                    {
                        a1.Amount = Convert.ToInt64(t1.Op.Op.First().Value.Amount.Amount / 10000);
                        a1.AmountDecimal = t1.Op.Op.First().Value.Amount.Amount / 10000;
                        a1.Amountusd = a1.AmountDecimal;
                    }

                    a1.Paidonbc = false;
                    a1.Cryptoconfirmed = true;
                    a1.Modifiedon = now;

                    await _transRepository.UpdateAsync(a1);

                    var error0 = _unitOfWork.CommitHandled();
                    if (!error0)
                    {
                        _logger.LogError($"Can't Add Transaction ! {JsonConvert.SerializeObject(error0, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })} ");
                    }

                    _logger.LogInformation($"[FinalizeTrades] Transaction Updated: {JsonConvert.SerializeObject(a1, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })}");

                    var cal1 = CalculateTokenAmountAndPrice(a1.Amountusd);

                    _logger.LogInformation($"[FinalizeTrades] CalculateTokenAmountAndPrice result: {JsonConvert.SerializeObject(cal1, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })}");

                    if (cal1.Count > 1)
                    {
                        foreach (var i1 in cal1.Skip(1))
                        {
                            var newTrans = new Transactions();

                            newTrans.Memobc = a1.Memobc;
                            newTrans.Paidonbc = false;
                            newTrans.Godfathercode = a1.Godfathercode;
                            newTrans.Cryptocurrency = a1.Cryptocurrency;
                            newTrans.Cryptoconfirmed = a1.Cryptoconfirmed;

                            newTrans.Amounttoken = i1.Item1;
                            newTrans.Purchaseprice = i1.Item2;
                            newTrans.Amount = a1.Amount;
                            newTrans.Amountusd = a1.Amountusd;
                            newTrans.Createdon = now;
                            newTrans.Modifiedon = now;
                            newTrans.Createdby = "System";
                            newTrans.Modifiedby = "System";

                            await _transRepository.AddAsync(newTrans);

                            var errorCurs = _unitOfWork.CommitHandled();
                            if (!errorCurs)
                            {
                                _logger.LogError($"Can't Add Transaction ! {JsonConvert.SerializeObject(errorCurs, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })} ");
                            }

                            i1.Item3.Remainingtokens = i1.Item3.Remainingtokens - i1.Item1;
                            await _tokenpriceRepository.UpdateAsync(i1.Item3);

                            var errorCursTokenPriceSub = _unitOfWork.CommitHandled();
                            if (!errorCursTokenPriceSub)
                            {
                                _logger.LogError($"Can't Update TokenPrice ! {JsonConvert.SerializeObject(errorCursTokenPriceSub, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })} ");
                            }

                            _logger.LogInformation($"[FinalizeTrades] Transaction created: {JsonConvert.SerializeObject(newTrans, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })}");

                        }
                    }

                    var a22 = _transRepository.DbSet.First(dd => dd.Transactionid == a1.Transactionid);

                    a22.Modifiedon = now;

                    a22.Purchaseprice = cal1.First().Item2;
                    a22.Amounttoken = cal1.First().Item1;

                    await _transRepository.UpdateAsync(a22);

                    var error1 = _unitOfWork.CommitHandled();
                    if (!error1)
                    {
                        _logger.LogError($"Can't Add Transaction ! {JsonConvert.SerializeObject(error1, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })} ");
                    }

                    _logger.LogInformation($"[FinalizeTrades] TokenPrice updated: {JsonConvert.SerializeObject(a22, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })}");

                    var tprice1 = cal1.First().Item3;

                    tprice1.Remainingtokens = tprice1.Remainingtokens.Value - cal1.First().Item1;
                    await _tokenpriceRepository.UpdateAsync(tprice1);

                    var errorCursTokenPrice = _unitOfWork.CommitHandled();
                    if (!errorCursTokenPrice)
                    {
                        _logger.LogError($"Can't Update TokenPrice ! {JsonConvert.SerializeObject(errorCursTokenPrice, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })} ");
                    }

                    _logger.LogInformation($"[FinalizeTrades] TokenPrice updated: {JsonConvert.SerializeObject(tprice1, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })}");

                    var guidString = Guid.NewGuid().ToString();
                    await _commonMessageService.SendMessage<ActionEventDefinition>("llc-event-broadcast", guidString,
                        new ActionEventDefinition()
                        {
                            ActionName = "FinalizeTradeTriggered",
                            Message = string.Format($"[LedgerLocal][Participation][Success] New participation of { a1.Amountusd } USD => {a22.Amounttoken} Token"),
                            Timestamp = DateTime.UtcNow,
                            Success = true,
                            Reason = "Subscription"
                        });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Finalizing");
            }


        }
    }
}
