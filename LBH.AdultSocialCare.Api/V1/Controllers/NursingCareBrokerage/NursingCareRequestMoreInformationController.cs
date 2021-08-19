using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareRequestMoreInformationUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Request;

namespace LBH.AdultSocialCare.Api.V1.Controllers.NursingCareBrokerage
{
    [Route("api/v1/nursing-care-request-more-information")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class NursingCareRequestMoreInformationController : BaseController
    {
        private readonly ICreateNursingCareRequestMoreInformationUseCase _createNursingCareRequestMoreInformationUseCase;
        private readonly IChangeStatusNursingCarePackageUseCase _changeStatusNursingCarePackageUseCase;

        public NursingCareRequestMoreInformationController(ICreateNursingCareRequestMoreInformationUseCase createNursingCareRequestMoreInformationUseCase,
            IChangeStatusNursingCarePackageUseCase changeStatusNursingCarePackageUseCase)
        {
            _createNursingCareRequestMoreInformationUseCase = createNursingCareRequestMoreInformationUseCase;
            _changeStatusNursingCarePackageUseCase = changeStatusNursingCarePackageUseCase;
        }

        /// <summary>
        /// Creates the nursing care request more information.
        /// </summary>
        /// <param name="nursingCareRequestMoreInformationForCreationRequest">The nursing care request more information for creation.</param>
        /// <returns>A boolean value if nursing care request more information succeed</returns>
        /// <response code="200">Returns boolean value</response>
        /// <response code="400">If the item is null</response>
        /// <response code="422">If the model is invalid</response>
        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> CreateNursingCareRequestMoreInformation([FromBody] NursingCareRequestMoreInformationForCreationRequest nursingCareRequestMoreInformationForCreationRequest)
        {
            if (nursingCareRequestMoreInformationForCreationRequest == null)
            {
                return BadRequest("Object for creation cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var nursingCareBrokerageCreationDomain = nursingCareRequestMoreInformationForCreationRequest.ToDomain();
            var result = await _createNursingCareRequestMoreInformationUseCase.Execute(nursingCareBrokerageCreationDomain).ConfigureAwait(false);
            await _changeStatusNursingCarePackageUseCase
                .UpdateAsync(nursingCareRequestMoreInformationForCreationRequest.NursingCarePackageId, ApprovalHistoryConstants.RequestMoreInformationId, nursingCareRequestMoreInformationForCreationRequest.InformationText)
                .ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPost("clarifying-commercials")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> CreateNursingCareClarifyCommercial([FromBody] NursingCareRequestMoreInformationForCreationRequest nursingCareRequestMoreInformationForCreationRequest)
        {
            if (nursingCareRequestMoreInformationForCreationRequest == null)
            {
                return BadRequest("Object for creation cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var nursingCareBrokerageCreationDomain = nursingCareRequestMoreInformationForCreationRequest.ToDomain();
            var result = await _createNursingCareRequestMoreInformationUseCase.Execute(nursingCareBrokerageCreationDomain).ConfigureAwait(false);
            await _changeStatusNursingCarePackageUseCase
                .UpdateAsync(nursingCareRequestMoreInformationForCreationRequest.NursingCarePackageId, ApprovalHistoryConstants.ClarifyingCommercialsId, nursingCareRequestMoreInformationForCreationRequest.InformationText)
                .ConfigureAwait(false);
            return Ok(result);
        }
    }
}
