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
using LedgerLocal.FrontServer.Service.WorkflowContract;
using LedgerLocal.FrontServer.WebApi.ActionResult;
using LedgerLocal.FrontServer.Service;
using System.Text;
using LedgerLocal.FrontServer.Service.Contract;

namespace LedgerLocal.FrontServer.Api.Web.Controllers
{ 

    public class WorkflowApiController : Controller
    {
        private readonly IWorkflowRunnerService _workflowRunnerService;
        private readonly IWorkflowService _workflowService;
        private readonly IDbContextService _dbContext;

        public WorkflowApiController(IWorkflowRunnerService workflowRunnerService,
                IWorkflowService workflowService,
                IDbContextService dbContext)
        {
            _workflowRunnerService = workflowRunnerService;
            _workflowService = workflowService;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Find workflow by ID
        /// </summary>
        /// <remarks>Returns workflow based on ID</remarks>
        /// <param name="workflowId">number for the workflow</param>
        /// <response code="200">workflow response</response>
        /// <response code="0">error payload</response>
        [HttpGet]
        [Route("/v1/workflow/byId")]
        [SwaggerOperation("WorkflowByIdGet")]
        [ProducesResponseType(typeof(WorkflowDescription), 200)]
        public virtual async Task<IActionResult> WorkflowByIdGet([FromQuery]string workflowId)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _workflowService.GetWorkflowByIdAsync(workflowId);
            return new ObjectResult(workflowById);
        }


        /// <summary>
        /// Create workflow
        /// </summary>
        /// <remarks>Create workflow</remarks>
        /// <param name="body">Workflow object that needs to be added to the store</param>
        /// <response code="200">workflow response</response>
        /// <response code="0">error payload</response>
        [HttpPost]
        [Route("/v1/workflow/create")]
        [SwaggerOperation("WorkflowCreatePost")]
        [ProducesResponseType(typeof(WorkflowDescription), 200)]
        public virtual async Task<IActionResult> WorkflowCreatePost([FromBody]WorkflowCreateOrUpdate body)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _workflowService.CreateWorkflowAsync(body);
            return new ObjectResult(workflowById);
        }
        
        /// <summary>
        /// Execute workflow
        /// </summary>
        /// <remarks>Execute workflow</remarks>
        /// <param name="body">WorkflowExecutionWithArgs to execute</param>
        /// <response code="200">workflow response</response>
        /// <response code="0">error payload</response>
        [HttpPost]
        [Route("/v1/workflow/execute")]
        [SwaggerOperation("WorkflowExecuteWithArgsPost")]
        [ProducesResponseType(typeof(object), 200)]
        public virtual async Task<IActionResult> WorkflowExecuteWithArgsPost([FromBody]WorkflowExecutionWithArgs body)
        {
            _dbContext.RefreshFullDomain();
            return Content((await _workflowRunnerService.ExecuteWorkflow(body)).ToString());
        }

        /// <summary>
        /// Execute workflow
        /// </summary>
        /// <remarks>Execute workflow</remarks>
        /// <param name="body">WorkflowExecutionWithArgs to execute</param>
        /// <response code="200">workflow response</response>
        /// <response code="0">error payload</response>
        [HttpPost]
        [Route("/v1/workflow/executeText")]
        [SwaggerOperation("WorkflowExecuteContentPost")]
        [ProducesResponseType(typeof(object), 200)]
        public virtual async Task<IActionResult> WorkflowExecuteContentPost()
        {
            _dbContext.RefreshFullDomain();
            string body = string.Empty;

            using (var sr = new StreamReader(Request.Body))
            {
                body = await sr.ReadToEndAsync();
            }

            var c = (await _workflowRunnerService.ExecuteWorkflow(new WorkflowExecutionWithArgs()
            {
                LedgerLocalJsContent = body,
                Timeout = 1000 * 60 * 30
            }));

            if (c == null || !c.Item1)
            {
                return c != null && c.Item2 != null ? new ErrorContentResult(c.ToString()) : new ErrorContentResult(string.Empty);
            }

            return c != null && c.Item2 != null ? (IActionResult)Content(c.Item2.ToString()) : (IActionResult)NoContent();
        }

        /// <summary>
        /// Execute workflow
        /// </summary>
        /// <remarks>Execute workflow by id</remarks>
        /// <param name="workflowId">number for the workflow</param>
        /// <param name="body">WorkflowExecutionWithArgs to execute</param>
        /// <response code="200">workflow response</response>
        /// <response code="0">error payload</response>
        [HttpGet]
        [Route("/v1/workflow/executeStored/byId")]
        [SwaggerOperation("WorkflowExecuteStoredByIdPost")]
        [ProducesResponseType(typeof(object), 200)]
        public virtual async Task<IActionResult> WorkflowExecuteStoredByIdPost([FromQuery] string workflowId)
        {
            _dbContext.RefreshFullDomain();
            var wf = await _workflowService.GetWorkflowByIdAsync(workflowId);

            var c = (await _workflowRunnerService.ExecuteWorkflow(new WorkflowExecutionWithArgs()
            {
                DicoArgs = wf.Arguments,
                LedgerLocalJsContent = Encoding.UTF8.GetString(Convert.FromBase64String(wf.Body)),
                Timeout = 1000 * 60 * 30
            }));

            if (c == null || !c.Item1)
            {
                return c != null && c.Item2 != null ? new ErrorContentResult(c.ToString()) : new ErrorContentResult(string.Empty);
            }

            return c != null && c.Item2 != null ? (IActionResult)Content(c.Item2.ToString()) : (IActionResult)NoContent();
        }

        /// <summary>
        /// Find workflow by where clause, and filter
        /// </summary>
        /// <remarks>Returns list of workflow</remarks>
        /// <param name="skip">number of items to skip</param>
        /// <param name="limit">max records to return</param>
        /// <param name="where">Where clause</param>
        /// <response code="200">workflow response</response>
        /// <response code="0">error payload</response>
        [HttpGet]
        [Route("/v1/workflow/list")]
        [SwaggerOperation("WorkflowListGet")]
        [ProducesResponseType(typeof(List<WorkflowDescription>), 200)]
        public virtual async Task<IActionResult> WorkflowListGet([FromQuery]int? skip, [FromQuery]int? limit, [FromQuery]string where)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _workflowService.GetAllWorkflowAsync();
            return new ObjectResult(workflowById);
        }


        /// <summary>
        /// Create or Update workflow
        /// </summary>
        /// <remarks>Create or Update workflow</remarks>
        /// <param name="body">Workflow object that needs to be created or updated to the store</param>
        /// <response code="200">Workflow response</response>
        /// <response code="0">error payload</response>
        [HttpPut]
        [Route("/v1/workflow/update")]
        [SwaggerOperation("WorkflowUpdatePut")]
        [ProducesResponseType(typeof(WorkflowDescription), 200)]
        public virtual async Task<IActionResult> WorkflowUpdatePut([FromBody]WorkflowCreateOrUpdate body)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _workflowService.UpdateWorkflowAsync(body);
            return new ObjectResult(workflowById);
        }

    }
}
