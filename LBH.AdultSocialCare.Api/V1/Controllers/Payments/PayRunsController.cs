using LBH.AdultSocialCare.Api.V1.Boundary.PayRuns.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
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
        public PayRunsController(IGetPayRunListUseCase getPayRunListUseCase)
        {
            _getPayRunListUseCase = getPayRunListUseCase;
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
    }
}
