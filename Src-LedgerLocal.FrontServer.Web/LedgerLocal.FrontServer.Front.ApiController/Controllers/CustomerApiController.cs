using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.SwaggerGen.Annotations;
using LedgerLocal.FrontServer.Api.Web.Models;
using LedgerLocal.FrontServer.Service;
using LedgerLocal.FrontServer.Service.Contract;

namespace LedgerLocal.FrontServer.Api.Web.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    public class CustomerApiController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IDbContextService _dbContext;

        public CustomerApiController(ICustomerService customerService,
            IDbContextService dbContext)
        {
            _customerService = customerService;
            _dbContext = dbContext;
        }


        /// <summary>
        /// Find customer by ID
        /// </summary>
        /// <remarks>Returns customers based on ID</remarks>
        /// <param name="id">customer Id</param>
        /// <response code="200">customer response</response>
        /// <response code="0">error payload</response>
        [HttpGet]
        [Route("/v1/customer/byId")]
        [SwaggerOperation("CustomerByIdGet")]
        [ProducesResponseType(typeof(CustomerProfile), 200)]
        public virtual async Task<IActionResult> CustomerByIdGet([FromQuery]string id)
        {
            _dbContext.RefreshFullDomain();
            var cust = await _customerService.GetCustomerByIdAsync(id);
            return new ObjectResult(cust);
        }

        /// <summary>
        /// Create customer
        /// </summary>
        /// <remarks>Create customer</remarks>
        /// <param name="body">Customer object that needs to be added to the store</param>
        /// <response code="200">customer response</response>
        /// <response code="0">error payload</response>
        [HttpPost]
        [Route("/v1/customer/create")]
        [SwaggerOperation("CustomerCreatePost")]
        [ProducesResponseType(typeof(List<CustomerProfile>), 200)]
        public virtual async Task<IActionResult> CustomerCreatePost([FromBody]CustomerCreateOrUpdate body)
        {
            _dbContext.RefreshFullDomain();
            var cust = await _customerService.CreateCustomerAsync(body);
            return new ObjectResult(cust);
        }


        /// <summary>
        /// Find customers by where clause, and filter
        /// </summary>
        /// <remarks>Returns list of Customers</remarks>
        /// <param name="skip">number of items to skip</param>
        /// <param name="limit">max records to return</param>
        /// <param name="where">Where clause</param>
        /// <response code="200">customer response</response>
        /// <response code="0">error payload</response>
        [HttpGet]
        [Route("/v1/customer/list")]
        [SwaggerOperation("CustomerListGet")]
        [ProducesResponseType(typeof(List<CustomerProfile>), 200)]
        public virtual async Task<IActionResult> CustomerListGet([FromQuery]int? skip, [FromQuery]int? limit, [FromQuery]string where)
        {
            _dbContext.RefreshFullDomain();
            var custs = await _customerService.GetAllCustomersAsync();
            return new ObjectResult(custs.ToList());
        }


        /// <summary>
        /// Update or Create Customer
        /// </summary>
        /// <remarks>Update or Create customer</remarks>
        /// <param name="body">Customer object that needs to be added to the store</param>
        /// <response code="200">customer response</response>
        /// <response code="0">error payload</response>
        [HttpPut]
        [Route("/v1/customer/update")]
        [SwaggerOperation("CustomerUpdatePut")]
        [ProducesResponseType(typeof(List<CustomerProfile>), 200)]
        public virtual async Task<IActionResult> CustomerUpdatePut([FromBody]CustomerCreateOrUpdate body)
        {
            _dbContext.RefreshFullDomain();
            var cust = await _customerService.UpdateCustomerAsync(body);
            return new ObjectResult(cust);
        }


        /// <summary>
        /// Customer Profile
        /// </summary>
        /// <remarks>The User Profile endpoint returns information about the LedgerLocal user that has authorized with the application.</remarks>
        /// <response code="200">Profile information for a user</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/v1/customer/me")]
        [SwaggerOperation("CustomerMeGet")]
        [ProducesResponseType(typeof(CustomerProfile), 200)]
        public virtual IActionResult CustomerMeGet()
        {
            _dbContext.RefreshFullDomain();
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<CustomerProfile>(exampleJson)
            : default(CustomerProfile);
            return new ObjectResult(example);
        }
    }
}
