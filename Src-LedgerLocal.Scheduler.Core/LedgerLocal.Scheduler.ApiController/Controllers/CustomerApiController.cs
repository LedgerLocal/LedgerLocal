
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.SwaggerGen.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using LedgerLocal.AdminServer.Service;
using LedgerLocal.AdminServer.Service.Contract;
using LedgerLocal.AdminServer.Api.Web.Models;

namespace LedgerLocal.AdminServer.ApiController.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [EnableCors("SiteCorsPolicy")]
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
            User.CheckIfValidCustomerId(id, true);

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
            User.CheckIfValidCustomerId(body.CustomerId, true);

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
