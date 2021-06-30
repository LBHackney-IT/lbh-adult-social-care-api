using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.UseCase.TransactionsUseCases.PayRunUseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
    }
}
