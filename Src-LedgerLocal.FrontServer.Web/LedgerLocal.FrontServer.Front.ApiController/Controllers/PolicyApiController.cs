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
    public class PolicyApiController : Controller
    { 
        private readonly IPolicyService _policyService;
        private readonly IDbContextService _dbContext;

        public PolicyApiController(IPolicyService policyService,
            IDbContextService dbContext)
        {
            _policyService = policyService;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Find policy by Name
        /// </summary>
        /// <remarks>Returns policy based on Name</remarks>
        /// <param name="name">name</param>
        /// <response code="200">policy response</response>
        /// <response code="0">error payload</response>
        [HttpGet]
        [Route("/v1/policy/byName")]
        [SwaggerOperation("PolicyByNameGet")]
        [ProducesResponseType(typeof(PolicyDescription), 200)]
        public virtual async Task<IActionResult> PolicyByNameGet([FromQuery]string name)
        {
            _dbContext.RefreshFullDomain();
            var res = await _policyService.GetPolicyByNameAsync(name);
            return new ObjectResult(res);
        }

        /// <summary>
        /// Create policy
        /// </summary>
        /// <remarks>Create policy</remarks>
        /// <param name="body">Policy object that needs to be added to the store</param>
        /// <response code="200">policy response</response>
        /// <response code="0">error payload</response>
        [HttpPost]
        [Route("/v1/policy/create")]
        [SwaggerOperation("PolicyCreatePost")]
        [ProducesResponseType(typeof(PolicyDescription), 200)]
        public virtual async Task<IActionResult> PolicyCreatePost([FromBody]PolicyCreateOrUpdate body)
        {
            _dbContext.RefreshFullDomain();
            var custs = await _policyService.CreatePolicyAsync(body);
            return new ObjectResult(custs);
        }

        /// <summary>
        /// Create or Update policy
        /// </summary>
        /// <remarks>Create or Update policy</remarks>
        /// <param name="body">Policy object that needs to be created or updated to the store</param>
        /// <response code="200">Policy response</response>
        /// <response code="0">error payload</response>
        [HttpPut]
        [Route("/v1/policy/update")]
        [SwaggerOperation("PolicyUpdatePut")]
        [ProducesResponseType(typeof(PolicyDescription), 200)]
        public virtual async Task<IActionResult> PolicyUpdatePut([FromBody]PolicyCreateOrUpdate body)
        {
            _dbContext.RefreshFullDomain();
            var custs = await _policyService.UpdatePolicyAsync(body);
            return new ObjectResult(custs);
        }
    }
}
