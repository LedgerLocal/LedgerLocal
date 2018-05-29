using AutoMapper;
using LedgerLocal.Service.GrapheneLogic;
using LedgerLocal.Service.GrapheneLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using LedgerLocal.Dto.Chain;
using LedgerLocal.AdminServer.Service.Contract;
using System.Threading;
using LedgerLocal.AdminServer.Service;
using Newtonsoft.Json.Linq;

namespace LedgerLocal.Service.ChainService
{
    public class AccountService : IAccountService
    {
        private IWebSocketClientFactory _webSocketClientFactory;
        private IMapper _mapper;
        private List<CliCredential> _creds;
        private ILogger<AccountService> _logger;
        private IGrapheneConfig _grapheneConfig;

        public AccountService(MapperConfiguration mapperConfiguration,
            IWebSocketClientFactory webSocketClientFactory,
            ILogger<AccountService> logger,
            IGrapheneConfig grapheneConfig)
        {
            _logger = logger;
            _mapper = mapperConfiguration.CreateMapper();
            _webSocketClientFactory = webSocketClientFactory;
            _grapheneConfig = grapheneConfig;

            _creds = new List<CliCredential>()
            {
                new CliCredential()
                {
                    Url = _grapheneConfig.GrapheneWalletWs,
                    Username = "",
                    Password = ""
                },
                new CliCredential()
                {
                    Url = _grapheneConfig.GrapheneBlockchainWs,
                    Username = "",
                    Password = ""
                }
            };
        }

        public async Task<List<AccountProfileSimple>> ListAccount(string lowerBound, int limit)
        {
            _logger.LogInformation($"[BlockchainApi] ListAccount: lowerBound {lowerBound}, limit {limit}");
            var cli = new GrapheneWallet(_webSocketClientFactory);
            await cli.StartAndConnect(_creds);

            var lstAccount = cli.ListAccounts(lowerBound, limit).ToList();

            var lstRes = new List<GrapheneAccountSimple>();

            foreach(var r in lstAccount)
            {
                lstRes.Add(new GrapheneAccountSimple()
                {
                    AccountName = r.First(),
                    Id = r.Skip(1).First()
                });
            }

            return _mapper.Map<List<GrapheneAccountSimple>, List<AccountProfileSimple>>(lstRes);
        }

        public async Task<List<AmountDescriptionSimple>> ListBalance(string accountId)
        {
            _logger.LogInformation($"[BlockchainApi] ListBalance: accountId {accountId}");
            var cli = new GrapheneWallet(_webSocketClientFactory);
            await cli.StartAndConnect(_creds);

            var lstBalances = cli.ListAccountBalances(accountId).ToList();

            return _mapper.Map<List<GrapheneAmount>, List<AmountDescriptionSimple>>(lstBalances);
        }

        public async Task<List<GrapheneOpContainerMain>> ListHistory(string accountId, uint limit)
        {
            _logger.LogInformation($"[BlockchainApi] ListHistory: accountId {accountId}");
            var cli = new GrapheneWallet(_webSocketClientFactory);
            await cli.StartAndConnect(_creds);

            var lstHisto1 = cli.GetAccountHistory(accountId, limit).ToList();

            return lstHisto1;
        }

        public async Task<Dictionary<string, TransactionRecordDescription>> Transfer(string from, string to, decimal amount, string symbol, string memo, bool broadcast)
        {
            _logger.LogInformation($"[BlockchainApi] Transfer: from {from}, to {to}, amount {amount}, symbol {symbol}, memo {memo}, broadcast {broadcast}");
            var cli = new GrapheneWallet(_webSocketClientFactory);
            await cli.StartAndConnect(_creds);

            var transferDico = cli.Transfer(from, to, amount, symbol, memo);

            return _mapper.Map<Dictionary<string, GrapheneTransactionRecord<GrapheneOperation>>, Dictionary<string, TransactionRecordDescription>>(transferDico);
        }

        public async Task<WebSocketSession> SubscribeToAccountBalance(string account, string[] objectIds, Action<string> cb)
        {
            _logger.LogInformation($"[AccountService] SubscribeToAccountBalance: account {account}, objectIds {string.Join("-", objectIds)}");

            var lastDt = DateTime.Now;
            
            var notifier = new GrapheneWitnessNotifier(_webSocketClientFactory, _grapheneConfig);
            WebSocketSession ws = null;

            ws = await notifier.InitNotifierForObjects(objectIds);

            if (ws == null)
            {
                return null;
            }

            EventHandler<Tuple<DateTime, string>> eventH1 = (object sender, Tuple<DateTime, string> e) =>
            {
                cb(e.Item2);
            };

            ws.SubscribeConsumePublic += eventH1;

            return ws;
        }
    }
}
