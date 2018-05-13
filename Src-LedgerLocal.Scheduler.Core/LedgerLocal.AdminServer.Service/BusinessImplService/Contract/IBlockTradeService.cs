using IO.Swagger.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.AdminServer.Service.BusinessImplService.Contract
{
    public interface IBlockTradeService
    {
        Task<List<string>> GetActiveWalletType();

        Task<OutputAddressValidationInfo> ValidateAddress(string addressType, string address);

        Task<OutputEstimateInfo> EstimateOutputAmount(decimal intputAmount, string inputCoinType, string outputCoinType);

        Task<InputEstimateInfo> EstimateIntpuAmount(decimal outputAmount, string inputCoinType, string outputCoinType);

        Task<List<OutputAddressInfo>> GetInputAddresses(SessionInfo sess1);

        Task<SimpleTradeInfo> InitiateTrade(string inputCoinType, string outputCoinType, string outputAddress, string memo);

        Task<SessionInfo> GetSession(string email, string password);
    }
}
