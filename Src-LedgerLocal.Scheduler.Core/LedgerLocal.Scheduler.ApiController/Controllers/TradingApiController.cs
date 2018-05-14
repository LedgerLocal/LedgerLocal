using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.SwaggerGen.Annotations;
using Microsoft.AspNetCore.Authorization;
using LedgerLocal.Service.ChainService;
using LedgerLocal.Dto.Chain;
using LedgerLocal.Service.GrapheneLogic;
using Microsoft.AspNetCore.Cors;

namespace LedgerLocal.AdminServer.ApiController.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [EnableCors("SiteCorsPolicy")]
    public class TradingApiController : Controller
    {

        private IAssetService _assetService;
        private ILimitOrderService _limitOrderService;

        public TradingApiController(IAssetService assetService, ILimitOrderService limitOrderService)
        {
            _assetService = assetService;
            _limitOrderService = limitOrderService;
        }
        
        /// <summary>
        /// Borrow Asset
        /// </summary>
        /// <remarks>Borrow asset</remarks>
        /// <param name="body">BorrowAsset object that needs to be added to the store</param>
        /// <response code="200">info response</response>
        /// <response code="0">error payload</response>
        [HttpPost]
        [Route("/v1/trading/borrowAsset")]
        [SwaggerOperation("PostBorrowAsset")]
        [ProducesResponseType(typeof(TransactionAssetCreatorDescription), 200)]
        [Authorize(Roles = "trading,trading:borrowasset")]
        public virtual async Task<IActionResult> PostBorrowAsset([FromBody]BorrowAssetCreateOrUpdate body)
        {
            var res = await _assetService.BorrowAsset(body.BorrowerName, body.AmountToBorrow, body.AssetSymbol, body.AmountOfCollateral, body.Broadcast);
            return new ObjectResult(res);
        }
        
        /// <summary>
        /// Get limit orders
        /// </summary>
        /// <remarks>Get limit orders</remarks>
        /// <param name="baseSymbol">baseSymbol</param>
        /// <param name="quoteSymbol">quoteSymbol</param>
        /// <param name="limit">limit</param>
        /// <response code="200">account response</response>
        /// <response code="0">error payload</response>
        [HttpGet]
        [Route("/v1/trading/getLimitOrders")]
        [SwaggerOperation("GetLimitOrders")]
        [ProducesResponseType(typeof(GrapheneOrder[]), 200)]
        [Authorize(Roles = "trading,trading:getlimitorders")]
        public virtual async Task<IActionResult> GetLimitOrder([FromQuery]string baseSymbol, [FromQuery]string quoteSymbol, [FromQuery]int limit)
        {
            var go = await _limitOrderService.GetLimitOrderHistory(baseSymbol, quoteSymbol, limit);
            return new ObjectResult(go);
        }
        
        /// <summary>
        /// Create Limit Order
        /// </summary>
        /// <remarks>Create Limit Order</remarks>
        /// <param name="account">account</param>
        /// <param name="sellAmount">sellAmount</param>
        /// <param name="sellAsset">sellAsset</param>
        /// <param name="buyAmount">buyAmount</param>
        /// <param name="buyAsset">buyAsset</param>
        /// <param name="expiration">expiration</param>
        /// <param name="isFillOrKill">isFillOrKill</param>
        /// <param name="feeAssetId">feeAssetId</param>
        /// <param name="feeAssetSymbol">feeAssetSymbol</param>
        /// <param name="broadcast">broadcast</param>
        /// <response code="200">account response</response>
        /// <response code="0">error payload</response>
        [HttpGet]
        [Route("/v1/trading/createLimitOrder")]
        [SwaggerOperation("GetCreateLimitOrder")]
        [ProducesResponseType(typeof(TransactionLimitOrderDescription), 200)]
        [Authorize(Roles = "trading,trading:createlimitorder")]
        public virtual async Task<IActionResult> GetCreateLimitOrder([FromQuery]string account, [FromQuery]decimal sellAmount, [FromQuery]string sellAsset,
            [FromQuery]decimal buyAmount, [FromQuery]string buyAsset, [FromQuery]string expiration,
            [FromQuery]bool isFillOrKill, [FromQuery]string feeAssetId, [FromQuery]string feeAssetSymbol, [FromQuery]string guidLabel, [FromQuery]bool broadcast)
        {
            var res = await _limitOrderService.CreateLimitOrder(account, sellAmount, sellAsset,
            buyAmount, buyAsset, expiration,
            isFillOrKill, feeAssetId, feeAssetSymbol, guidLabel, broadcast);
            return new ObjectResult(res);
        }

        /// <summary>
        /// Exchange
        /// </summary>
        /// <remarks>Create Exchange</remarks>
        /// <param name="account">account</param>
        /// <param name="sellAmount">sellAmount</param>
        /// <param name="sellAsset">sellAsset</param>
        /// <param name="buyAmount">buyAmount</param>
        /// <param name="buyAsset">buyAsset</param>
        /// <param name="expiration">expiration</param>
        /// <param name="isFillOrKill">isFillOrKill</param>
        /// <param name="feeAssetId">feeAssetId</param>
        /// <param name="feeAssetSymbol">feeAssetSymbol</param>
        /// <param name="guidLabel">guidLabel</param>
        /// <response code="200">account response</response>
        /// <response code="0">error payload</response>
        [HttpGet]
        [Route("/v1/trading/createExchange")]
        [SwaggerOperation("GetCreateExchange")]
        [ProducesResponseType(typeof(ExchangeLimitOrderDescription), 200)]
        [Authorize(Roles = "trading,trading:createexchange")]
        public virtual async Task<IActionResult> GetCreateExchange([FromQuery]string account, [FromQuery]decimal sellAmount, [FromQuery]string sellAsset,
            [FromQuery]decimal buyAmount, [FromQuery]string buyAsset, [FromQuery]string expiration,
            [FromQuery]bool isFillOrKill, [FromQuery]string feeAssetId, [FromQuery]string feeAssetSymbol, [FromQuery]string guidLabel)
        {
            var res = await _limitOrderService.CreateExchange(account, sellAmount, sellAsset,
            buyAmount, buyAsset, expiration,
            false, feeAssetId, feeAssetSymbol, guidLabel, 30000);
            return new ObjectResult(res);
        }

    }
}
