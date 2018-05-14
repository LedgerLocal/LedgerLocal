using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.SwaggerGen.Annotations;
using Microsoft.AspNetCore.Authorization;
using LedgerLocal.Service.ChainService;
using LedgerLocal.Dto.Chain;
using Microsoft.AspNetCore.Cors;
using LedgerLocal.Service.GrapheneLogic;

namespace LedgerLocal.AdminServer.ApiController.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [EnableCors("SiteCorsPolicy")]
    public class AccountApiController : Controller
    {

        private readonly IAccountService _accountService;

        public AccountApiController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        
        /// <summary>
        /// List account
        /// </summary>
        /// <remarks>Returns list of accounts</remarks>
        /// <param name="lowerBound">id of item to skip</param>
        /// <param name="limit">max records to return</param>
        /// <response code="200">account response</response>
        /// <response code="0">error payload</response>
        [HttpGet]
        [Route("/v1/account/list")]
        [SwaggerOperation("AccountListGet")]
        [ProducesResponseType(typeof(List<AccountProfile>), 200)]
        [Authorize(Roles = "account,account:list")]
        public virtual async Task<IActionResult> AccountListGet([FromQuery]string lowerBound, [FromQuery]int? limit)
        {
            var lstCust = await _accountService.ListAccount(lowerBound, limit.HasValue ? limit.Value : 100);
            return new ObjectResult(lstCust);
        }

        /// <summary>
        /// Get balances from account
        /// </summary>
        /// <remarks>Returns balances</remarks>
        /// <param name="accountId">Account Id</param>
        /// <response code="200">account response</response>
        /// <response code="0">error payload</response>
        [HttpGet]
        [Route("/v1/account/balanceList")]
        [SwaggerOperation("AccountBalanceListGet")]
        [ProducesResponseType(typeof(List<AmountDescriptionSimple>), 200)]
        [Authorize(Roles = "account,account:balancelist")]
        public virtual async Task<IActionResult> AccountBalanceListGet([FromQuery]string accountId)
        {
            var lstBalances = await _accountService.ListBalance(accountId);
            return new ObjectResult(lstBalances);
        }

        /// <summary>
        /// Get history from account
        /// </summary>
        /// <remarks>Returns balances</remarks>
        /// <param name="accountId">Account Id</param>
        /// <param name="limit">limit</param>
        /// <response code="200">account response</response>
        /// <response code="0">error payload</response>
        [HttpGet]
        [Route("/v1/account/historyList")]
        [SwaggerOperation("AccountHistoryListGet")]
        [ProducesResponseType(typeof(List<GrapheneOpContainer>), 200)]
        [Authorize(Roles = "account,account:historylist")]
        public virtual async Task<IActionResult> AccountHistoryListGet([FromQuery]string accountId, [FromQuery]uint start, [FromQuery]uint stop, [FromQuery]uint limit)
        {
            var lstBalances = await _accountService.ListHistory(accountId, start, stop, limit);
            return new ObjectResult(lstBalances);
        }

        /// <summary>
        /// Create transfer
        /// </summary>
        /// <remarks>Create transfer</remarks>
        /// <param name="body">Transfer object that needs to be added to the store</param>
        /// <response code="200">info response</response>
        /// <response code="0">error payload</response>
        [HttpPost]
        [Route("/v1/account/transfer")]
        [SwaggerOperation("PostTransfer")]
        [ProducesResponseType(typeof(Dictionary<string, TransactionRecordDescription>), 200)]
        [Authorize(Roles = "account,account:transfer")]
        public virtual async Task<IActionResult> PostTransfer([FromBody]TransferCreateOrUpdate body)
        {
            var res = await _accountService.Transfer(body.From, body.To, body.Amount, body.AssetSymbol, body.Memo, body.Broadcast);
            return new ObjectResult(res);
        }
        
    }
}
