using Common.Exceptions.Models;
using HttpServices.Models.Features.RequestFeatures;
using HttpServices.Models.Requests;
using HttpServices.Models.Responses;
using HttpServices.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using InvoiceResponse = HttpServices.Models.Responses.InvoiceResponse;

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
        private readonly IResetPackagePaidUpToDateUseCase _resetPackagePaidUpToDateUseCase;

        public TransactionsController(ITransactionsService transactionsService, IPayRunUseCase payRunUseCase, IResetPackagePaidUpToDateUseCase resetPackagePaidUpToDateUseCase)
        {
            _transactionsService = transactionsService;
            _payRunUseCase = payRunUseCase;
            _resetPackagePaidUpToDateUseCase = resetPackagePaidUpToDateUseCase;
        }

        [HttpGet("departments/payment-departments")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<DepartmentResponse>>> GetPaymentDepartments()
        {
            var departments = await _transactionsService.GetPaymentDepartments().ConfigureAwait(false);
            return Ok(departments);
        }

        [HttpPost("pay-runs/{payRunType}")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid?>> CreatePayRun(string payRunType, [FromBody] PayRunForCreationRequest payRunForCreationRequest)
        {
            var result = await _payRunUseCase.CreateNewPayRunUseCase(payRunType, payRunForCreationRequest).ConfigureAwait(false);
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
            var res = await _payRunUseCase.GetSinglePayRunDetailsUseCase(payRunId, parameters).ConfigureAwait(false);
            return Ok(res);
        }

        [ProducesResponseType(typeof(PayRunInsightsResponse), StatusCodes.Status200OK)]
        [HttpGet("pay-runs/{payRunId}/summary-insights")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PayRunInsightsResponse>> GetSinglePayRunSummaryInsights(Guid payRunId)
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

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [HttpPut("pay-runs/release-held-invoice-list")]
        public async Task<ActionResult<bool>> ReleaseHeldInvoiceItemPayment([FromBody] IEnumerable<ReleaseHeldInvoiceItemRequest> releaseHeldInvoiceItemRequests)
        {
            var res = await _transactionsService
                .ReleaseHeldInvoiceItemPaymentListUseCase(releaseHeldInvoiceItemRequests).ConfigureAwait(false);
            return Ok(res);
        }

        // Delete Pay Run
        [HttpDelete("pay-runs/{payRunId}")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> DeleteDraftPayRun(Guid payRunId)
        {
            var result = await _transactionsService.DeleteDraftPayRunUseCase(payRunId).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPost("pay-runs/{payRunId}/invoices/{invoiceId}/hold-payment")]
        [ProducesResponseType(typeof(DisputedInvoiceFlatResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<DisputedInvoiceFlatResponse>> HoldInvoicePayment(Guid payRunId, Guid invoiceId, [FromBody] DisputedInvoiceForCreationRequest disputedInvoiceForCreationRequest)
        {
            var result = await _transactionsService
                .HoldInvoicePaymentUseCase(payRunId, invoiceId, disputedInvoiceForCreationRequest)
                .ConfigureAwait(false);
            return Ok(result);
        }

        [ProducesResponseType(typeof(PagedHeldInvoiceResponse), StatusCodes.Status200OK)]
        [HttpGet("invoices/held-invoice-payments")]
        public async Task<ActionResult<PagedHeldInvoiceResponse>> GetHeldInvoicePaymentsList([FromQuery] HeldInvoicePaymentParameters parameters)
        {
            var res = await _payRunUseCase.GetHeldInvoicePaymentsUseCase(parameters).ConfigureAwait(false);
            return Ok(res);
        }

        [HttpPost("invoices")]
        [ProducesResponseType(typeof(IEnumerable<InvoiceResponse>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<InvoiceResponse>>> CreateInvoice([FromBody] InvoiceForCreationRequest invoiceForCreationRequest)
        {
            var result = await _transactionsService.CreateInvoiceUseCase(invoiceForCreationRequest).ConfigureAwait(false);
            return Ok(result);
        }

        [ProducesResponseType(typeof(IEnumerable<InvoiceStatusResponse>), StatusCodes.Status200OK)]
        [HttpGet("invoices/invoice-status-list")]
        public async Task<ActionResult<IEnumerable<InvoiceStatusResponse>>> GetAllInvoiceStatusesList()
        {
            var res = await _transactionsService.GetAllInvoiceStatusesUseCase().ConfigureAwait(false);
            return Ok(res);
        }

        [ProducesResponseType(typeof(IEnumerable<InvoiceStatusResponse>), StatusCodes.Status200OK)]
        [HttpGet("invoices/invoice-payment-statuses")]
        public async Task<ActionResult<IEnumerable<InvoiceStatusResponse>>> GetInvoicePaymentStatusesList()
        {
            var res = await _transactionsService.GetInvoicePaymentStatusesUseCase().ConfigureAwait(false);
            return Ok(res);
        }

        // Accept invoice in pay run
        [HttpPut("pay-runs/{payRunId}/invoices/{invoiceId}/accept-invoice")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> ApproveInvoice(Guid payRunId, Guid invoiceId)
        {
            var result = await _transactionsService.AcceptInvoiceUseCase(payRunId, invoiceId).ConfigureAwait(false);
            return Ok(result);
        }

        // Reject invoice in pay run
        [HttpPut("pay-runs/{payRunId}/invoices/{invoiceId}/status/reject-invoice")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> RejectInvoiceInPayRun(Guid payRunId, Guid invoiceId)
        {
            var result = await _transactionsService.RejectInvoiceUseCase(payRunId, invoiceId).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPost("supplier-bills")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BillResponse>> CreateSupplierBill([FromBody] BillCreationRequest billCreationRequest)
        {
            var result = await _transactionsService.CreateSupplierBillUseCase(billCreationRequest).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPost("supplier-bills/pay")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> PaySupplierBill([FromBody] IEnumerable<long> supplierBillIds)
        {
            var result = await _transactionsService.PaySupplierBillUseCase(supplierBillIds).ConfigureAwait(false);
            return Ok(result);
        }

        [ProducesResponseType(typeof(PagedBillSummaryResponse), StatusCodes.Status200OK)]
        [HttpGet("supplier-bills")]
        public async Task<ActionResult<PagedBillSummaryResponse>> GetBillSummaryList([FromQuery] BillSummaryListParameters parameters)
        {
            var res = await _transactionsService.GetBillSummaryList(parameters).ConfigureAwait(false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(res.PagingMetaData));
            return Ok(res);
        }

        [ProducesResponseType(typeof(PagedSupplierResponse), StatusCodes.Status200OK)]
        [HttpGet("suppliers")]
        public async Task<ActionResult<PagedSupplierResponse>> GetSupplierList([FromQuery] SupplierListParameters parameters)
        {
            var res = await _transactionsService.GetSuppliersListUseCase(parameters).ConfigureAwait(false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(res.PagingMetaData));
            return Ok(res);
        }

        [ProducesResponseType(typeof(PagedSupplierResponse), StatusCodes.Status200OK)]
        [HttpGet("suppliers/{supplierId}/tax-rates")]
        public async Task<ActionResult<IEnumerable<SupplierTaxRateResponse>>> GetSupplierTaxRate(long supplierId)
        {
            var result = await _transactionsService.GetSupplierTaxRateUseCase(supplierId).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet("pay-runs/date-of-last-pay-run/{payRunType}")]
        [ProducesResponseType(typeof(PayRunDateSummaryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PayRunDateSummaryResponse>> GetDateSummaryOfLastPayRun(string payRunType)
        {
            var result = await _transactionsService.GetDateOfLastPayRun(payRunType).ConfigureAwait(false);
            return Ok(result);
        }

        // Mark list of invoices in pay run as accepted
        [HttpPut("pay-runs/{payRunId}/invoices/accept-invoices")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> ApproveInvoice(Guid payRunId, [FromBody] InvoiceIdListRequest invoiceIdList)
        {
            var result = await _transactionsService.AcceptInvoicesUseCase(payRunId, invoiceIdList).ConfigureAwait(false);
            return Ok(result);
        }

        // Create disputed invoice chat
        [HttpPost("pay-runs/{payRunId}/invoices/{invoiceId}/create-held-chat")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<DisputedInvoiceChatResponse>> CreateDisputedInvoiceChat(Guid payRunId, Guid invoiceId, [FromBody] DisputedInvoiceChatForCreationRequest disputedInvoiceChatForCreationRequest)
        {
            var result = await _transactionsService.CreatePayRunHeldChatUseCase(payRunId, invoiceId, disputedInvoiceChatForCreationRequest).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet("pay-runs/pay-run-types")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<PayRunTypeResponse>>> GetAllPayRunTypes()
        {
            var types = await _transactionsService.GetAllPayRunTypesUseCase().ConfigureAwait(false);
            return Ok(types);
        }

        [HttpGet("pay-runs/pay-run-sub-types")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<PayRunSubTypeResponse>>> GetAllPayRunSubTypes()
        {
            var subTypes = await _transactionsService.GetAllPayRunSubTypesUseCase().ConfigureAwait(false);
            return Ok(subTypes);
        }

        [HttpGet("pay-runs/unique-pay-run-statuses")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<PayRunStatusResponse>>> GetAllUniquePayRunStatuses()
        {
            var result = await _transactionsService.GetAllUniquePayRunStatusesUseCase().ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPost("pay-runs/invoice-date-reset")]
        [ProducesDefaultResponseType]
        [AllowAnonymous]
        public async Task<ActionResult<GenericSuccessResponse>> ResetPackagePaidUpToDate([FromBody] List<InvoiceForResetDomain> invoiceForResetDomains)
        {
            var result = await _resetPackagePaidUpToDateUseCase.ExecuteAsync(invoiceForResetDomains).ConfigureAwait(false);
            return Ok(new GenericSuccessResponse
            {
                IsSuccess = result,
                Message = "Success"
            });
        }
    }
}
