using LBH.AdultSocialCare.Api.V1.Factories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Controllers.Common;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.Controllers.NursingCare
{
    [Route("api/v1/nursing-care-packages/{nursingCarePackageId}/package-reclaim")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class NursingCarePackageReclaimController : BaseController
    {
        private readonly ICreateNursingCarePackageReclaimUseCase _createNursingCarePackageReclaimUseCase;

        public NursingCarePackageReclaimController(ICreateNursingCarePackageReclaimUseCase createNursingCarePackageReclaimUseCase)
        {
            _createNursingCarePackageReclaimUseCase = createNursingCarePackageReclaimUseCase;
        }

        [ProducesResponseType(typeof(NursingCarePackageClaimResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public async Task<ActionResult<NursingCarePackageClaimResponse>> CreateNursingCarePackageReclaim(
            NursingCarePackageClaimCreationRequest nursingCarePackageClaimCreationRequest)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var nursingCarePackageClaimForCreationDomain = nursingCarePackageClaimCreationRequest.ToDomain();
            var nursingCarePackageClaimResponse =
                await _createNursingCarePackageReclaimUseCase.ExecuteAsync(nursingCarePackageClaimForCreationDomain).ConfigureAwait(false);
            return Ok(nursingCarePackageClaimResponse);
        }
    }
}
