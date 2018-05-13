using System;
using System.Threading.Tasks;
using Quartz;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using LedgerLocal.AdminServer.Service.Contract;
using LoyaltyCoin.AdminServer.Service.LycServiceContract;

namespace LedgerLocal.AdminServer.Jobs
{
    [DisallowConcurrentExecution]
    public class KafkaListenerJob : IJob
    {
        private readonly IDbContextService _dbContextService;
        private readonly IKafkaEventService _kafkaMessageService;

        private readonly ILogger<KafkaListenerJob> _logger;

        public KafkaListenerJob(
                ILogger<KafkaListenerJob>  logger, 
                IDbContextService dbContextService, 
                IKafkaEventService kafkaMessageService
            )
        {
            _logger = logger;
            _dbContextService = dbContextService;
            _kafkaMessageService = kafkaMessageService;
        }

        async Task IJob.Execute(IJobExecutionContext context)
        {
            _logger.LogInformation($"Starting KafkaMessagePooling ...");

            _dbContextService.RefreshFullDomain();

            IList<Task> tasks = new List<Task>();

            tasks.Add(_kafkaMessageService.PoolMessageFromKafka(TimeSpan.FromMinutes(10)));

            await Task.WhenAll(tasks);

            _logger.LogInformation($"Stopping KafkaMessagePooling ...");
        }
    }
}
