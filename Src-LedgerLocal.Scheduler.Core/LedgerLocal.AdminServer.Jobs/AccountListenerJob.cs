using System;
using System.Threading.Tasks;
using Quartz;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using LedgerLocal.AdminServer.Service.Contract;
using LedgerLocal.AdminServer.Service.LycServiceContract;
using LedgerLocal.Service.ChainService;
using LedgerLocal.Blockchain.Service.LycServiceContract;
using LedgerLocal.AdminServer.Api.Web.Models;

namespace LedgerLocal.AdminServer.Jobs
{
    [DisallowConcurrentExecution]
    public class AccountListenerJob : IJob
    {
        private readonly IAccountService _accountService;
        private readonly ICommonMessageService _commonMessageService;

        private readonly ILogger<AccountListenerJob> _logger;

        public AccountListenerJob(
                ILogger<AccountListenerJob>  logger, 
                IAccountService accountService,
                ICommonMessageService commonMessageService
            )
        {
            _logger = logger;
            _accountService = accountService;
            _commonMessageService = commonMessageService;
        }

        async Task IJob.Execute(IJobExecutionContext context)
        {
            _logger.LogInformation($"Starting AccountListenerJob ...");

            IList<Task> tasks = new List<Task>();

            tasks.Add(_accountService.SubscribeToAccountBalance("1.2.800691", new string[] { "2.5.1362979", "2.5.2060980" }, async (a1) =>
            {
                var guidString = Guid.NewGuid().ToString();
                await _commonMessageService.SendMessage<ActionEventDefinition>("llc-event-broadcast", guidString, 
                    new ActionEventDefinition()
                    {
                        ActionName = "BalanceChanged",
                        Message = a1,
                        Timestamp = DateTime.UtcNow,
                        Success = true,
                        Reason = "Subscription"
                    });
            }));

            await Task.WhenAll(tasks);

            _logger.LogInformation($"Stopping AccountListenerJob ...");
        }
    }
}
