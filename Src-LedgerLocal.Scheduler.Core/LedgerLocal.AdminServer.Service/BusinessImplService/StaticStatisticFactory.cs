using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using LedgerLocal.AdminServer.Dto;
using LedgerLocal.AdminServer.Service.BusinessImplService.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml;
using VDS.RDF;
using VDS.RDF.Query;
using VDS.RDF.Storage;

namespace LedgerLocal.AdminServer.Service.BusinessImplService
{
    public class StaticStatisticFactory : IStaticStatisticFactory
    {
        private StaticLedgerLocalStatisticDto _instance;

        public StaticStatisticFactory()
        {
            _instance = new StaticLedgerLocalStatisticDto();
        }

        public StaticLedgerLocalStatisticDto GetStatistic
        {
            get
            {
                return _instance;
            }
        }
    }
}
