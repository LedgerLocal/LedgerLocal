using AutoMapper;
using LedgerLocal.Dto.Chain;
using LedgerLocal.AdminServer.Service.Contract;
using LedgerLocal.Service.GrapheneLogic;
using LedgerLocal.Service.GrapheneLogic.Model;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.Service.ChainService
{
    public class AssetService : IAssetService
    {
        private IWebSocketClientFactory _webSocketClientFactory;
        private IMapper _mapper;
        private List<CliCredential> _lstCreds;
        private ILogger<AssetService> _logger;

        public AssetService(ILogger<AssetService> logger,
            MapperConfiguration mapperConfiguration,
            IWebSocketClientFactory webSocketClientFactory)
        {
            _logger = logger;
            _mapper = mapperConfiguration.CreateMapper();
            _webSocketClientFactory = webSocketClientFactory;

            _lstCreds = new List<CliCredential>()
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

        public async Task<List<AssetDescription>> ListAsset(string lowerBound, int limit)
        {
            _logger.LogInformation($"[BlockchainApi] ListAsset: lowerBound {lowerBound}, limit {limit}");

            var cli = new GrapheneWallet(_webSocketClientFactory);
            await cli.StartAndConnect(_lstCreds);

            return _mapper.Map<List<GrapheneAsset>, List<AssetDescription>>(cli.ListAssets(lowerBound, limit).ToList());
        }

        public async Task<TransactionAssetCreatorDescription> CreateAsset(string issuer, string symbol, 
            uint precision, AssetOptionCreateOrUpdate common,
            BitassetOptionCreateOrUpdate bitassetOpts, bool broadcast = false)
        {
            _logger.LogInformation($"[BlockchainApi] CreateAsset: issuer {issuer}, symbol {symbol}, broadcast {broadcast}");
            var cli = new GrapheneWallet(_webSocketClientFactory);
            await cli.StartAndConnect(_lstCreds);

            var c1 = _mapper.Map<AssetOptionCreateOrUpdate, GrapheneAssetOptions>(common);
            var bc1 = _mapper.Map<BitassetOptionCreateOrUpdate, GrapheneBitAssetOptions>(bitassetOpts);

            var cAsset = cli.CreateAsset(issuer, symbol, precision, c1, bc1, broadcast);

            return _mapper.Map<GrapheneTransactionRecord<GrapheneAssetCreator>, TransactionAssetCreatorDescription>(cAsset);
        }

        public async Task<TransactionAssetCreatorDescription> CreateUiAsset(string issuer, string symbol,
            uint precision, ulong maxSupply, decimal marketFeePercent, 
            ulong maxMarketFee, ulong amountBase, ulong amountQuote,
            string description)
        {
            _logger.LogInformation($"[BlockchainApi] CreateUiAsset: issuer {issuer}, symbol {symbol}");
            var cli = new GrapheneWallet(_webSocketClientFactory);
            await cli.StartAndConnect(_lstCreds);

            var h1 = new AssetOptionHelper();

            var common = new GrapheneAssetOptions();

            common.Max_supply = maxSupply;
            common.Market_fee_percent = marketFeePercent;
            common.Max_market_fee = maxMarketFee;
            common.Issuer_permissions = h1.GetPermissions(false);
            common.Flags = h1.GetFlag();
            common.Whitelist_authorities = new List<string>();
            common.Blacklist_authorities = new List<string>();
            common.Whitelist_markets = new List<string>();
            common.Blacklist_markets = new List<string>();

            common.Core_exchange_rate = new GrapheneExchangeRate()
            {
                Base = new GrapheneAmount()
                {
                    Amount = amountBase,
                    Asset_id = "1.3.0"
                },
                Quote = new GrapheneAmount()
                {
                    Amount = amountQuote,
                    Asset_id = "1.3.1"
                }
            };

            common.Description = description;
            common.IsPredictionMarket = false;

            //var optBitAsset = new GrapheneBitAssetOptions();

            ///*

            //"feed_lifetime_sec" : 60 * 60 * 24,
            //"minimum_feeds" : 7,
            //"force_settlement_delay_sec" : 60 * 60 * 24,
            //"force_settlement_offset_percent" : 1 * assetConstants.GRAPHENE_1_PERCENT,
            //"maximum_force_settlement_volume" : 20 * assetConstants.GRAPHENE_1_PERCENT,
            //"short_backing_asset" : "1.3.0"

            //*/

            //optBitAsset.Feed_lifetime_sec = 60 * 60 * 24;
            //optBitAsset.Minimum_feeds = 7;
            //optBitAsset.Force_settlement_delay_sec = 60 * 60 * 24;
            //optBitAsset.Force_settlement_offset_percent = 1 * h1.GRAPHENE_1_PERCENT;
            //optBitAsset.Maximum_force_settlement_volume = 20 * h1.GRAPHENE_1_PERCENT;
            //optBitAsset.Short_backing_asset = "1.3.0";

            var cAsset = cli.CreateAsset(issuer, symbol, precision, common, null, true);

            return _mapper.Map<GrapheneTransactionRecord<GrapheneAssetCreator>, TransactionAssetCreatorDescription>(cAsset);
        }

        public async Task<GrapheneAsset> GetAssetById(string id)
        {
            _logger.LogInformation($"[BlockchainApi] GetAssetById: to {id}");
            var cli = new GrapheneWallet(_webSocketClientFactory);
            await cli.StartAndConnect(_lstCreds);

            var cAsset = cli.GetAsset(id);

            return cAsset;
        }

        public async Task<BitassetDataDescription> GetBitassetById(string id)
        {
            _logger.LogInformation($"[BlockchainApi] GetAssetById: to {id}");
            var cli = new GrapheneWallet(_webSocketClientFactory);
            await cli.StartAndConnect(_lstCreds);

            var cAsset = cli.GetBitasset(id);

            return cAsset;
        }

        public async Task<TransactionAssetIssuedDescription> IssueAsset(string to, decimal amount, string symbol, string memo = "", bool broadcast = true)
        {
            _logger.LogInformation($"[BlockchainApi] IssueAsset: to {to}, amount {amount}, symbol {symbol}, broadcast {broadcast}");
            var cli = new GrapheneWallet(_webSocketClientFactory);
            await cli.StartAndConnect(_lstCreds);

            var cAsset = cli.IssueAsset(to, amount, symbol, memo, broadcast);

            return _mapper.Map<GrapheneTransactionRecord<GrapheneAssetIssued>, TransactionAssetIssuedDescription>(cAsset);
        }

        public async Task<TransactionAssetCreatorDescription> BorrowAsset(string borrower_name, decimal amount_to_borrow, 
            string asset_symbol, decimal amount_of_collateral, bool broadcast = false)
        {
            _logger.LogInformation($"[BlockchainApi] BorrowAsset: borrower_name {borrower_name}, amount_to_borrow {amount_to_borrow}, asset_symbol {asset_symbol}, broadcast {broadcast}");

            var cli = new GrapheneWallet(_webSocketClientFactory);
            await cli.StartAndConnect(_lstCreds);

            var cAsset = cli.BorrowAsset(borrower_name, amount_to_borrow, asset_symbol, amount_of_collateral, broadcast);

            return _mapper.Map<GrapheneTransactionRecord<GrapheneAssetCreator>, TransactionAssetCreatorDescription>(cAsset);
        }

        public async Task<TransactionAssetCreatorDescription> PublishAssetFeed(string publishing_account, string symbol, 
            PriceFeedCreateOrUpdate feed, bool broadcast = false)
        {
            _logger.LogInformation($"[BlockchainApi] PublishAssetFeed: publishing_account {publishing_account}, symbol {symbol}, broadcast {broadcast}");

            var cli = new GrapheneWallet(_webSocketClientFactory);
            await cli.StartAndConnect(_lstCreds);

            var c1 = _mapper.Map<PriceFeedCreateOrUpdate, GraphenePriceFeed>(feed);

            var cAsset = cli.PublishAssetFeed(publishing_account, symbol, c1, broadcast);

            return _mapper.Map<GrapheneTransactionRecord<GrapheneAssetCreator>, TransactionAssetCreatorDescription>(cAsset);
        }

    }
}
