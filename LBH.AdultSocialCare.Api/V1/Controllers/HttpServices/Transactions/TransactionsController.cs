using HttpServices.Models.Features.RequestFeatures;
using HttpServices.Models.Requests;
using HttpServices.Models.Responses;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.UseCase.TransactionsUseCases.PayRunUseCases.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.HttpServices.Transactions
{
    [Route("api/v1/transactions")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsService _transactionsService;
        private readonly IPayRunUseCase _payRunUseCase;

        public TransactionsController(ITransactionsService transactionsService, IPayRunUseCase payRunUseCase)
        {
            _transactionsService = transactionsService;
            _payRunUseCase = payRunUseCase;
        }

        [HttpGet("departments/payment-departments")]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetPaymentDepartments()
        {
            var departments = await _transactionsService.GetPaymentDepartments().ConfigureAwait(false);
            return Ok(departments);
        }

        [HttpPost("pay-runs/{payRunType}")]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreatePayRun(string payRunType)
        {
            var result = await _payRunUseCase.CreateNewPayRunUseCase(payRunType).ConfigureAwait(false);
            return Ok(result);
        }

        [ProducesResponseType(typeof(PagedPayRunSummaryResponse), StatusCodes.Status200OK)]
        [HttpGet("pay-runs/summary-list")]
        public async Task<ActionResult<PagedPayRunSummaryResponse>> GetPayRunSummaryList([FromQuery] PayRunSummaryListParameters parameters)
        {
            var res = await _payRunUseCase.GetPayRunSummaryListUseCase(parameters).ConfigureAwait(false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(res.PagingMetaData));
            return Ok(res);
        }

        [ProducesResponseType(typeof(PagedSupplierMinimalListResponse), StatusCodes.Status200OK)]
        [HttpGet("pay-runs/{payRunId}/unique-suppliers")]
        public async Task<ActionResult<PagedSupplierMinimalListResponse>> GetUniqueSuppliersInPayRun(Guid payRunId, [FromQuery] SupplierListParameters parameters)
        {
            var res = await _transactionsService.GetUniqueSuppliersInPayRunUseCase(payRunId, parameters).ConfigureAwait(false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(res.PagingMetaData));
            return Ok(res);
        }

        [ProducesResponseType(typeof(IEnumerable<ReleasedHoldsByTypeResponse>), StatusCodes.Status200OK)]
        [HttpGet("pay-runs/released-holds-count")]
        public async Task<ActionResult<IEnumerable<ReleasedHoldsByTypeResponse>>> GetReleasedHoldsCountByType([FromQuery] DateTimeOffset? fromDate, [FromQuery] DateTimeOffset? toDate)
        {
            var res = await _payRunUseCase.GetReleasedHoldsCountUseCase(fromDate, toDate).ConfigureAwait(false);
            return Ok(res);
        }

        [ProducesResponseType(typeof(IEnumerable<PackageTypeResponse>), StatusCodes.Status200OK)]
        [HttpGet("pay-runs/{payRunId}/unique-package-types")]
        public async Task<ActionResult<IEnumerable<PackageTypeResponse>>> GetUniquePackageTypesInPayRun(Guid payRunId)
        {
            var res = await _transactionsService.GetUniquePackageTypesInPayRunUseCase(payRunId).ConfigureAwait(false);
            return Ok(res);
        }

        [ProducesResponseType(typeof(IEnumerable<InvoiceStatusResponse>), StatusCodes.Status200OK)]
        [HttpGet("pay-runs/{payRunId}/unique-payment-statuses")]
        public async Task<ActionResult<IEnumerable<InvoiceStatusResponse>>> GetUniqueInvoiceItemPaymentStatusInPayRun(Guid payRunId)
        {
            var res = await _transactionsService.GetUniquePaymentStatusesInPayRunUseCase(payRunId).ConfigureAwait(false);
            return Ok(res);
        }

        [ProducesResponseType(typeof(IEnumerable<InvoiceResponse>), StatusCodes.Status200OK)]
        [HttpGet("pay-runs/released-holds")]
        public async Task<ActionResult<IEnumerable<InvoiceResponse>>> GetReleasedHolds([FromQuery] DateTimeOffset? fromDate, [FromQuery] DateTimeOffset? toDate)
        {
            var res = await _transactionsService.GetReleasedHoldsUseCase(fromDate, toDate).ConfigureAwait(false);
            return Ok(res);
        }

        [ProducesResponseType(typeof(PayRunDetailsResponse), StatusCodes.Status200OK)]
        [HttpGet("pay-runs/{payRunId}/details")]
        public async Task<ActionResult<PayRunDetailsResponse>> GetSinglePayRunDetails(Guid payRunId, [FromQuery] InvoiceListParameters parameters)
        {
            var res = await _transactionsService.GetSinglePayRunDetailsUseCase(payRunId, parameters).ConfigureAwait(false);
            return Ok(res);
        }

        [HttpGet("pay-runs/{payRunId}/summary-insights")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> GetSinglePayRunSummaryInsights(Guid payRunId)
        {
            var result = await _transactionsService.GetSinglePayRunInsightsUseCase(payRunId).ConfigureAwait(false);
            return Ok(result);
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [HttpGet("pay-runs/{payRunId}/status/submit-for-approval")]
        public async Task<ActionResult<bool>> SubmitPayRunForApproval(Guid payRunId)
        {
            var res = await _transactionsService.SubmitPayRunForApprovalUseCase(payRunId).ConfigureAwait(false);
            return Ok(res);
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [HttpGet("pay-runs/{payRunId}/status/kick-back-to-draft")]
        public async Task<ActionResult<bool>> KickPayRunBackToDraft(Guid payRunId)
        {
            var res = await _transactionsService.KickBackPayRunToDraftUseCase(payRunId).ConfigureAwait(false);
            return Ok(res);
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [HttpGet("pay-runs/{payRunId}/status/approve-pay-run")]
        public async Task<ActionResult<bool>> ApprovePayRun(Guid payRunId)
        {
            var res = await _transactionsService.ApprovePayRunForPaymentUseCase(payRunId).ConfigureAwait(false);
            return Ok(res);
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [HttpPut("pay-runs/release-held-invoice")]
        public async Task<ActionResult<bool>> ReleaseSingleHeldInvoice([FromBody] ReleaseHeldInvoiceItemRequest releaseHeldInvoiceItemRequest)
        {
            var res = await _transactionsService
                .ReleaseHeldInvoiceItemPaymentUseCase(releaseHeldInvoiceItemRequest).ConfigureAwait(false);
            return Ok(res);
        }
    }
}
