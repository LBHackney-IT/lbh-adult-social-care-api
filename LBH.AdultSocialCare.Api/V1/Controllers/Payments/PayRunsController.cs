using LBH.AdultSocialCare.Api.V1.Boundary.PayRuns.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Common.Exceptions.Models;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.PayRuns.Request;
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
    }
}
