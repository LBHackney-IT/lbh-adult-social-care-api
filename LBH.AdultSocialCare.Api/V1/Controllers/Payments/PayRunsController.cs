using Common.Exceptions.Models;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

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

        [ProducesResponseType(typeof(PayRunInsightsResponse), StatusCodes.Status200OK)]
        [HttpGet("{id}/insights")]
        public async Task<ActionResult<PayRunInsightsResponse>> GetPayRunInsights([FromServices] IGetPayRunInsightsUseCase useCase, Guid id)
        {
            var res = await useCase.GetAsync(id);
            return Ok(res);
        }
    }
}
