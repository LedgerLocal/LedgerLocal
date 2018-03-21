using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audit.Core;
using Audit.WebApi;
using Nest;
using Newtonsoft.Json.Linq;
using System.Collections.Concurrent;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using Elasticsearch.Net;
using System.Diagnostics;

namespace LedgerLocal.FrontServer.Service.AuditProvider
{
    public class ElasticAuditDataProvider : AuditDataProvider, IDisposable
    {
        internal string _connectionString = "http://169.57.30.22:30200";
        internal string _tableName = "auditsearch";
        internal string _idColumnName = "id";
        internal string _jsonColumnName = "data";
        internal string _lastUpdatedColumnName = "updated";

        private readonly BlockingCollection<Tuple<string, JObject>> _queueElasticToBePosted = new BlockingCollection<Tuple<string, JObject>>();
        //private readonly BlockingCollection<AuditSearchQueueDto> _queueBusToBePosted = new BlockingCollection<AuditSearchQueueDto>();
        private IElasticClient _client;
        private Action<string, JObject> _scribeProcessorElastic;
        //private Action<AuditSearchQueueDto> _scribeProcessorBus;

        private readonly object _sync = new object();

        public ElasticAuditDataProvider() : base()
        {
            Initialize();
        }

        private void Initialize()
        {
            SetupObserverBatchyElastic();
            SetupObserverBatchyBus();
        }

        /// <summary>
        /// The Elastic connection string
        /// </summary>
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        /// <summary>
        /// The events Index Name
        /// </summary>
        public string IndexName
        {
            get
            {
                return _tableName.ToLower() + "-" + DateTime.UtcNow.ToString("yyyy-MM");
            }
            set { _tableName = value; }
        }

        /// <summary>
        /// The Column Name that stores the JSON
        /// </summary>
        public string JsonColumnName
        {
            get { return _jsonColumnName; }
            set { _jsonColumnName = value; }
        }

        /// <summary>
        /// The Column Name that stores the Last Updated Date (NULL to ignore)
        /// </summary>
        public string LastUpdatedDateColumnName
        {
            get { return _lastUpdatedColumnName; }
            set { _lastUpdatedColumnName = value; }
        }

        /// <summary>
        /// The Column Name that is the primary ley
        /// </summary>
        public string IdColumnName
        {
            get { return _idColumnName; }
            set { _idColumnName = value; }
        }

        public IElasticClient Client
        {
            get
            {
                try
                {
                    lock (_sync)
                    {
                        if (_client == null)
                        {
                            var uri = new Uri(_connectionString);
                            _client = new ElasticClient(uri);
                        }

                        return _client;
                    }
                }
                catch (Exception e)
                {
                    Debug.Fail(e.Message);
                }

                return null;
            }
        }

        //public IBus BusClient
        //{
        //    get
        //    {
        //        //if (HttpContext.Current != null
        //        //    && HttpContext.Current.Request != null
        //        //    && HttpContext.Current.Request.IsLocal)
        //        //{
        //        //    return null;
        //        //}

        //        //var allInsts = ServiceLocator.Current.GetInstance<IBus>("csRmqBus");

        //        //if (allInsts != null)
        //        //{
        //        //    return allInsts;
        //        //}

        //        //try
        //        //{
        //        //    var connectionString = ConfigurationManager.ConnectionStrings["easynetq"];
        //        //    return RabbitHutch.CreateBus(connectionString.ConnectionString);
        //        //}
        //        //catch (Exception e)
        //        //{
        //        //    Debug.Fail(e.Message);
        //        //}

        //        return null;
        //    }
        //}

        private void SetupObserverBatchyElastic()
        {
            _scribeProcessorElastic = (a, b) => WriteToQueueForprocessingElastic(a, b);

            this._queueElasticToBePosted.GetConsumingEnumerable()
                .ToObservable(Scheduler.Default)
                .Buffer(TimeSpan.FromSeconds(1), 5)
                .Subscribe(async x => await this.WriteDirectlyToESAsBatch(x));
        }

        private void SetupObserverBatchyBus()
        {
            //_scribeProcessorBus = a => WriteToQueueForprocessingBus(a);

            //this._queueBusToBePosted.GetConsumingEnumerable()
            //    .ToObservable(Scheduler.Default)
            //    .Buffer(TimeSpan.FromSeconds(1), 5)
            //    .Subscribe(x => this.WriteDirectlyToBusAsBatch(x));
        }

