using LedgerLocal.FrontServer.Api.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.FrontServer.Service.WorkflowContract
{
    public interface IWorkflowRunnerService
    {
        Task<Tuple<bool, object>> ExecuteWorkflow(WorkflowExecutionWithArgs options);
    }
}
