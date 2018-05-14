using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;
using LedgerLocal.AdminServer.Service.Contract;
using LedgerLocal.AdminServer.Dto;
using LedgerLocal.AdminServer.Data.FullDomain;
using LedgerLocal.AdminServer.Service.BusinessImplService.Contract;
using Microsoft.AspNetCore.Cors;

namespace LedgerLocal.AdminServer.ApiController.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [EnableCors("SiteCorsPolicy")]
    public class CultureApiController : Controller
    {

        private readonly IGenericCrudService<CultureDto, Culture> _genService;
        private readonly IDbContextService _dbContext;

        public CultureApiController(
                IGenericCrudService<CultureDto, Culture> genService,
                IDbContextService dbContext)
        {
            _genService = genService;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("/v1/Culture/byId")]
        [SwaggerOperation("ContentByIdGet")]
        [ProducesResponseType(typeof(CultureDto), 200)]
        public virtual async Task<IActionResult> CultureByIdGet([FromQuery]string CultureId)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _genService.GetSingleByPredicateAsync((x => {
                return x.Cultureid.ToString() == CultureId;
            }));
            return new ObjectResult(workflowById);
        }

        [HttpGet]
        [Route("/v1/Culture/list")]
        [SwaggerOperation("CultureListGet")]
        [ProducesResponseType(typeof(List<CultureDto>), 200)]
        public virtual async Task<IActionResult> CultureListGet([FromQuery]int skip = 0, [FromQuery]int take = 100)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _genService.GetAllAsync();
            return new ObjectResult(workflowById.Skip(skip).Take(take));
        }

        [HttpPost]
        [Route("/v1/Culture/create")]
        [SwaggerOperation("CultureCreatePost")]
        [ProducesResponseType(typeof(CultureDto), 200)]
        public virtual async Task<IActionResult> CultureCreatePost([FromBody]CultureDto body)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _genService.CreateAsync(body, (x => { return x.Cultureid == body.Cultureid; }));
            return new ObjectResult(workflowById);
        }

        [HttpPost]
        [Route("/v1/Culture/update")]
        [SwaggerOperation("CultureUpdatePost")]
        [ProducesResponseType(typeof(CultureDto), 200)]
        public virtual async Task<IActionResult> CultureUpdatePost([FromBody]CultureDto body)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _genService.UpdateAsync(body, (x => { return x.Cultureid == body.Cultureid; }));
            return new ObjectResult(workflowById);
        }

        [HttpDelete]
        [Route("/v1/Culture/delete")]
        [SwaggerOperation("CultureDelete")]
        [ProducesResponseType(typeof(bool), 200)]
        public virtual async Task<IActionResult> CultureDelete([FromBody]CultureDto body)
        {
            _dbContext.RefreshFullDomain();
            await _genService.DeleteAsync(body, (x => { return x.Cultureid == body.Cultureid; }));
            return new ObjectResult(true);
        }

    }
}
