using BinanceExchange.API.Models.WebSocket;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using LedgerLocal.AdminServer.Service.BusinessImplService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using VDS.RDF;
using VDS.RDF.Storage;

namespace LedgerLocal.AdminServer.Service.BusinessImplService
{
    public class RunningStatBusiness : IRunningStatBusiness
    {
        private readonly IRdfStoreBusiness _rdfStoreBusiness;
        private readonly IElasticBusiness _elasticBusiness;
        private readonly ILogger<RunningStatBusiness> _logger;

        public RunningStatBusiness(
            IRdfStoreBusiness rdfStoreBusiness,
            IElasticBusiness elasticBusiness,
            IBotService botService,
            ILogger<RunningStatBusiness> logger
            )
        {
            _rdfStoreBusiness = rdfStoreBusiness;
            _elasticBusiness = elasticBusiness;
            _logger = logger;
        }

    }
}
