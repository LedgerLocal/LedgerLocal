using AutoMapper;
using LedgerLocal.Dto.Chain;
using LedgerLocal.Service.GrapheneLogic;
using LedgerLocal.Service.GrapheneLogic.Model;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.Service.ChainService
{
    public interface ILimitOrderService
    {
        Task<TransactionLimitOrderDescription> CreateLimitOrder(string account, decimal sellAmount, string sellAsset,
            decimal buyAmount, string buyAsset, string expiration,
            bool isFillOrKill, string fee_asset_id, string feeAssetSymbol, string guidLabel, bool broadcast);

        Task<ExchangeLimitOrderDescription> CreateExchange(string account, decimal sellAmount,
            string sellAsset, decimal buyAmount, string buyAsset,
            string expiration, bool isFillOrKill, string fee_asset_id,
            string feeAssetSymbol, string guidLabel, int timeoutInMilliSecond);

        Task<GrapheneOrder[]> GetLimitOrderHistory(string baseSymbol, string quoteSymbol, int limit);
    }
}