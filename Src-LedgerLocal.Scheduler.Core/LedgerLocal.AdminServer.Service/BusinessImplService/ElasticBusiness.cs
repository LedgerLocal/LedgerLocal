using Nest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml;
using LedgerLocal.AdminServer.Service.BusinessImplService.Contract;
using VDS.RDF;
using VDS.RDF.Query;
using VDS.RDF.Storage;

namespace LedgerLocal.AdminServer.Service.BusinessImplService
{
    public class ElasticBusiness : IElasticBusiness
    {

        private readonly IElasticClient _elasticClient;

        public ElasticBusiness(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public void IndexJsonObject(IEnumerable<Dictionary<string, object>> obj1, string indexName, string type)
        {

            var bdesc = new BulkDescriptor();

            bdesc.IndexMany(obj1, (f, g) => f.Index(indexName).Type(type));

            var x = _elasticClient.Bulk(bdesc);

        }

    }
}
