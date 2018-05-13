using LedgerLocal.Blockchain.Service.KafkaMessager.Contract;
using LedgerLocal.Blockchain.Service.LycServiceContract.Architecture;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Collections.Concurrent;
using LedgerLocal.Blockchain.Service.KafkaMessager;
using Newtonsoft.Json.Linq;
using LedgerLocal.AdminServer.Service.KafkaMessager.KafkaReactive;

namespace LedgerLocal.Blockchain.Service.LycServiceContract
{
    public class CommonMessageService : ICommonMessageService
    {
        private readonly IKafkaConfigFactory _kafkaConfig;

        private readonly IKafkaFacade _kafkaFacade;

        private readonly Serilog.ILogger _logger = new Serilog.LoggerConfiguration()
                                                        .CreateLogger()
                                                        .ForContext<CommonMessageService>();
        private readonly object _sync = new object();

        public CommonMessageService(IKafkaConfigFactory config, IKafkaFacade kafkaFacade)
        {
            _kafkaConfig = config;
            _kafkaFacade = kafkaFacade;
        }

        public async Task PoolMessage<T>(string topicName, TimeSpan timeSpan, Action<string, string, T> cb) where T : class
        {
            var consumerPool = _kafkaFacade.ProducerConsumerStore.GetConsumer(topicName);

            var resPast = consumerPool.BlockingCollentionPublic.Where(x => x?.Value?.Value == consumerPool.LastMessage?.Value?.Value
                && x?.Value?.Key == consumerPool.LastMessage?.Value?.Key);

            if (resPast.Any())
            {
                var reverseList = consumerPool.BlockingCollentionPublic.Reverse();
                foreach (var it in reverseList)
                {
                    if (it == resPast.First())
                    {
                        break;
                    }

                    consumerPool.LastMessage = it;
                    if (it.IsSuccess)
                    {
                        var obj = JsonConvert.DeserializeObject<T>(it.Value.Value);
                        cb(topicName, it.Value.Key, obj);
                    }
                }
            }

            consumerPool.ObserverPublic.Subscribe((a) =>
            {
                consumerPool.LastMessage = a;
                if (a.IsSuccess)
                {
                    var obj = JsonConvert.DeserializeObject<T>(a.Value.Value);
                    cb(topicName, a.Value.Key, obj);
                }
            });

            await Task.Delay(timeSpan);
        }

        public async Task<CommonMessageEncapsulator<T>> ConsumeMessage<T>(string topicName, 
            string key, 
            TimeSpan timeSpan) where T : class
        {
            CommonMessageEncapsulator<T> resultMessage = null;

            await Task.Factory.StartNew(() =>
            {
                ManualResetEvent oSignalEvent = new ManualResetEvent(false);
                var consumerPool = _kafkaFacade.ProducerConsumerStore.GetConsumer(topicName);

                var resPast = consumerPool.BlockingCollentionPublic.Where(x => x?.Value?.Key == key);

                if (resPast.Any())
                {
                    var it = resPast.First();
                    var obj = JsonConvert.DeserializeObject<T>(it.Value.Value);
                    resultMessage = new CommonMessageEncapsulator<T>(obj);
                    oSignalEvent.Set();
                }

                EventHandler<KafkaEventArgs> eventH1 = (object sender, KafkaEventArgs e) =>
                {
                    var a = e.Record;
                    consumerPool.LastMessage = a;
                    if (a.IsSuccess && a.Value.Key.Equals(key, StringComparison.OrdinalIgnoreCase))
                    {
                        var obj = JsonConvert.DeserializeObject<T>(a.Value.Value);
                        resultMessage = new CommonMessageEncapsulator<T>(obj);
                        oSignalEvent.Set();
                    }
                };

                consumerPool.SubscribeConsumePublic += eventH1;

                oSignalEvent.WaitOne(timeSpan);

                consumerPool.SubscribeConsumePublic -= eventH1;
            });

            return resultMessage;
        }

        public async Task SendMessage<T>(string topicName, string key, T val)
            where T : class
        {
            var producer = _kafkaFacade.ProducerConsumerStore.GetProducer(topicName);

            await Task.Factory.StartNew(() =>
            {
                producer.ProducerBlockingQueue.Add(new Record<string, string>(key, JsonConvert.SerializeObject(val)));
            });
        }

        
        private static bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        
    }
}
