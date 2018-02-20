using LedgerLocal.FrontServer.Api.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.FrontServer.Service
{
    public interface IWorkflowService
    {
        Task<IList<WorkflowDescription>> GetAllWorkflowAsync();
        
        Task<WorkflowDescription> GetWorkflowByIdAsync(string worflowId);

        Task<WorkflowDescription> CreateWorkflowAsync(WorkflowCreateOrUpdate worflow);

        Task<WorkflowDescription> UpdateWorkflowAsync(WorkflowCreateOrUpdate worflow);
    }
}
