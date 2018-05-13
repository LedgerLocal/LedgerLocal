using LedgerLocal.Dto.Chain;
using LedgerLocal.Service.GrapheneLogic;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.Service.ChainService
{
    public interface IAssetService
    {
        Task<GrapheneAsset> GetAssetById(string id);

        Task<List<AssetDescription>> ListAsset(string lowerBound, int limit);

        Task<TransactionAssetCreatorDescription> CreateAsset(string issuer, string symbol,
            uint precision, AssetOptionCreateOrUpdate common,
            BitassetOptionCreateOrUpdate bitassetOpts, bool broadcast = false);

        Task<TransactionAssetCreatorDescription> CreateUiAsset(string issuer, string symbol,
                    uint precision, ulong maxSupply, decimal marketFeePercent,
                    ulong maxMarketFee, ulong amountBase, ulong amountQuote,
                    string description);

        Task<TransactionAssetIssuedDescription> IssueAsset(string to, decimal amount, string symbol, string memo = "", bool broadcast = true);
            
        Task<TransactionAssetCreatorDescription> BorrowAsset(string borrower_name, decimal amount_to_borrow,
            string asset_symbol, decimal amount_of_collateral, bool broadcast = false);

        Task<TransactionAssetCreatorDescription> PublishAssetFeed(string publishing_account, string symbol, PriceFeedCreateOrUpdate feed, bool broadcast = false);

        Task<BitassetDataDescription> GetBitassetById(string id);
    }
}
