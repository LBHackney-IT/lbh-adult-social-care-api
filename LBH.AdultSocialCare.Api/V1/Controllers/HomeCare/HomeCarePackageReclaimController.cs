using LBH.AdultSocialCare.Api.V1.Factories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;
using LBH.AdultSocialCare.Api.V1.Controllers.Common;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.Controllers.HomeCare
{
    [Route("api/v1/home-care-packages/{homeCarePackageId}/package-reclaim")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class HomeCarePackageReclaimController : BaseController
    {
        private readonly ICreateHomeCarePackageReclaimUseCase _createHomeCarePackageReclaimUseCase;

        public HomeCarePackageReclaimController(ICreateHomeCarePackageReclaimUseCase createHomeCarePackageReclaimUseCase)
        {
            _createHomeCarePackageReclaimUseCase = createHomeCarePackageReclaimUseCase;
        }

        [ProducesResponseType(typeof(HomeCarePackageClaimResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public async Task<ActionResult<HomeCarePackageClaimResponse>> CreateHomeCarePackageClaim(
            HomeCarePackageClaimCreationRequest homeCarePackageClaimCreationRequest)
        {
            if (homeCarePackageClaimCreationRequest == null)
            {
                return BadRequest("Object for creation cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var homeCarePackageClaimForCreationDomain = homeCarePackageClaimCreationRequest.ToDomain();
            var homeCarePackageClaimResponse =
                await _createHomeCarePackageReclaimUseCase.ExecuteAsync(homeCarePackageClaimForCreationDomain).ConfigureAwait(false);
            return Ok(homeCarePackageClaimResponse);
        }
    }
}
