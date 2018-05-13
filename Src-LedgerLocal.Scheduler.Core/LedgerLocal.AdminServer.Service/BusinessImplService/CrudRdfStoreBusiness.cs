using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml;
using LedgerLocal.AdminServer.Service.BusinessImplService.Contract;
using VDS.RDF;
using VDS.RDF.Query;
using VDS.RDF.Storage;
using VDS.RDF.Parsing;

namespace LedgerLocal.AdminServer.Service.BusinessImplService
{
    public class CrudRdfStoreBusiness : ICrudRdfStoreBusiness
    {
        private bool Exists<T>(T obj1, Func<T, string> idFunc)
            where T : class
        {
            return false;
        }

        private void CreateObject<T>(T obj1, Func<T, string> idFunc)
            where T : class
        {
            using (var _graphConn = new BlazegraphConnector("http://51.144.44.26:8080/blazegraph", "oqtopus-main"))
            {
                var grap1 = new Graph();
                grap1.BaseUri = new Uri("http://graph.oqtopus.io/raw/logic");

                var lstTriples = new List<Triple>();

                _graphConn.UpdateGraph("http://graph.oqtopus.io/raw/logic", lstTriples, Enumerable.Empty<Triple>());

            }
        }

        private void UpdateObject<T>(T obj1, Func<T, string> idFunc)
            where T : class
        {
            using (var _graphConn = new BlazegraphConnector("http://51.144.44.26:8080/blazegraph", "oqtopus-main"))
            {
                var grap1 = new Graph();
                grap1.BaseUri = new Uri("http://graph.oqtopus.io/raw/logic");

                var lstTriples = new List<Triple>();

                _graphConn.UpdateGraph("http://graph.oqtopus.io/raw/logic", lstTriples, Enumerable.Empty<Triple>());

            }
        }

        private T RetrieveObject<T>(Func<T, bool> where)
            where T : class
        {
            using (var _graphConn = new BlazegraphConnector("http://51.144.44.26:8080/blazegraph", "oqtopus-main"))
            {
                var grap1 = new Graph();
                grap1.BaseUri = new Uri("http://graph.oqtopus.io/raw/logic");

            }

            return null;
        }


        public Tuple<T, IList<Triple>> SaveOrUpdateObject<T>(T obj1, Func<T, string> idFunc) 
            where T : class
        {

            if (Exists<T>(obj1, idFunc))
            {
                UpdateObject(obj1, idFunc);
            }
            else
            {
                CreateObject(obj1, idFunc);
            }

            return null;

        }

        public T GetObject<T>(Func<T, bool> where)
            where T : class
        {

            return RetrieveObject(where);

        }

        public List<T> GetObjects<T>()
            where T : class
        {

            return new List<T>();

        }

    }
}
