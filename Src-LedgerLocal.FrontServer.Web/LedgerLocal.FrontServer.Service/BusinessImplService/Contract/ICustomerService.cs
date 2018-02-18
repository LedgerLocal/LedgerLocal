using LedgerLocal.FrontServer.Api.Web.Models;
using LedgerLocal.FrontServer.Model.FullDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.FrontServer.Service
{
    public interface ICustomerService
    {
        Task<IList<CustomerProfile>> GetAllCustomersAsync();

        Task<CustomerProfile> GetCustomerByIdAsync(string customerId);

        Task<CustomerProfile> CreateCustomerAsync(CustomerCreateOrUpdate customer);

        Task<CustomerProfile> UpdateCustomerAsync(CustomerCreateOrUpdate customer);
    }
}
