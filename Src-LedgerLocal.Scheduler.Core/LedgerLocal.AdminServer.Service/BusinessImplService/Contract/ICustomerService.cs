using LedgerLocal.AdminServer.Api.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LedgerLocal.AdminServer.Service
{
    public interface ICustomerService
    {
        Task<IList<CustomerProfile>> GetAllCustomersAsync();

        Task<CustomerProfile> GetCustomerByIdAsync(string customerId);

        Task<CustomerProfile> CreateCustomerAsync(CustomerCreateOrUpdate customer);

        Task<CustomerProfile> UpdateCustomerAsync(CustomerCreateOrUpdate customer);
    }
}
