using Common.Exceptions.Models;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Payments
{
    [Route("api/v1/payruns")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class PayRunsController : ControllerBase
    {
        private readonly IGetPayRunListUseCase _getPayRunListUseCase;
        private readonly ICreateDraftPayRunUseCase _createDraftPayRunUseCase;

        public PayRunsController(IGetPayRunListUseCase getPayRunListUseCase,
            ICreateDraftPayRunUseCase createDraftPayRunUseCase)
        {
            _getPayRunListUseCase = getPayRunListUseCase;
            _createDraftPayRunUseCase = createDraftPayRunUseCase;
        }

        /// <summary>
        /// Gets single pay run details.
        /// </summary>
        /// <param name="useCase">Use case to get details.</param>
        /// <param name="parameters">Parameters to filter data.</param>
        /// <param name="id">Pay run Id.</param>
        /// <returns>Pay run and paginated list of invoices in the pay run</returns>
        [ProducesResponseType(typeof(PayRunDetailsViewResponse), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        // [AuthorizeRoles(RolesEnum.Finance, RolesEnum.FinanceApprover)]
        public async Task<ActionResult<PayRunDetailsViewResponse>> GetPayRunDetails(
            [FromServices] IGetPayRunDetailsUseCase useCase, [FromQuery] PayRunDetailsQueryParameters parameters,
            Guid id)
        {
            var res = await useCase.ExecuteAsync(id, parameters);
            return Ok(res);
        }

        /// <summary>
        /// Gets list of held invoices.
        /// </summary>
        /// <param name="useCase">Use case to get held invoices.</param>
        /// <param name="parameters">Parameters to filter invoice list.</param>
        /// <returns>List of held invoices if success</returns>
        [ProducesResponseType(typeof(PagedResponse<HeldInvoiceDetailsResponse>), StatusCodes.Status200OK)]
        [HttpGet("held-invoices")]
        // [AuthorizeRoles(RolesEnum.Finance, RolesEnum.FinanceApprover)]
        public async Task<ActionResult<PagedResponse<HeldInvoiceDetailsResponse>>> GetHeldInvoices(
            [FromServices] IGetHeldInvoicesUseCase useCase, [FromQuery] PayRunDetailsQueryParameters parameters)
        {
            var res = await useCase.ExecuteAsync(parameters);
            return Ok(res);
        }

        /// <summary>
        /// Gets the paginated pay run list information.
        /// </summary>
        /// <param name="parameters">Parameters to filter list of pay run.</param>
        /// <returns>List of pay runs with status</returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<PayRunListResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        // [AuthorizeRoles(RolesEnum.Finance, RolesEnum.FinanceApprover)]
        public async Task<ActionResult<PagedResponse<PayRunListResponse>>> GetPayRunList(
            [FromQuery] PayRunListParameters parameters)
        {
            var result = await _getPayRunListUseCase.GetPayRunList(parameters).ConfigureAwait(false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.PagingMetaData));
            return Ok(result);
        }

        /// <summary>Create a new pay run with draft status.</summary>
        /// <param name="request">The pay run creation request object.</param>
        /// <returns>Ok when operation is successful.</returns>
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpPost]
        // [AuthorizeRoles(RolesEnum.Finance)]
        public async Task<ActionResult> CreateDraftPayRun(DraftPayRunCreationRequest request)
        {
            await _createDraftPayRunUseCase.CreateDraftPayRun(request.ToDomain());
            return Ok();
        }

        /// <summary>
        /// Gets single pay run insights.
        /// </summary>
        /// <param name="useCase">Use case to get insights.</param>
        /// <param name="id">Pay run id.</param>
        /// <returns>Insights response object if successful</returns>
        [ProducesResponseType(typeof(PayRunInsightsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [HttpGet("{id}/insights")]
        // [AuthorizeRoles(RolesEnum.Finance, RolesEnum.FinanceApprover)]
        public async Task<ActionResult<PayRunInsightsResponse>> GetPayRunInsights(
            [FromServices] IGetPayRunInsightsUseCase useCase, Guid id)
        {
            var res = await useCase.GetAsync(id);
            return Ok(res);
        }

        /// <summary>
        /// Gets released invoice count.
        /// </summary>
        /// <param name="useCase">Use case to fetch released invoice count.</param>
        /// <returns>Total number or released invoices if success</returns>
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [HttpGet("released-invoice-count")]
        // [AuthorizeRoles(RolesEnum.Finance)]
        public async Task<ActionResult<int>> GetReleasedInvoiceCount(
            [FromServices] IGetReleasedInvoiceCountUseCase useCase)
        {
            var res = await useCase.GetAsync();
            return Ok(res);
        }

        /// <summary>
        /// Gets previous pay run end date.
        /// </summary>
        /// <param name="useCase">Use case to get previous pay run end date.</param>
        /// <param name="type">Pay run type.</param>
        /// <returns>End date of last pay run if success</returns>
        [ProducesResponseType(typeof(DateTimeOffset), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpGet("{type}/previous-pay-run-end-date")]
        // [AuthorizeRoles(RolesEnum.Finance)]
        public async Task<ActionResult<DateTimeOffset>> GetPreviousPayRunEndDate(
            [FromServices] IGetEndDateOfLastPayRunUseCase useCase, PayrunType type)
        {
            var res = await useCase.GetAsync(type);
            return Ok(res);
        }

        /// <summary>
        /// Gets details of a single invoice in pay run.
        /// </summary>
        /// <param name="useCase">Use case to get single pay run invoice details.</param>
        /// <param name="payRunId">Pay run Id.</param>
        /// <param name="invoiceId">Invoice Id</param>
        /// <returns>Details of a single invoice in pay run if success</returns>
        [ProducesResponseType(typeof(PayRunInvoiceDetailViewResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [HttpGet("{payRunId:guid}/invoices/{invoiceId:guid}")]
        // [AuthorizeRoles(RolesEnum.Finance, RolesEnum.FinanceApprover)]
        public async Task<ActionResult<PayRunInvoiceDetailViewResponse>> GetPayRunInvoiceDetails(
            [FromServices] IGetPayRunInvoiceUseCase useCase, Guid payRunId, Guid invoiceId)
        {
            var res = await useCase.GetDetailsAsync(payRunId, invoiceId);
            return Ok(res);
        }

        /// <summary>
        /// Gets Cedar file for single pay run.
        /// </summary>
        /// <param name="payRunId">Pay run Id.</param>
        /// <returns>Cedar file of single pay run</returns>
        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [HttpGet("{payRunId}/download")]
        public async Task<ActionResult> DownloadCedarFile(Guid payRunId)
        {
            await Task.Yield();
            var list = new List<PayRunInsightsResponse>()
            {
                new PayRunInsightsResponse() { PayRunId = payRunId, TotalHeldAmount = 100M},
                new PayRunInsightsResponse() { PayRunId = payRunId, TotalHeldAmount = 200M},
            };
            var stream = new MemoryStream();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(list, true);
                package.Save();
            }
            stream.Position = 0;
            string excelName = $"{payRunId} Cedar File.xlsx";

            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }
    }
}