        private void WriteToQueueForprocessingElastic(string op, JObject jo)
        {
            try
            {
                this._queueElasticToBePosted.Add(new Tuple<string, JObject>(op, jo));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        //private void WriteToQueueForprocessingBus(AuditSearchQueueDto jo)
        //{
        //    try
        //    {
        //        this._queueBusToBePosted.Add(jo);
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //    }
        //}

        private async Task WriteDirectlyToESAsBatch(IEnumerable<Tuple<string, JObject>> jos)
        {
            try
            {
                //if (jos == null || jos.Count() < 1)
                //    return;

                //var indxC = jos.Select(c => new { index = new { _index = IndexName, _type = "Audit", _id = c.Item1 } });

                //var bb = jos.Zip(indxC, (f, s) => new object[] { s, f.Item2 });
                //var bbo = bb.SelectMany(a => a);

                //var clt = Client;
                //if (clt != null)
                //{
                //    var res = await clt.LowLevel.BulkAsync<VoidResponse>(IndexName, "Audit", new PostData<object>(bbo.ToArray()));
                //    if (!(res != null && res.Success))
                //    {
                //        Debug.WriteLine("Error inserting into ES");
                //    }
                //}

                await Task.Run(() => { });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        //private async Task WriteDirectlyToBusAsBatch(IEnumerable<AuditSearchQueueDto> jos)
        //{
        //    try
        //    {
        //        if (jos == null || jos.Count() < 1)
        //            return;

        //        foreach (var j in jos)
        //        {
        //            await Task.Factory.StartNew(() =>
        //            {
        //                using (var clt = BusClient)
        //                {
        //                    if (clt != null)
        //                    {
        //                        clt.Publish<AuditSearchQueueDto>(j);
        //                    }
        //                }
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //    }
        //}

        public override object InsertEvent(Audit.Core.AuditEvent auditEvent)
        {
            try
            {
                var guidString = Guid.NewGuid().ToString();
                var acObj = auditEvent.GetWebApiAuditAction();

                //if (acObj != null
                //    && acObj.Headers != null
                //    && acObj.Headers.ContainsKey("GhostMode"))
                //{
                //    return guidString;
                //}

                //if (HttpContext.Current != null
                //    && HttpContext.Current.Request != null
                //    && HttpContext.Current.Request.Headers != null
                //    && (HttpContext.Current.Request.Headers.AllKeys.Contains("GhostMode")
                //        && !HttpContext.Current.Request.Headers.AllKeys.Contains("NoGhostMode")))
                //{
                //    return guidString;
                //}

                if (acObj != null
                    && !string.IsNullOrWhiteSpace(acObj.ControllerName)
                    && (acObj.ControllerName.Contains("Cmap")
                    || acObj.ControllerName.Contains("Dss")
                    || acObj.ControllerName.Contains("Store")
                    || acObj.ControllerName.Contains("Audit")))
                {
                    acObj.ActionParameters = null;
                }

                var json = auditEvent.ToJson();
                var jsonObj = JObject.Parse(json);
                var now = DateTime.UtcNow;

                jsonObj.Add("CsId", guidString);
                jsonObj.Add("CsUpdated", now);

                WriteToQueueForprocessingElastic(guidString, jsonObj);

                var resIp = string.Empty;
                if (jsonObj != null && jsonObj.SelectToken("Action") != null && jsonObj.SelectToken("Action").SelectToken("IpAddress") != null)
                {
                    resIp = jsonObj.SelectToken("Action").SelectToken("IpAddress").ToString();
                }

                //var msg = new AuditSearchQueueDto
                //{
                //    Id = guidString,
                //    Operation = "INSERT",
                //    Updated = now,
                //    Duration = auditEvent.Duration,
                //    MachineName = auditEvent.Environment.MachineName,
                //    UrlCalled = auditEvent.EventType,
                //    Ip = resIp,
                //    IndexName = IndexName,
                //    Success = false
                //};

                //WriteToQueueForprocessingBus(msg);
                return guidString;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return "error";
        }

        public override void ReplaceEvent(object eventId, Audit.Core.AuditEvent auditEvent)
        {
            try
            {
                var guidString = eventId.ToString();
                var json = auditEvent.ToJson();
                var jsonObj = JObject.Parse(json);

                var acObj = auditEvent.GetWebApiAuditAction();

                //if (acObj != null
                //    && acObj.Headers != null
                //    && acObj.Headers.ContainsKey("GhostMode"))
                //{
                //    return;
                //}

                //if (HttpContext.Current != null
                //    && HttpContext.Current.Request != null
                //    && HttpContext.Current.Request.Headers != null
                //    && (HttpContext.Current.Request.Headers.AllKeys.Contains("GhostMode")
                //        && !HttpContext.Current.Request.Headers.AllKeys.Contains("NoGhostMode")))
                //{
                //    return;
                //}

                if (acObj != null
                    && !string.IsNullOrWhiteSpace(acObj.ControllerName)
                    && (acObj.ControllerName.Contains("Cmap")
                    || acObj.ControllerName.Contains("Dss")
                    || acObj.ControllerName.Contains("Store")
                    || acObj.ControllerName.Contains("Audit")))
                {
                    acObj.ActionParameters = null;
                }

                var now = DateTime.UtcNow;

                if (jsonObj.SelectToken("CsId") == null)
                {
                    jsonObj.Add("CsId", guidString);
                }

                if (jsonObj.SelectToken("CsUpdated") == null)
                {
                    jsonObj.Add("CsUpdated", now);
                }

                WriteToQueueForprocessingElastic(guidString, jsonObj);

                var resIp = string.Empty;
                if (jsonObj != null && jsonObj.SelectToken("Action") != null && jsonObj.SelectToken("Action").SelectToken("IpAddress") != null)
                {
                    resIp = jsonObj.SelectToken("Action").SelectToken("IpAddress").ToString();
                }

                //var msg = new AuditSearchQueueDto
                //{
                //    Id = guidString,
                //    Operation = "UPDATE",
                //    Updated = now,
                //    Duration = auditEvent.Duration,
                //    MachineName = auditEvent.Environment.MachineName,
                //    UrlCalled = auditEvent.EventType,
                //    Ip = resIp,
                //    IndexName = IndexName,
                //    Success = true
                //};

                //WriteToQueueForprocessingBus(msg);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public void Dispose()
        {
            //this._queueBusToBePosted.Dispose();
            this._queueElasticToBePosted.Dispose();
        }
    }
}
