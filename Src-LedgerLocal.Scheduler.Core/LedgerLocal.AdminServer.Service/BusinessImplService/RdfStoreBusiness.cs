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

namespace LedgerLocal.AdminServer.Service.BusinessImplService
{
    public class RdfStoreBusiness : IRdfStoreBusiness
    {

        public Tuple<Dictionary<string, object>, IList<Triple>> SaveJsonObjectWithGraph(JObject obj1, Type dtoType, Graph h, DateTime timestamp, string prefix)
        {

            var lstTriples = new List<Triple>();

            var guid = Guid.NewGuid();
            var uriId = new Uri(string.Concat("http://sem.LedgerLocal.local/", prefix, "/id/", guid));
            var grap1 = h;

            // Add Type

            var uriMeta01 = grap1.CreateUriNode(uriId);

            var uriMeta02 = grap1.GetUriNode(new Uri("http://sem.LedgerLocal.local/meta/type"));

            if (uriMeta02 == null)
            {
                uriMeta02 = grap1.CreateUriNode(new Uri("http://sem.LedgerLocal.local/meta/type"));
            }

            var uriMeta03 = grap1.GetLiteralNode(dtoType.AssemblyQualifiedName);

            if (uriMeta03 == null)
            {
                uriMeta03 = grap1.CreateLiteralNode(dtoType.AssemblyQualifiedName);
            }

            lstTriples.Add(new Triple(uriMeta01, uriMeta02, uriMeta03));

            // Add Date

            var uriMeta11 = grap1.CreateUriNode(uriId);

            var uriMeta12 = grap1.GetUriNode(new Uri("http://sem.LedgerLocal.local/meta/timestamp"));

            if (uriMeta12 == null)
            {
                uriMeta12 = grap1.CreateUriNode(new Uri("http://sem.LedgerLocal.local/meta/timestamp"));
            }

            var uriMeta13 = timestamp.ToLiteral(grap1);

            lstTriples.Add(new Triple(uriMeta11, uriMeta12, uriMeta13));

            foreach (var it1 in obj1)
            {

                if (it1.Value is JArray || it1.Value is JObject)
                {
                    continue;
                }

                var uri1 = uriMeta01;

                var uri2 = grap1.GetUriNode(new Uri(string.Concat("http://sem.LedgerLocal.local/", prefix, "/", WebUtility.UrlEncode(it1.Key))));

                if (uri2 == null)
                {
                    uri2 = grap1.CreateUriNode(new Uri(string.Concat("http://sem.LedgerLocal.local/", prefix, "/", WebUtility.UrlEncode(it1.Key))));
                }

                var uri3 = grap1.GetLiteralNode(it1.Value.ToString());

                if (uri3 == null)
                {
                    uri3 = grap1.CreateLiteralNode(it1.Value.ToString());
                }

                lstTriples.Add(new Triple(uri1, uri2, uri3));

            }

            obj1.Add("timestamp", timestamp);
            obj1.Add("dataType", dtoType.AssemblyQualifiedName);

            var dico1 = new Dictionary<string, object>();

            foreach (var v1 in obj1)
            {
                if (v1.Value is JArray || v1.Value is JObject)
                {
                    continue;
                }

                var k1 = v1.Key.Replace(" ", string.Empty).ToLowerInvariant();

                if (!dico1.ContainsKey(k1))
                {
                    dico1.Add(k1, v1.Value.ToObject<object>());
                }
            }

            return new Tuple<Dictionary<string, object>, IList<Triple>>(dico1, lstTriples);

        }
    }
}
