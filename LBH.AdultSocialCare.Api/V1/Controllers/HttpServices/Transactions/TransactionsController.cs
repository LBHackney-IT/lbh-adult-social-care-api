using HttpServices.Models.Features.RequestFeatures;
using HttpServices.Models.Responses;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.UseCase.TransactionsUseCases.PayRunUseCases.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
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
    }
}
