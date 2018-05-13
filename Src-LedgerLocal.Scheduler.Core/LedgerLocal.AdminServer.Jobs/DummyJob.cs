using System;
using System.Threading.Tasks;
using Quartz;
using Serilog;
using LedgerLocal.AdminServer.Service;
using LedgerLocal.AdminServer.Service.Contract;
using System.Threading;

namespace LedgerLocal.AdminServer.Jobs
{
    [DisallowConcurrentExecution]
    public class DummyJob : IJob
    {

        private readonly ILogger _logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.LiterateConsole()
                    .CreateLogger();

        public DummyJob()
        {
        }

        async Task IJob.Execute(IJobExecutionContext context)
        {
            _logger.Information($"Starting DummyJob...");

            await Task.Factory.StartNew(() =>
            {
                //var users = _customerService.GetAllUsers();

                //_logger.Information($"List users: {users.Count}");
                //foreach(var u in users)
                //{
                //    _logger.Information($"->User: {u.Email}");
                //}

                Thread.Sleep(10000);
            });
        }
    }
}
