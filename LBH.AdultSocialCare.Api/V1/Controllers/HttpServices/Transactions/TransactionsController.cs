using HttpServices.Services.Contracts;
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

        public TransactionsController(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        [HttpGet("departments/payment-departments")]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetPaymentDepartments()
        {
            var departments = await _transactionsService.GetPaymentDepartments().ConfigureAwait(false);
            return Ok(departments);
        }
    }
}
