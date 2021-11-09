using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Payments
{
    [Route("api/v1/payruns")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class PayRunStatusController : ControllerBase
    {
        /// <summary>
        /// Holds a pay run invoice.
        /// </summary>
        /// <param name="useCase">Hold invoice use case.</param>
        /// <param name="heldInvoiceCreationRequest">Held invoice creation request</param>
        /// <param name="id">Pay run id</param>
        /// <param name="invoiceId">Pay run invoice id</param>
        /// <returns>Held invoice object</returns>
        [ProducesResponseType(typeof(HeldInvoiceFlatResponse), StatusCodes.Status200OK)]
        [HttpPost("{id}/invoices/{invoiceId}/hold")]
        public async Task<ActionResult<HeldInvoiceFlatResponse>> HoldInvoice([FromServices] IHoldInvoiceUseCase useCase, [FromBody] HeldInvoiceCreationRequest heldInvoiceCreationRequest, Guid id, Guid invoiceId)
        {
            var res = await useCase.ExecuteAsync(id, invoiceId, heldInvoiceCreationRequest.ToDomain());
            return Ok(res);
        }
    }
}
