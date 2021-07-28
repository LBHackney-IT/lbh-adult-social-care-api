using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.SubmittedPackageRequestsBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;
using LBH.AdultSocialCare.Api.V1.UseCase.SubmittedPackageRequestsUseCases.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/submitted-package-requests")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class SubmittedPackageRequestsController : ControllerBase
    {
        private readonly IGetSubmittedPackageRequestsUseCase _getSubmittedPackageRequestsUseCase;
        private readonly IGetAllPackageStatusUseCase _getAllPackageStatusUseCase;

        public SubmittedPackageRequestsController(IGetSubmittedPackageRequestsUseCase getSubmittedPackageRequestsUseCase,
            IGetAllPackageStatusUseCase getAllPackageStatusUseCase)
        {
            _getSubmittedPackageRequestsUseCase = getSubmittedPackageRequestsUseCase;
            _getAllPackageStatusUseCase = getAllPackageStatusUseCase;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedSubmittedPackageRequestsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagedSubmittedPackageRequestsResponse>> GetSubmittedPackageRequests([FromQuery] SubmittedPackageRequestParameters parameters)
        {
            var result = await _getSubmittedPackageRequestsUseCase.GetSubmittedPackageRequests(parameters).ConfigureAwait(false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.PagingMetaData));
            return Ok(result);
        }

        [ProducesResponseType(typeof(IEnumerable<StatusResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("status")]
        public async Task<ActionResult<IEnumerable<StatusResponse>>> GetSupplierList()
        {
            var result = await _getAllPackageStatusUseCase.GetAllAsync().ConfigureAwait(false);
            return Ok(result);
        }
    }
}
