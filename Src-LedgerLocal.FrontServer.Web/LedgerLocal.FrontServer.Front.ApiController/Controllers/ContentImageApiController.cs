using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;
using LedgerLocal.FrontServer.Service.Contract;
using LedgerLocal.FrontServer.Dto;
using LedgerLocal.FrontServer.Data.FullDomain;
using LedgerLocal.FrontServer.Service.BusinessImplService.Contract;

namespace LedgerLocal.FrontServer.Api.Web.Controllers
{

    public class ContentImageApiController : Controller
    {

        private readonly IGenericCrudService<ContentBlockImageMapDto, Contentblockimagemap> _genService;
        private readonly IDbContextService _dbContext;

        public ContentImageApiController(
                IGenericCrudService<ContentBlockImageMapDto, Contentblockimagemap> genService,
                IDbContextService dbContext)
        {
            _genService = genService;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("/v1/Contentblockimagemap/byId")]
        [SwaggerOperation("ContentByIdGet")]
        [ProducesResponseType(typeof(ContentBlockImageMapDto), 200)]
        public virtual async Task<IActionResult> ContentblockByIdGet([FromQuery]string Contentblockimagemap)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _genService.GetSingleByPredicateAsync((x => {
                return x.Contentblockimagemapid.ToString() == Contentblockimagemap;
            }));
            return new ObjectResult(workflowById);
        }

        [HttpGet]
        [Route("/v1/Contentblockimagemap/list")]
        [SwaggerOperation("ContentblockListGet")]
        [ProducesResponseType(typeof(List<ContentBlockImageMapDto>), 200)]
        public virtual async Task<IActionResult> ContentblockListGet([FromQuery]int skip = 0, [FromQuery]int take = 100)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _genService.GetAllAsync();
            return new ObjectResult(workflowById.Skip(skip).Take(take));
        }

        [HttpPost]
        [Route("/v1/Contentblockimagemap/create")]
        [SwaggerOperation("ContentblockCreatePost")]
        [ProducesResponseType(typeof(ContentBlockImageMapDto), 200)]
        public virtual async Task<IActionResult> ContentblockCreatePost([FromBody]ContentBlockImageMapDto body)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _genService.CreateAsync(body, (x => { return x.Contentblockimagemapid == body.Contentblockimagemapid; }));
            return new ObjectResult(workflowById);
        }

        [HttpPost]
        [Route("/v1/Contentblockimagemap/update")]
        [SwaggerOperation("ContentblockUpdatePost")]
        [ProducesResponseType(typeof(ContentBlockImageMapDto), 200)]
        public virtual async Task<IActionResult> ContentblockUpdatePost([FromBody]ContentBlockImageMapDto body)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _genService.UpdateAsync(body, (x => { return x.Contentblockimagemapid == body.Contentblockimagemapid; }));
            return new ObjectResult(workflowById);
        }

        [HttpDelete]
        [Route("/v1/Contentblockimagemap/delete")]
        [SwaggerOperation("ContentblockDelete")]
        [ProducesResponseType(typeof(bool), 200)]
        public virtual async Task<IActionResult> ContentblockDelete([FromBody]ContentBlockImageMapDto body)
        {
            _dbContext.RefreshFullDomain();
            await _genService.DeleteAsync(body, (x => { return x.Contentblockimagemapid == body.Contentblockimagemapid; }));
            return new ObjectResult(true);
        }

    }
}
