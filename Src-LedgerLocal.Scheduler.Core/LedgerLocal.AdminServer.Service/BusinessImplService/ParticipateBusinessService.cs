using IO.Swagger.Models;
using LedgerLocal.AdminServer.Api.Web.Models;
using LedgerLocal.AdminServer.Data.FullDomain;
using LedgerLocal.AdminServer.Data.FullDomain.Infrastructure;
using LedgerLocal.AdminServer.Service.BusinessImplService.Contract;
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
            ILedgerLocalDbFullDomainUnitOfWork unitOfWork,
            ILogger<ParticipateBusinessService> logger)
        {
            _accountService = accountService;
            _blockTradeService = blockTradeService;
            _commonMessageService = commonMessageService;
            _tokenpriceRepository = tokenpriceRepository;
            _transRepository = transRepository;
            _unitOfWork = unitOfWork;

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
            var now = DateTime.UtcNow;
            var memoGuid = Guid.NewGuid().ToString();

            var r1 = await _blockTradeService.InitiateTrade(inputCoinType, _mappingTradingExchange[inputCoinType], "tst-ll-admin", memoGuid);

            var objTrans = new Transactions();

            //if (amount.HasValue)
            //{
            //    objTrans.Amount = amount.Value;
            //}

            objTrans.Cryptoconfirmed = false;

            objTrans.Cryptoaddress = r1.InputAddress;
            objTrans.Cryptocurrency = r1.InputCoinType;
            objTrans.Memobc = r1.InputMemo;

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

        private List<Tuple<long, decimal>> CalculateTokenAmountAndPrice(decimal amountUsd)
        {
            var res1 = new List<Tuple<long, decimal>>();

            var allPrices = _tokenpriceRepository.DbSet.OrderBy(x1 => x1.Priceusd).ToList();
            var allTransactionsValid = _transRepository.DbSet.Where(x1 => x1.Cryptoconfirmed).ToList();

            var totalToken = allTransactionsValid.Sum(x1 => x1.Amounttoken);

            long cursToken = 0;
            foreach (var it1 in allPrices)
            {
                cursToken = cursToken + it1.Remainingtokens.Value;
                if (totalToken < cursToken)
                {
                    var qty = Convert.ToInt64(amountUsd / it1.Priceusd.Value);

                    if (qty < (cursToken - totalToken))
                    {
                        res1.Add(new Tuple<long, decimal>(qty, it1.Priceusd.Value));
                        break;
                    }
                    else
                    {
                        res1.Add(new Tuple<long, decimal>(qty, it1.Priceusd.Value));
                        totalToken = totalToken + qty;
                        continue;
                    }
                }
            }

            return res1;
        }

        public async Task FinalizeTrades(string currencyId)
        {
            try
            {

                var now = DateTime.UtcNow;

                var lstTrades = await _accountService.ListHistory("tst-ll-admin", 1);
                var a1 = _transRepository.DbSet.Where(x1 => !x1.Cryptoconfirmed).FirstOrDefault();
                //var lstTradesOrdered = lstTrades.OrderByDescending(x1 => x1.Op.BlockNum);
                //var itemToProcess = lstTransNotFilled.Where(x1 => lstTradesOrdered.Select(x2 => x2.Memo).Contains(x1.Memobc));

                if (a1 != null)
                {
                    var t1 = lstTrades.First();

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

                    var cal1 = CalculateTokenAmountAndPrice(a1.Amountusd);

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

                            await _transRepository.AddAsync(a1);

                            var errorCurs = _unitOfWork.CommitHandled();
                            if (!errorCurs)
                            {
                                _logger.LogError($"Can't Add Transaction ! {JsonConvert.SerializeObject(errorCurs, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })} ");
                            }

                        }
                    }

                    var a22 = _transRepository.DbSet.First(dd => dd.Transactionid == a1.Transactionid);

                    a22.Modifiedon = now;

                    a22.Purchaseprice = cal1.First().Item2;
                    a22.Amounttoken = cal1.First().Item1;

                    await _transRepository.UpdateAsync(a1);

                    var error1 = _unitOfWork.CommitHandled();
                    if (!error1)
                    {
                        _logger.LogError($"Can't Add Transaction ! {JsonConvert.SerializeObject(error1, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })} ");
                    }

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
