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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace LedgerLocal.AdminServer.ApiController.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    public class TokenApiController : Controller
    {
        public TokenApiController()
        {
        }

        ///// <summary>
        ///// Returns if is new wallet
        ///// </summary>
        ///// <remarks>Return if is new wallet</remarks>
        ///// <response code="200">info response</response>
        ///// <response code="0">error payload</response>
        //[HttpGet]
        //[Route("/v1/token/issue")]
        //[SwaggerOperation("Issue")]
        //[ProducesResponseType(typeof(TokenResponse), 200)]
        //public virtual async Task<IActionResult> Issue([FromQuery]string user, [FromQuery]string pass)
        //{
        //    var disco = await DiscoveryClient.GetAsync("http://localhost:15777");

        //    var tokenClient = new TokenClient(disco.TokenEndpoint, user, pass);
        //    var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api.blockchain");

        //    return new ObjectResult(tokenResponse);
        //}

        /// <summary>
        /// List Claims
        /// </summary>
        /// <remarks>Return all claims</remarks>
        /// <response code="200">info response</response>
        /// <response code="0">error payload</response>
        [HttpGet]
        [Route("/v1/token/claimList")]
        [SwaggerOperation("ClaimListGet")]
        [ProducesResponseType(typeof(JsonResult), 200)]
        [Authorize]
        public virtual IActionResult ClaimListGet()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}
