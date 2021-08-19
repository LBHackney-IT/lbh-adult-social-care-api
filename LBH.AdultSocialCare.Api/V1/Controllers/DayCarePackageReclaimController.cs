using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageReclaimUseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/day-care-packages/{dayCarePackageId}/package-reclaim")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class DayCarePackageReclaimController : BaseController
    {
        private readonly ICreateDayCarePackageReclaimUseCase _createDayCarePackageReclaimUseCase;

        public DayCarePackageReclaimController(ICreateDayCarePackageReclaimUseCase createDayCarePackageReclaimUseCase)
        {
            _createDayCarePackageReclaimUseCase = createDayCarePackageReclaimUseCase;
        }

        [ProducesResponseType(typeof(DayCarePackageClaimResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public async Task<ActionResult<DayCarePackageClaimResponse>> CreateDayCarePackageReclaim(
            DayCarePackageClaimCreationRequest dayCarePackageClaimCreationRequest)
        {
            if (dayCarePackageClaimCreationRequest == null)
            {
                return BadRequest("Object for creation cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var dayCarePackageClaimForCreationDomain = dayCarePackageClaimCreationRequest.ToDomain();
            var dayCarePackageClaimResponse =
                await _createDayCarePackageReclaimUseCase.ExecuteAsync(dayCarePackageClaimForCreationDomain).ConfigureAwait(false);
            return Ok(dayCarePackageClaimResponse);
        }
    }
}
