using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;
using Microsoft.AspNetCore.Cors;
using LedgerLocal.AdminServer.Service.BusinessImplService.Contract;
using LedgerLocal.Blockchain.Service.LycServiceContract;
using IO.Swagger.Models;

namespace LedgerLocal.AdminServer.ApiController.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [EnableCors("SiteCorsPolicy")]
    public class ParticipateBusinessApiController : Controller
    { 
        private readonly IParticipateBusinessService _participateBusinessService;
        private readonly ICommonMessageService _commonMessageService;

        public ParticipateBusinessApiController(IParticipateBusinessService participateBusinessService, ICommonMessageService commonMessageService)
        {
            _participateBusinessService = participateBusinessService;
            _commonMessageService = commonMessageService;
        }

        [HttpGet]
        [Route("/v1/participate/cryptoPaymentAvailable")]
        [SwaggerOperation("CryptoPaymentAvailableGet")]
        [ProducesResponseType(typeof(List<string>), 200)]
        public virtual async Task<IActionResult> CryptoPaymentAvailableGet()
        {
            var guidString = Guid.NewGuid().ToString();

            var lstWallets = await _participateBusinessService.ListPaymentCrypto();

            return new ObjectResult(lstWallets);
        }

        [HttpGet]
        [Route("/v1/participate/initiateTrade")]
        [SwaggerOperation("InitiateTradeGet")]
        [ProducesResponseType(typeof(SimpleTradeInfo), 200)]
        public virtual async Task<IActionResult> InitiateTradeGet([FromQuery] string inputCoin, [FromQuery] decimal? amount)
        {
            var guidString = Guid.NewGuid().ToString();

            var lstWallets = await _participateBusinessService.InitiateTrade(inputCoin, amount);

            return new ObjectResult(lstWallets);
        }

        [HttpGet]
        [Route("/v1/participate/calculateOutputInBts")]
        [SwaggerOperation("CalculateOutputInBTS")]
        [ProducesResponseType(typeof(OutputEstimateInfo), 200)]
        public virtual async Task<IActionResult> CalculateOutputInBTS([FromQuery] string inputCoin, [FromQuery] decimal amount)
        {
            var guidString = Guid.NewGuid().ToString();

            var lstWallets = await _participateBusinessService.CalculateOutputBitshares2(inputCoin, amount);

            return new ObjectResult(lstWallets);
        }
    }
}
