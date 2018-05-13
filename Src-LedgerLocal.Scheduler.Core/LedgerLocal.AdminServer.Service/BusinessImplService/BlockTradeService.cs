using IO.Swagger.Models;
using LedgerLocal.AdminServer.Service.BusinessImplService.Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.AdminServer.Service.BusinessImplService
{
    public class BlockTradeService : IBlockTradeService
    {
        private HttpClient _httpClient;

        public BlockTradeService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<string>> GetActiveWalletType()
        {
            var res1 = await _httpClient.GetAsync("https://blocktrades.us:443/api/v2/active-wallets");
            res1.EnsureSuccessStatusCode();
            var str1 = await  res1.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<string>>(str1);
        }

        public async Task<OutputAddressValidationInfo> ValidateAddress(string addressType, string address)
        {
            var res1 = await _httpClient.GetAsync(
                    string.Concat("https://blocktrades.us:443/api/v2/wallets/", addressType, "/address-validator?address=", address)
                );

            res1.EnsureSuccessStatusCode();

            var resp1string = await res1.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<OutputAddressValidationInfo>(resp1string);
        }

        public async Task<OutputEstimateInfo> EstimateOutputAmount(decimal intputAmount, string inputCoinType, string outputCoinType)
        {
            var res1 = await _httpClient.GetAsync(
                    string.Concat("https://blocktrades.us:443/api/v2/estimate-output-amount?inputAmount=", intputAmount, "&inputCoinType=", inputCoinType, "&outputCoinType=", outputCoinType)
                );

            res1.EnsureSuccessStatusCode();

            var resp1string = await res1.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<OutputEstimateInfo>(resp1string);
        }

        public async Task<InputEstimateInfo> EstimateIntpuAmount(decimal outputAmount, string inputCoinType, string outputCoinType)
        {
            var res1 = await _httpClient.GetAsync(
                    string.Concat("https://blocktrades.us:443/api/v2/estimate-input-amount?outputAmount=", outputAmount, "&inputCoinType=", inputCoinType, "&outputCoinType=", outputCoinType)
                );

            res1.EnsureSuccessStatusCode();

            var resp1string = await res1.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<InputEstimateInfo>(resp1string);
        }

        public async Task<List<OutputAddressInfo>> GetInputAddresses(SessionInfo sess1)
        {

            var res1 = await _httpClient.GetAsync(
                    string.Concat("https://blocktrades.us:443/api/v2/input-addresses?sessionToken=", sess1.Token)
                );

            res1.EnsureSuccessStatusCode();

            var resp1string = await res1.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<OutputAddressInfo>>(resp1string);
        }

        public async Task<SimpleTradeInfo> InitiateTrade(string inputCoinType, string outputCoinType, string outputAddress, string memo)
        {
            var sm1 = new InitiateTradeModel1()
            {
                InputCoinType = inputCoinType,
                OutputCoinType = outputCoinType,
                OutputAddress = outputAddress,
                OutputMemo = memo
            };

            var res1 = await _httpClient.PostAsync(
                "https://blocktrades.us:443/api/v2/simple-api/initiate-trade",
                new StringContent(
                    JsonConvert.SerializeObject(sm1),
                Encoding.UTF8,
                "application/json")
                );

            res1.EnsureSuccessStatusCode();

            var resp1string = await res1.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SimpleTradeInfo>(resp1string);

        }

        public async Task<SessionInfo> GetSession(string email, string password)
        {
            var sm1 = new SessionsModel2() { Email = email, Password = password };

            var res1 = await _httpClient.PostAsync(
                "https://blocktrades.us:443/api/v2/sessions", 
                new StringContent(
                    JsonConvert.SerializeObject(sm1), 
                Encoding.UTF8, 
                "application/json")
                );

            res1.EnsureSuccessStatusCode();

            var resp1string = await res1.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SessionInfo>(resp1string);
        }
    }
}
