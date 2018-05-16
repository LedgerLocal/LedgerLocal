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
using LedgerLocal.AdminServer.Service.Contract;
using LedgerLocal.AdminServer.Service.BusinessImplService.Contract;
using LedgerLocal.Blockchain.Service.LycServiceContract;
using LedgerLocal.AdminServer.Api.Web.Models;

namespace LedgerLocal.AdminServer.ApiController.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [EnableCors("SiteCorsPolicy")]
    public class ParticipateBusinessApiController : Controller
    { 
        private readonly IBlockTradeService _blockTradeService;
        private readonly ICommonMessageService _commonMessageService;

        public ParticipateBusinessApiController(IBlockTradeService blockTradeService, ICommonMessageService commonMessageService)
        {
        }

        [HttpGet]
        [Route("/v1/participate/cryptoPaymentAvailable")]
        [SwaggerOperation("CryptoPaymentAvailableGet")]
        [ProducesResponseType(typeof(List<string>), 200)]
        public virtual async Task<IActionResult> CryptoPaymentAvailableGet()
        {
            var guidString = Guid.NewGuid().ToString();

            var lstWallets = await _blockTradeService.GetActiveWalletType();

            return new ObjectResult(lstWallets);
        }

        [HttpGet]
        [Route("/v1/participate/initiateTrade")]
        [SwaggerOperation("InitiateTradeGet")]
        [ProducesResponseType(typeof(List<string>), 200)]
        public virtual async Task<IActionResult> InitiateTradeGet([FromQuery] string inputCoin, [FromQuery] string destinationCoin, [FromQuery] string address, [FromQuery] string memo)
        {
            var guidString = Guid.NewGuid().ToString();

            var lstWallets = await _blockTradeService.InitiateTrade(inputCoin, destinationCoin, address, memo);

            return new ObjectResult(lstWallets);
        }
    }
}
