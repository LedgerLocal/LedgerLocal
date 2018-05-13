using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;
using LedgerLocal.FrontServer.Service.Contract;
using LedgerLocal.FrontServer.Dto;
using LedgerLocal.FrontServer.Data.FullDomain;
using LedgerLocal.FrontServer.Service.BusinessImplService.Contract;
using Microsoft.EntityFrameworkCore;

namespace LedgerLocal.FrontServer.ApiController.Controllers
{

    public class ContentApiController : Controller
    {

        private readonly IGenericCrudService<ContentblockDto, Contentblock> _genService;
        private readonly IDbContextService _dbContext;

        public ContentApiController(
                IGenericCrudService<ContentblockDto, Contentblock> genService,
                IDbContextService dbContext)
        {
            _genService = genService;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("/v1/Contentblock/byId")]
        [SwaggerOperation("ContentByIdGet")]
        [ProducesResponseType(typeof(ContentblockDto), 200)]
        public virtual async Task<IActionResult> ContentblockByIdGet([FromQuery]string ContentblockId)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _genService.GetSingleByPredicateAsync((x => {
                return x.Contentblockid.ToString() == ContentblockId;
            }), d =>
            {
                return d.Include("Contentblockimagemap")
                .Include("Contentblockimagemap.Image");
            });
            return new ObjectResult(workflowById);
        }

        [HttpGet]
        [Route("/v1/Contentblock/list")]
        [SwaggerOperation("ContentblockListGet")]
        [ProducesResponseType(typeof(List<ContentblockDto>), 200)]
        public virtual async Task<IActionResult> ContentblockListGet([FromQuery]int skip = 0, [FromQuery]int take = 100)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _genService.GetAllAsync(x => {
                return x.Include("Contentblockimagemap")
                .Include("Contentblockimagemap.Image");
            });
            return new ObjectResult(workflowById.Skip(skip).Take(take));
        }

        [HttpPost]
        [Route("/v1/Contentblock/create")]
        [SwaggerOperation("ContentblockCreatePost")]
        [ProducesResponseType(typeof(ContentblockDto), 200)]
        public virtual async Task<IActionResult> ContentblockCreatePost([FromBody]ContentblockDto body)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _genService.CreateAsync(body, (x => { return x.Contentblockid == body.Contentblockid; }));
            return new ObjectResult(workflowById);
        }

        [HttpPost]
        [Route("/v1/Contentblock/update")]
        [SwaggerOperation("ContentblockUpdatePost")]
        [ProducesResponseType(typeof(ContentblockDto), 200)]
        public virtual async Task<IActionResult> ContentblockUpdatePost([FromBody]ContentblockDto body)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _genService.UpdateAsync(body, (x => { return x.Contentblockid == body.Contentblockid; }));
            return new ObjectResult(workflowById);
        }

        [HttpDelete]
        [Route("/v1/Contentblock/delete")]
        [SwaggerOperation("ContentblockDelete")]
        [ProducesResponseType(typeof(bool), 200)]
        public virtual async Task<IActionResult> ContentblockDelete([FromBody]ContentblockDto body)
        {
            _dbContext.RefreshFullDomain();
            await _genService.DeleteAsync(body, (x => { return x.Contentblockid == body.Contentblockid; }));
            return new ObjectResult(true);
        }

    }
}
