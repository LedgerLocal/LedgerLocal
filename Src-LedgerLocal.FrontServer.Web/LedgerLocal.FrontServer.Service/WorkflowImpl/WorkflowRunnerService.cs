using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Jint;
using LedgerLocal.FrontServer.Api.Web.Models;
using LedgerLocal.FrontServer.Service.Contract;
using LedgerLocal.FrontServer.Service.LedgerLocalServiceContract;
using LedgerLocal.FrontServer.Service.WorkflowContract;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LedgerLocal.FrontServer.Service.WorkflowImpl
{
    public class WorkflowRunnerService : IWorkflowRunnerService
    {
        private readonly IWorkflowService _workflowService;
        private readonly ILogger<WorkflowRunnerService> _logger;

        public WorkflowRunnerService(ILogger<WorkflowRunnerService> logger, IWorkflowService workflowService)
        {
            _logger = logger;
            _workflowService = workflowService;
        }

        public async Task<Tuple<bool, object>> ExecuteWorkflow(WorkflowExecutionWithArgs options)
        {
            _logger.LogInformation("ExecuteWorkflow {0}", JsonConvert.SerializeObject(options, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));


            Tuple<bool, object> result = new Tuple<bool, object>(true, null);
            var sb = new StringBuilder();

            try
            {
                var LedgerLocalJs = new LedgerLocalJs();

                var contentJs = options.LedgerLocalJsContent;

                if (string.IsNullOrWhiteSpace(contentJs))
                {
                    var dbContext = (IDbContextService)ServiceLocatorSingleton.Instance.ServiceProvider.GetService(typeof(IDbContextService));
                    dbContext.RefreshFullDomain();
                    var ws1 = (IWorkflowService)ServiceLocatorSingleton.Instance.ServiceProvider.GetService(typeof(IWorkflowService));
                    var w1 = await ws1.GetWorkflowByIdAsync(options.WorkflowId);

                    contentJs = Encoding.UTF8.GetString(Convert.FromBase64String(w1.Body));
                }

                ManualResetEvent oSignalEvent = new ManualResetEvent(false);

                var engine = new Engine(o => o
                            .DebugMode(options.Debug)
                            .AllowClr(typeof(VoucherCreateOrUpdate).GetTypeInfo().Assembly))

                    .SetValue("printJson", new Func<object, string>((x) =>
                    {
                        return JsonConvert.SerializeObject(x, Formatting.Indented);
                    }))

                    .SetValue("printConsole", new Action<string>((x) =>
                    {
                        sb.AppendLine(x);
                    }))

                    .SetValue("printLine", new Func<string>(() => Environment.NewLine))

                    .SetValue("awaitTask", new Action<Task>(async (task) => {
                        await task;
                    }))
                    
                    .SetValue("LedgerLocalJs", LedgerLocalJs)
                    .SetValue("LedgerLocalArgs", options.DicoArgs);

                var resultInner = engine
                    .Execute(contentJs)
                    .GetCompletionValue()
                    .ToObject();

                oSignalEvent.Set();

                oSignalEvent.WaitOne(options.Timeout);

                var res1 = new { Result = resultInner, Console = sb.ToString() };

                _logger.LogInformation("ExecuteWorkflow Finished: {0}", JsonConvert.SerializeObject(res1, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));

                result = new Tuple<bool, object>(true, JsonConvert.SerializeObject(res1, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            }
            catch (Exception ex)
            {
                result = new Tuple<bool, object>(false, JsonConvert.SerializeObject(ex, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            }

            return result;
        }

        
    }
}
