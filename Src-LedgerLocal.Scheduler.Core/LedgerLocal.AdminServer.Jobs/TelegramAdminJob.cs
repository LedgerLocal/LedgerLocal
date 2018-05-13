using System;
using System.Threading.Tasks;
using Quartz;
using LedgerLocal.AdminServer.Service.BusinessImplService.Contract;
using Microsoft.Extensions.Logging;

namespace LedgerLocal.AdminServer.Jobs
{
    [DisallowConcurrentExecution]
    public class TelegramAdminJob : IJob
    {
        private readonly IBotService _botService;
        private readonly ILogger<TelegramAdminJob> _logger;

        public TelegramAdminJob(
            IBotService botService,
            ILogger<TelegramAdminJob> logger
            )
        {
            _botService = botService;
            _logger = logger;
        }

        async Task IJob.Execute(IJobExecutionContext context)
        {
            var dateNow = DateTime.UtcNow;

            _logger.LogInformation($"Starting TelegramAdminJob with UTC date {String.Format("{0:F}", dateNow)} ...");

            if (!_botService.IsStarted)
            {
                _botService.Start();
            }

            while (_botService.Running)
            {
                await Task.Delay(1000);
            }
        }

    }
}
