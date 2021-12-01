using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common
{
    [Route("api/v1/care-charges")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class CareChargeController : ControllerBase
    {
        private readonly IGetCareChargePackagesUseCase _getCareChargePackagesUseCase;
        public CareChargeController(IGetCareChargePackagesUseCase getCareChargePackagesUseCase)
        {
            _getCareChargePackagesUseCase = getCareChargePackagesUseCase;
        }

        /// <summary>
        /// Gets the paginated care package list with care charge information.
        /// </summary>
        /// <param name="parameters">Parameters to filter list of care packages.</param>
        /// <returns>List of care packages with care charge status</returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<CareChargePackagesResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        // [AuthorizeRoles(RolesEnum.Broker, RolesEnum.BrokerageApprover, RolesEnum.Finance, RolesEnum.FinanceApprover, RolesEnum.CareChargeManager)]
        public async Task<ActionResult<PagedResponse<CareChargePackagesResponse>>> GetCareChargePackages([FromQuery] CareChargePackagesParameters parameters)
        {
            var result = await _getCareChargePackagesUseCase.GetCareChargePackages(parameters).ConfigureAwait(false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.PagingMetaData));
            return Ok(result);
        }
    }
}
