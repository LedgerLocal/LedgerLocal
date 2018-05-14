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
using LoyaltyCoin.AdminServer.Api.Web.Models;

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
            _blockTradeService = blockTradeService;
            _commonMessageService = commonMessageService;
        }

        [HttpGet]
        [Route("/v1/participate/cryptoPaymentAvailable")]
        [SwaggerOperation("CryptoPaymentAvailableGet")]
        [ProducesResponseType(typeof(List<string>), 200)]
        public virtual async Task<IActionResult> CryptoPaymentAvailableGet()
        {
            var guidString = Guid.NewGuid().ToString();

            var lstWallets = await _blockTradeService.GetActiveWalletType();

            await _commonMessageService.SendMessage<ActionEventDefinition>("llc-event-broadcast", guidString, new ActionEventDefinition()
            {
                ActionName = "ListPaymentCryptoAvailable",
                Message = string.Concat("Returning crypto: ", lstWallets.Count)
            });

            return new ObjectResult(lstWallets);
        }
    }
}
