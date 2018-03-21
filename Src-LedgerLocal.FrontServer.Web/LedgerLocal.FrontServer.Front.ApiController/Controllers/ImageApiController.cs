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

    public class ImageApiController : Controller
    {

        private readonly IGenericCrudService<ImageDto, Image> _genService;
        private readonly IDbContextService _dbContext;

        public ImageApiController(
                IGenericCrudService<ImageDto, Image> genService,
                IDbContextService dbContext)
        {
            _genService = genService;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("/v1/Image/byId")]
        [SwaggerOperation("ContentByIdGet")]
        [ProducesResponseType(typeof(ImageDto), 200)]
        public virtual async Task<IActionResult> ImageByIdGet([FromQuery]string ImageId)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _genService.GetSingleByPredicateAsync((x => {
                return x.Imageid.ToString() == ImageId;
            }));
            return new ObjectResult(workflowById);
        }

        [HttpGet]
        [Route("/v1/Image/list")]
        [SwaggerOperation("ImageListGet")]
        [ProducesResponseType(typeof(List<ImageDto>), 200)]
        public virtual async Task<IActionResult> ImageListGet([FromQuery]int skip = 0, [FromQuery]int take = 100)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _genService.GetAllAsync();
            return new ObjectResult(workflowById.Skip(skip).Take(take));
        }

        [HttpPost]
        [Route("/v1/Image/create")]
        [SwaggerOperation("ImageCreatePost")]
        [ProducesResponseType(typeof(ImageDto), 200)]
        public virtual async Task<IActionResult> ImageCreatePost([FromBody]ImageDto body)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _genService.CreateAsync(body, (x => { return x.Imageid == body.Imageid; }));
            return new ObjectResult(workflowById);
        }

        [HttpPost]
        [Route("/v1/Image/update")]
        [SwaggerOperation("ImageUpdatePost")]
        [ProducesResponseType(typeof(ImageDto), 200)]
        public virtual async Task<IActionResult> ImageUpdatePost([FromBody]ImageDto body)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _genService.UpdateAsync(body, (x => { return x.Imageid == body.Imageid; }));
            return new ObjectResult(workflowById);
        }

        [HttpDelete]
        [Route("/v1/Image/delete")]
        [SwaggerOperation("ImageDelete")]
        [ProducesResponseType(typeof(bool), 200)]
        public virtual async Task<IActionResult> ImageDelete([FromBody]ImageDto body)
        {
            _dbContext.RefreshFullDomain();
            await _genService.DeleteAsync(body, (x => { return x.Imageid == body.Imageid; }));
            return new ObjectResult(true);
        }

    }
}
