using System;
using System.Threading.Tasks;
using Quartz;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using LedgerLocal.AdminServer.Service.Contract;
using LedgerLocal.AdminServer.Service.LycServiceContract;

namespace LedgerLocal.AdminServer.Jobs
{
    [DisallowConcurrentExecution]
    public class KafkaListenerJob : IJob
    {
        private readonly IKafkaEventService _kafkaMessageService;

        private readonly ILogger<KafkaListenerJob> _logger;

        public KafkaListenerJob(
                ILogger<KafkaListenerJob>  logger, 
                IKafkaEventService kafkaMessageService
            )
        {
            _logger = logger;
            _kafkaMessageService = kafkaMessageService;
        }

        async Task IJob.Execute(IJobExecutionContext context)
        {
            _logger.LogInformation($"Starting KafkaMessagePooling ...");
            
            IList<Task> tasks = new List<Task>();

            tasks.Add(_kafkaMessageService.PoolMessageFromKafka(TimeSpan.FromMinutes(10)));

            await Task.WhenAll(tasks);

            _logger.LogInformation($"Stopping KafkaMessagePooling ...");
        }
    }
}
