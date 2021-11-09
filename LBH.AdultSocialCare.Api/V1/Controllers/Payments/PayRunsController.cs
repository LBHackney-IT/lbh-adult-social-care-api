using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Common.Exceptions.Models;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

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
        public PayRunsController(IGetPayRunListUseCase getPayRunListUseCase, ICreateDraftPayRunUseCase createDraftPayRunUseCase)
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
        public async Task<ActionResult<PayRunDetailsViewResponse>> GetPayRunDetails([FromServices] IGetPayRunDetailsUseCase useCase, [FromQuery] PayRunDetailsQueryParameters parameters, Guid id)
        {
            var res = await useCase.ExecuteAsync(id, parameters);
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
        public async Task<ActionResult<PagedResponse<PayRunListResponse>>> GetPayRunList([FromQuery] PayRunListParameters parameters)
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
        public async Task<ActionResult> CreateDraftPayRun(DraftPayRunCreationRequest request)
        {
            await _createDraftPayRunUseCase.CreateDraftPayRun(request.ToDomain());
            return Ok();
        }

        /// <summary>Approve pay run.</summary>
        /// <param name="useCase">Approve pay run status use case.</param>
        /// <param name="payRunId">An unique identifier of a pay run to be approved.</param>
        /// <param name="request">The notes object for attaching status change.</param>
        /// <returns>Ok when operation is successful.</returns>
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpPost("{payRunId}/approve")]
        public async Task<ActionResult> ApprovePayRun([FromServices] IApprovePayRunUseCase useCase, Guid payRunId, PayRunChangeStatusRequest request)
        {
            await useCase.ExecuteAsync(payRunId, request.Notes);
            return Ok();
        }

        /// <summary>Archive pay run.</summary>
        /// <param name="useCase">Archive pay run status use case.</param>
        /// <param name="payRunId">An unique identifier of a pay run to be archived.</param>
        /// <param name="request">The notes object for attaching status change.</param>
        /// <returns>Ok when operation is successful.</returns>
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpPost("{payRunId}/archive")]
        public async Task<ActionResult> ArchivePayRun([FromServices] IArchivePayRunUseCase useCase, Guid payRunId, PayRunChangeStatusRequest request)
        {
            await useCase.ExecuteAsync(payRunId, request.Notes);
            return Ok();
        }

        /// <summary>Submit pay run.</summary>
        /// <param name="useCase">Submit pay run status use case.</param>
        /// <param name="payRunId">An unique identifier of a pay run to be submitted.</param>
        /// <param name="request">The notes object for attaching status change.</param>
        /// <returns>Ok when operation is successful.</returns>
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpPost("{payRunId}/submit")]
        public async Task<ActionResult> SubmitPayRun([FromServices] ISubmitPayRunUseCase useCase, Guid payRunId, PayRunChangeStatusRequest request)
        {
            await useCase.ExecuteAsync(payRunId, request.Notes);
            return Ok();
        }
    }
}
