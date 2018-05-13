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

namespace LedgerLocal.Service.ChainService
{
    public class AccountService : IAccountService
    {
        private IWebSocketClientFactory _webSocketClientFactory;
        private IMapper _mapper;
        private List<CliCredential> _creds;
        private ILogger<AccountService> _logger;

        public AccountService(MapperConfiguration mapperConfiguration,
            IWebSocketClientFactory webSocketClientFactory,
            ILogger<AccountService> logger)
        {
            _logger = logger;
            _mapper = mapperConfiguration.CreateMapper();
            _webSocketClientFactory = webSocketClientFactory;

            _creds = new List<CliCredential>()
            {
                new CliCredential()
                {
                    Url = "ws://217.182.230.164:8092",
                    Username = "lycmainwallet",
                    Password = "p"
                },
                new CliCredential()
                {
                    Url = "ws://217.182.230.164:8094",
                    Username = "lycblockchain",
                    Password = "p"
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

        public async Task<Dictionary<string, TransactionRecordDescription>> Transfer(string from, string to, decimal amount, string symbol, string memo, bool broadcast)
        {
            _logger.LogInformation($"[BlockchainApi] Transfer: from {from}, to {to}, amount {amount}, symbol {symbol}, memo {memo}, broadcast {broadcast}");
            var cli = new GrapheneWallet(_webSocketClientFactory);
            await cli.StartAndConnect(_creds);

            var transferDico = cli.Transfer(from, to, amount, symbol, memo);

            return _mapper.Map<Dictionary<string, GrapheneTransactionRecord<GrapheneOperation>>, Dictionary<string, TransactionRecordDescription>>(transferDico);
        }
    }
}
