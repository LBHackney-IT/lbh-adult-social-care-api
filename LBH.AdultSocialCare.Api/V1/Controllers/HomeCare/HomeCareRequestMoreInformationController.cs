using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Request;
using LBH.AdultSocialCare.Api.V1.Controllers.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBH.AdultSocialCare.Api.V1.Controllers.HomeCare
{
    [Route("api/v1/home-care-request-more-information")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class HomeCareRequestMoreInformationController : BaseController
    {
        private readonly ICreateHomeCareRequestMoreInformationUseCase _createHomeCareRequestMoreInformationUseCase;
        private readonly IChangeStatusHomeCarePackageUseCase _changeStatusHomeCarePackageUseCase;

        public HomeCareRequestMoreInformationController(ICreateHomeCareRequestMoreInformationUseCase createHomeCareRequestMoreInformationUseCase,
            IChangeStatusHomeCarePackageUseCase changeStatusHomeCarePackageUseCase)
        {
            _createHomeCareRequestMoreInformationUseCase = createHomeCareRequestMoreInformationUseCase;
            _changeStatusHomeCarePackageUseCase = changeStatusHomeCarePackageUseCase;
        }

        /// <summary>
        /// Creates the home care request more information.
        /// </summary>
        /// <param name="homeCareRequestMoreInformationForCreationRequest">The home care request more information for creation.</param>
        /// <returns>A boolean value if home care request more information succeed</returns>
        /// <response code="200">Returns boolean value</response>
        /// <response code="400">If the item is null</response>
        /// <response code="422">If the model is invalid</response>
        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> CreateHomeCareRequestMoreInformation([FromBody] HomeCareRequestMoreInformationForCreationRequest homeCareRequestMoreInformationForCreationRequest)
        {
            if (homeCareRequestMoreInformationForCreationRequest == null)
            {
                return BadRequest("Object for creation cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var homeCareBrokerageCreationDomain = homeCareRequestMoreInformationForCreationRequest.ToDomain();
            var result = await _createHomeCareRequestMoreInformationUseCase.Execute(homeCareBrokerageCreationDomain).ConfigureAwait(false);
            await _changeStatusHomeCarePackageUseCase
                .UpdateAsync(homeCareRequestMoreInformationForCreationRequest.HomeCarePackageId, ApprovalHistoryConstants.RequestMoreInformationId, homeCareRequestMoreInformationForCreationRequest.InformationText)
                .ConfigureAwait(false);
            return Ok(result);
        }
    }
}
