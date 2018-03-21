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

    public class PageApiController : Controller
    {

        private readonly IGenericCrudService<PageDto, Page> _genService;
        private readonly IDbContextService _dbContext;

        public PageApiController(
                IGenericCrudService<PageDto, Page> genService,
                IDbContextService dbContext)
        {
            _genService = genService;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("/v1/Page/byId")]
        [SwaggerOperation("ContentByIdGet")]
        [ProducesResponseType(typeof(PageDto), 200)]
        public virtual async Task<IActionResult> PageByIdGet([FromQuery]string PageId)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _genService.GetSingleByPredicateAsync((x => {
                return x.Pageid.ToString() == PageId;
            }));
            return new ObjectResult(workflowById);
        }

        [HttpGet]
        [Route("/v1/Page/list")]
        [SwaggerOperation("PageListGet")]
        [ProducesResponseType(typeof(List<PageDto>), 200)]
        public virtual async Task<IActionResult> PageListGet([FromQuery]int skip = 0, [FromQuery]int take = 100)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _genService.GetAllAsync();
            return new ObjectResult(workflowById.Skip(skip).Take(take));
        }

        [HttpPost]
        [Route("/v1/Page/create")]
        [SwaggerOperation("PageCreatePost")]
        [ProducesResponseType(typeof(PageDto), 200)]
        public virtual async Task<IActionResult> PageCreatePost([FromBody]PageDto body)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _genService.CreateAsync(body, (x => { return x.Pageid == body.Pageid; }));
            return new ObjectResult(workflowById);
        }

        [HttpPost]
        [Route("/v1/Page/update")]
        [SwaggerOperation("PageUpdatePost")]
        [ProducesResponseType(typeof(PageDto), 200)]
        public virtual async Task<IActionResult> PageUpdatePost([FromBody]PageDto body)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _genService.UpdateAsync(body, (x => { return x.Pageid == body.Pageid; }));
            return new ObjectResult(workflowById);
        }

        [HttpDelete]
        [Route("/v1/Page/delete")]
        [SwaggerOperation("PageDelete")]
        [ProducesResponseType(typeof(bool), 200)]
        public virtual async Task<IActionResult> PageDelete([FromBody]PageDto body)
        {
            _dbContext.RefreshFullDomain();
            await _genService.DeleteAsync(body, (x => { return x.Pageid == body.Pageid; }));
            return new ObjectResult(true);
        }

    }
}
