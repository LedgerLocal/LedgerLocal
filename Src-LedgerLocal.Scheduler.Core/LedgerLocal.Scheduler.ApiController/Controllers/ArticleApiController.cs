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
    public class ArticleApiController : Controller
    {

        private readonly IGenericCrudService<ArticleDto, Article> _genService;
        private readonly IDbContextService _dbContext;

        public ArticleApiController(
                IGenericCrudService<ArticleDto, Article> genService,
                IDbContextService dbContext)
        {
            _genService = genService;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("/v1/article/byId")]
        [SwaggerOperation("ArticleByIdGet")]
        [ProducesResponseType(typeof(ArticleDto), 200)]
        public virtual async Task<IActionResult> ArticleByIdGet([FromQuery]string articleId)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _genService.GetSingleByPredicateAsync((x => {
                return x.Articleid.ToString() == articleId;
            }));
            return new ObjectResult(workflowById);
        }

        [HttpGet]
        [Route("/v1/article/list")]
        [SwaggerOperation("ArticleListGet")]
        [ProducesResponseType(typeof(List<ArticleDto>), 200)]
        public virtual async Task<IActionResult> ArticleListGet([FromQuery]int skip = 0, [FromQuery]int take = 100)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _genService.GetAllAsync();
            return new ObjectResult(workflowById.Skip(skip).Take(take));
        }

        [HttpPost]
        [Route("/v1/article/create")]
        [SwaggerOperation("ArticleCreatePost")]
        [ProducesResponseType(typeof(ArticleDto), 200)]
        public virtual async Task<IActionResult> ArticleCreatePost([FromBody]ArticleDto body)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _genService.CreateAsync(body, (x => { return x.Articleid == body.Articleid; }));
            return new ObjectResult(workflowById);
        }
        
        [HttpPost]
        [Route("/v1/article/update")]
        [SwaggerOperation("ArticleUpdatePost")]
        [ProducesResponseType(typeof(ArticleDto), 200)]
        public virtual async Task<IActionResult> ArticleUpdatePost([FromBody]ArticleDto body)
        {
            _dbContext.RefreshFullDomain();
            var workflowById = await _genService.UpdateAsync(body, (x => { return x.Articleid == body.Articleid; }));
            return new ObjectResult(workflowById);
        }

        [HttpDelete]
        [Route("/v1/article/delete")]
        [SwaggerOperation("ArticleDelete")]
        [ProducesResponseType(typeof(bool), 200)]
        public virtual async Task<IActionResult> ArticleDelete([FromBody]ArticleDto body)
        {
            _dbContext.RefreshFullDomain();
            await _genService.DeleteAsync(body, (x => { return x.Articleid == body.Articleid; }));
            return new ObjectResult(true);
        }
        
    }
}
