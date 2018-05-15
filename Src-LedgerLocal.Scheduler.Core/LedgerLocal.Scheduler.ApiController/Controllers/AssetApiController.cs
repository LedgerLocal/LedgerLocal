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
using LedgerLocal.Service.ChainService;
using LedgerLocal.Dto.Chain;
using Microsoft.AspNetCore.Cors;

namespace LedgerLocal.AdminServer.ApiController.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [EnableCors("SiteCorsPolicy")]
    public class AssetApiController : Controller
    {

        private IAssetService _assetService;

        public AssetApiController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        /// <summary>
        /// list assets
        /// </summary>
        /// <remarks>Returns list of asset</remarks>
        /// <param name="lowerbound">lowerbound</param>
        /// <param name="limit">max records to return</param>
        /// <response code="200">asset response</response>
        /// <response code="0">error payload</response>
        [HttpGet]
        [Route("/v1/asset/list")]
        [SwaggerOperation("AssetListGet")]
        [ProducesResponseType(typeof(List<AssetDescription>), 200)]
        public virtual async Task<IActionResult> AssetListGet([FromQuery]string lowerbound, [FromQuery]int? limit)
        {
            var res = await _assetService.ListAsset(lowerbound, limit.HasValue ? limit.Value : 100);
            return new ObjectResult(res);
        }

        /// <summary>
        /// Create UI Asset
        /// </summary>
        /// <remarks>create UI asset</remarks>
        /// <param name="body">CreateUIAsset object that needs to be added to the store</param>
        /// <response code="200">info response</response>
        /// <response code="0">error payload</response>
        [HttpGet]
        [Route("/v1/asset/createUiAsset")]
        [SwaggerOperation("GetCreateUiAsset")]
        [ProducesResponseType(typeof(TransactionAssetCreatorDescription), 200)]
        public virtual async Task<IActionResult> GetCreateUiAsset([FromQuery]string issuer, [FromQuery]string symbol, [FromQuery]uint precision,
            [FromQuery]ulong maxSupply, [FromQuery]decimal marketFeePercent, [FromQuery]ulong maxMarketFee,
            [FromQuery]ulong amountBase, [FromQuery]ulong amountQuote, [FromQuery]string description)
        {
            var res = await _assetService.CreateUiAsset(issuer, symbol, precision, maxSupply, marketFeePercent, maxMarketFee, amountBase, amountQuote, description);
            return new ObjectResult(res);
        }
        
        /// <summary>
        /// Create Asset
        /// </summary>
        /// <remarks>Settle asset</remarks>
        /// <param name="body">CreateAsset object that needs to be added to the store</param>
        /// <response code="200">info response</response>
        /// <response code="0">error payload</response>
        [HttpPost]
        [Route("/v1/asset/createAsset")]
        [SwaggerOperation("PostCreateAsset")]
        [ProducesResponseType(typeof(TransactionAssetCreatorDescription), 200)]
        public virtual async Task<IActionResult> PostCreateAsset([FromBody]CreateAssetCreateOrUpdate body)
        {
            var res = await _assetService.CreateAsset(body.Issuer, body.Symbol, body.Precision, body.AssetOption, body.BitassetOption, body.Broadcast);
            return new ObjectResult(res);
        }

        /// <summary>
        /// Update Asset
        /// </summary>
        /// <remarks>Update asset</remarks>
        /// <param name="body">UpdateAsset object that needs to be added to the store</param>
        /// <response code="200">info response</response>
        /// <response code="0">error payload</response>
        [HttpPost]
        [Route("/v1/asset/updateAsset")]
        [SwaggerOperation("PostUpdateAsset")]
        [ProducesResponseType(typeof(TransactionRecordDescription), 200)]
        public virtual async Task<IActionResult> PostUpdateAsset([FromBody]UpdateAssetCreateOrUpdate body)
        {
            await Task.Factory.StartNew(() => { return 0; });

            return new ObjectResult(new TransactionRecordDescription());
        }

        /// <summary>
        /// Update bitasset
        /// </summary>
        /// <remarks>Update bitasset</remarks>
        /// <param name="body">UpdateBitasset object that needs to be added to the store</param>
        /// <response code="200">info response</response>
        /// <response code="0">error payload</response>
        [HttpPost]
        [Route("/v1/asset/updateBitasset")]
        [SwaggerOperation("PostUpdateBitasset")]
        [ProducesResponseType(typeof(TransactionRecordDescription), 200)]
        public virtual async Task<IActionResult> PostUpdateBitasset([FromBody]UpdateBitassetCreateOrUpdate body)
        {
            await Task.Factory.StartNew(() => { return 0; });

            return new ObjectResult(new TransactionRecordDescription());
        }

        /// <summary>
        /// Update bitasset
        /// </summary>
        /// <remarks>Update bitasset</remarks>
        /// <param name="body">UpdateAssetFeedProducer object that needs to be added to the store</param>
        /// <response code="200">info response</response>
        /// <response code="0">error payload</response>
        [HttpPost]
        [Route("/v1/asset/updateAssetFeedProducer")]
        [SwaggerOperation("PostUpdateAssetFeedProducer")]
        [ProducesResponseType(typeof(TransactionRecordDescription), 200)]
        public virtual async Task<IActionResult> PostUpdateAssetFeedProducer([FromBody]UpdateAssetFeedProducerCreateOrUpdate body)
        {
            await Task.Factory.StartNew(() => { return 0; });

            return new ObjectResult(new TransactionRecordDescription());
        }

        /// <summary>
        /// Update bitasset
        /// </summary>
        /// <remarks>Update bitasset</remarks>
        /// <param name="body">PostPublishAssetFeed object that needs to be added to the store</param>
        /// <response code="200">info response</response>
        /// <response code="0">error payload</response>
        [HttpPost]
        [Route("/v1/asset/publishAssetFeed")]
        [SwaggerOperation("PostPublishAssetFeed")]
        [ProducesResponseType(typeof(TransactionAssetCreatorDescription), 200)]
        public virtual async Task<IActionResult> PostPublishAssetFeed([FromBody]PublishAssetFeedCreateOrUpdate body)
        {
            var res = await _assetService.PublishAssetFeed(body.PublishingAccount, body.Symbol, body.Feed, body.Broadcast);
            return new ObjectResult(res);
        }

        /// <summary>
        /// Issue asset
        /// </summary>
        /// <remarks>Issue asset</remarks>
        /// <param name="body">IssueAsset object that needs to be added to the store</param>
        /// <response code="200">info response</response>
        /// <response code="0">error payload</response>
        [HttpPost]
        [Route("/v1/asset/issueAsset")]
        [SwaggerOperation("PostIssueAsset")]
        [ProducesResponseType(typeof(TransactionAssetCreatorDescription), 200)]
        public virtual async Task<IActionResult> PostIssueAsset([FromBody]IssueAssetCreateOrUpdate body)
        {
            var res = await _assetService.IssueAsset(body.ToAccount, body.Amount, body.Symbol, body.Memo, body.Broadcast);
            return new ObjectResult(res);
        }

        /// <summary>
        /// get asset
        /// </summary>
        /// <remarks>Returns asset</remarks>
        /// <param name="assetNameOrId">assetNameOrId</param>
        /// <response code="200">asset response</response>
        /// <response code="0">error payload</response>
        [HttpGet]
        [Route("/v1/asset/byId")]
        [SwaggerOperation("AssetGetById")]
        [ProducesResponseType(typeof(AssetDescription), 200)]
        public virtual async Task<IActionResult> AssetGetById([FromQuery]string assetNameOrId)
        {
            var res = await _assetService.GetAssetById(assetNameOrId);
            return new ObjectResult(res);
        }

        /// <summary>
        /// get bitasset data
        /// </summary>
        /// <remarks>Returns asset</remarks>
        /// <param name="assetNameOrId">assetNameOrId</param>
        /// <response code="200">asset response</response>
        /// <response code="0">error payload</response>
        [HttpGet]
        [Route("/v1/asset/bitassetById")]
        [SwaggerOperation("BitassetDataGetById")]
        [ProducesResponseType(typeof(BitassetDataDescription), 200)]
        public virtual async Task<IActionResult> BitassetDataGetById([FromQuery]string assetNameOrId)
        {
            var res = await _assetService.GetBitassetById(assetNameOrId);
            return new ObjectResult(res);
        }

        /// <summary>
        /// Fund asset fee pool
        /// </summary>
        /// <remarks>Fund asset fee pool</remarks>
        /// <param name="body">FundAssetFeePool object that needs to be added to the store</param>
        /// <response code="200">info response</response>
        /// <response code="0">error payload</response>
        [HttpPost]
        [Route("/v1/asset/fundAssetFeePool")]
        [SwaggerOperation("PostFundAssetFeePool")]
        [ProducesResponseType(typeof(TransactionDescription), 200)]
        public virtual async Task<IActionResult> PostFundAssetFeePool([FromBody]FundAssetFeePoolCreateOrUpdate body)
        {
            await Task.Factory.StartNew(() => { return 0; });

            return new ObjectResult(new TransactionDescription());
        }

        /// <summary>
        /// Reserve Asset
        /// </summary>
        /// <remarks>Reserve Asset</remarks>
        /// <param name="body">ReverseAsset object that needs to be added to the store</param>
        /// <response code="200">info response</response>
        /// <response code="0">error payload</response>
        [HttpPost]
        [Route("/v1/asset/reserveAsset")]
        [SwaggerOperation("PostReverseAsset")]
        [ProducesResponseType(typeof(TransactionDescription), 200)]
        public virtual async Task<IActionResult> PostReverseAsset([FromBody]ReverseAssetCreateOrUpdate body)
        {
            await Task.Factory.StartNew(() => { return 0; });

            return new ObjectResult(new TransactionDescription());
        }

        /// <summary>
        /// Global Settle Asset
        /// </summary>
        /// <remarks>Fund asset fee pool</remarks>
        /// <param name="body">GlobalSettleAsset object that needs to be added to the store</param>
        /// <response code="200">info response</response>
        /// <response code="0">error payload</response>
        [HttpPost]
        [Route("/v1/asset/globalSettleAsset")]
        [SwaggerOperation("PostGlobalSettleAsset")]
        [ProducesResponseType(typeof(TransactionDescription), 200)]
        public virtual async Task<IActionResult> PostGlobalSettleAsset([FromBody]GlobalSettleAssetCreateOrUpdate body)
        {
            await Task.Factory.StartNew(() => { return 0; });

            return new ObjectResult(new TransactionDescription());
        }

    }
}
