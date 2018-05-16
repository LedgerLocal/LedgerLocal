using System;
using System.Threading.Tasks;
using Quartz;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using LedgerLocal.Service.ChainService;
using LedgerLocal.Blockchain.Service.LycServiceContract;
using LedgerLocal.AdminServer.Api.Web.Models;
using System.Linq;
using LedgerLocal.Service.GrapheneLogic;
using LedgerLocal.AdminServer.Service.BusinessImplService.Contract;
using Newtonsoft.Json.Linq;

namespace LedgerLocal.AdminServer.Jobs
{
    [DisallowConcurrentExecution]
    public class AccountListenerJob : IJob
    {
        private readonly IAccountService _accountService;
        private readonly ICommonMessageService _commonMessageService;
        private readonly IParticipateBusinessService _participateBusinessService;

        private readonly ILogger<AccountListenerJob> _logger;

        public AccountListenerJob(
                ILogger<AccountListenerJob>  logger, 
                IAccountService accountService,
                ICommonMessageService commonMessageService,
                IParticipateBusinessService participateBusinessService
            )
        {
            _logger = logger;
            _accountService = accountService;
            _commonMessageService = commonMessageService;
            _participateBusinessService = participateBusinessService;
        }

        async Task IJob.Execute(IJobExecutionContext context)
        {
            _logger.LogInformation($"Starting AccountListenerJob ...");

            IList<Task<WebSocketSession>> tasks = new List<Task<WebSocketSession>>();

            tasks.Add(_accountService.SubscribeToAccountBalance("1.2.800691", new string[] { "2.5.1362979", "2.5.2060980" }, async (a1) =>
            {

                var jObj = JObject.Parse(a1);
                var jArr1 = (JArray)jObj["params"];
                var t1 = jArr1[1][0][0]["asset_type"];

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

                await _participateBusinessService.FinalizeTrades(t1.ToString());
                
            }));

            await Task.WhenAll(tasks);

            var ws1 = tasks.First().Result;

            while (ws1.IsBusy)
            {
                await Task.Delay(1000);
            }

            _logger.LogInformation($"Stopping AccountListenerJob ...");
        }
    }
}
