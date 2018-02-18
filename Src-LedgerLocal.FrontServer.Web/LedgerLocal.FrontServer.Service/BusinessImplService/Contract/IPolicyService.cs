using LedgerLocal.FrontServer.Api.Web.Models;
using LedgerLocal.FrontServer.Model.FullDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.FrontServer.Service
{
    public interface IPolicyService
    {
        Task<List<PolicyDescription>> GetPolicyByNameAsync(string name);
        
        Task<PolicyDescription> CreatePolicyAsync(PolicyCreateOrUpdate policy);

        Task<PolicyDescription> UpdatePolicyAsync(PolicyCreateOrUpdate policy);
    }
}
