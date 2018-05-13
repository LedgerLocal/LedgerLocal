using System;
using System.Threading.Tasks;
using Quartz;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using VDS.RDF.Storage;
using VDS.RDF;
using LedgerLocal.AdminServer.Service.BusinessImplService.Contract;
using BinanceExchange.API.Client.Interfaces;
using BinanceExchange.API.Models.Response;
using Microsoft.Extensions.Logging;

namespace LedgerLocal.AdminServer.Jobs
{
    [DisallowConcurrentExecution]
    public class StatPoolingJob : IJob
    {
        private readonly IRdfStoreBusiness _rdfStoreBusiness;
        private readonly IElasticBusiness _elasticBusiness;
        private readonly IBotService _botService;
        private readonly IBinanceClient _binanceClient;
        private readonly ILogger<StatPoolingJob> _logger;

        public StatPoolingJob(
            IRdfStoreBusiness rdfStoreBusiness, 
            IElasticBusiness elasticBusiness,
            IBotService botService, 
            IBinanceClient binanceClient,
            ILogger<StatPoolingJob> logger
            )
        {
            _rdfStoreBusiness = rdfStoreBusiness;
            _elasticBusiness = elasticBusiness;
            _botService = botService;
            _binanceClient = binanceClient;
            _logger = logger;
        }

        async Task IJob.Execute(IJobExecutionContext context)
        {
            var dateNow = DateTime.UtcNow;

            _logger.LogInformation($"Starting LedgerLocalStat with UTC date {String.Format("{0:F}", dateNow)} ...");

            using (var store = new BlazegraphConnector("http://LedgerLocal.appswiss.ch:9999/blazegraph", "LedgerLocal-balance"))
            {
                var lstTriplesStats = new List<Triple>();
                var lstTriplesSummary = new List<Triple>();

                var lstBalance = new List<Dictionary<string, object>>();
                
                var grap1 = new Graph();
                grap1.BaseUri = new Uri("http://graph.LedgerLocal.io/raw/balance");

                var lstJobjToPersist = new List<JObject>();
                var lstJobjStats = new List<Dictionary<string, object>>();

                try
                {
                    var dicoLastTrade = new Dictionary<string, object>();
                    var al1 = await _binanceClient.GetAccountInformation();
                    foreach (var a1 in al1.Balances.Where(x1 => x1.Free > 0 || x1.Locked > 0))
                    {
                        decimal? amountInUSD = null;

                        var obj1 = new JObject();
                        obj1.Add("asset", a1.Asset);
                        obj1.Add("free", a1.Free);
                        obj1.Add("locked", a1.Locked);

                        lstJobjToPersist.Add(obj1);

                        var tupleRes1 = _rdfStoreBusiness.SaveJsonObjectWithGraph(obj1, typeof(BalanceResponse), grap1, dateNow, "balance");
                        lstTriplesStats.AddRange(tupleRes1.Item2);
                        lstJobjStats.Add(tupleRes1.Item1);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "[STAT] Error during balance");
                }
                
                store.UpdateGraph("http://graph.LedgerLocal.io/raw/balance", lstTriplesStats, Enumerable.Empty<Triple>());
                _logger.LogInformation($"=> [Stats] Graph updated with {lstTriplesStats.Count} entries with success");
                _elasticBusiness.IndexJsonObject(lstJobjStats, string.Concat("binance-balance-", String.Format("{0:MM-yyyy}", dateNow)), "BinanceBalance");
                _logger.LogInformation($"=> [Stats] ElasticSearch pushed {lstJobjStats.Count} entries with success");
                                
            }

            _logger.LogInformation($"Stopping LedgerLocalStat...");
        }
    }
}
