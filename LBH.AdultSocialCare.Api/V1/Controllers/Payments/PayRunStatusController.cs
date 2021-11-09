using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Common.Exceptions.Models;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;

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
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [HttpPost("{id}/invoices/{invoiceId}/hold")]
        public async Task<ActionResult<HeldInvoiceFlatResponse>> HoldInvoice([FromServices] IHoldInvoiceUseCase useCase, [FromBody] HeldInvoiceCreationRequest heldInvoiceCreationRequest, Guid id, Guid invoiceId)
        {
            var res = await useCase.ExecuteAsync(id, invoiceId, heldInvoiceCreationRequest.ToDomain());
            return Ok(res);
        }

        /// <summary>
        /// Changes the pay run invoice status.
        /// </summary>
        /// <param name="useCase">Change pay run invoice status use case.</param>
        /// <param name="id">Pay run id.</param>
        /// <param name="invoiceId">Pay run invoice id.</param>
        /// <param name="newStatus">The new status to be set.</param>
        /// <returns>True if success</returns>
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [HttpPut("{id}/invoices/{invoiceId}/status/{newStatus}")]
        public async Task<ActionResult<bool>> ChangePayRunInvoiceStatus([FromServices] IChangePayRunInvoiceStatusUseCase useCase, Guid id, Guid invoiceId, InvoiceStatus newStatus)
        {
            var res = await useCase.ExecuteAsync(id, invoiceId, newStatus);
            return Ok(res);
        }

        /// <summary>Approve pay run.</summary>
        /// <param name="useCase">Approve pay run status use case.</param>
        /// <param name="id">An unique identifier of a pay run to be approved.</param>
        /// <param name="request">The notes object for attaching status change.</param>
        /// <returns>Ok when operation is successful.</returns>
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpPost("{id}/approve")]
        public async Task<ActionResult> ApprovePayRun([FromServices] IApprovePayRunUseCase useCase, Guid id, PayRunChangeStatusRequest request)
        {
            await useCase.ExecuteAsync(id, request.Notes);
            return Ok();
        }

        /// <summary>Archive pay run.</summary>
        /// <param name="useCase">Archive pay run status use case.</param>
        /// <param name="id">An unique identifier of a pay run to be archived.</param>
        /// <param name="request">The notes object for attaching status change.</param>
        /// <returns>Ok when operation is successful.</returns>
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpPost("{id}/archive")]
        public async Task<ActionResult> ArchivePayRun([FromServices] IArchivePayRunUseCase useCase, Guid id, PayRunChangeStatusRequest request)
        {
            await useCase.ExecuteAsync(id, request.Notes);
            return Ok();
        }

        /// <summary>Submit pay run.</summary>
        /// <param name="useCase">Submit pay run status use case.</param>
        /// <param name="id">An unique identifier of a pay run to be submitted.</param>
        /// <param name="request">The notes object for attaching status change.</param>
        /// <returns>Ok when operation is successful.</returns>
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpPost("{id}/submit")]
        public async Task<ActionResult> SubmitPayRun([FromServices] ISubmitPayRunUseCase useCase, Guid id, PayRunChangeStatusRequest request)
        {
            await useCase.ExecuteAsync(id, request.Notes);
            return Ok();
        }
    }
}
