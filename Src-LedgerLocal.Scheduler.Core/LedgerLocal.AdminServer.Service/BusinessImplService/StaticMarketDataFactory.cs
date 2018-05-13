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
using LedgerLocal.AdminServer.Api.Web.Models;

namespace LedgerLocal.AdminServer.Service.BusinessImplService
{
    public class StaticMarketDataFactory : IStaticMarketDataFactory
    {
        private List<CustomerProfile> _instance;

        public StaticMarketDataFactory()
        {
            _instance = new List<CustomerProfile>();
        }

        public List<CustomerProfile> GetCustomers
        {
            get
            {
                return _instance;
            }
        }
    }
}
