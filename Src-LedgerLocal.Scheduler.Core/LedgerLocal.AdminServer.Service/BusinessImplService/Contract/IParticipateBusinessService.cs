using IO.Swagger.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.AdminServer.Service.BusinessImplService.Contract
{
    public interface IParticipateBusinessService
    {

        Task<List<string>> ListPaymentCrypto();

        Task<OutputEstimateInfo> CalculateOutputBitshares2(string cryptoInput, decimal amountInput);

        Task<SimpleTradeInfo> InitiateTrade(string inputCoinType, decimal? amount);

        Task FinalizeTrades();

    }
}
