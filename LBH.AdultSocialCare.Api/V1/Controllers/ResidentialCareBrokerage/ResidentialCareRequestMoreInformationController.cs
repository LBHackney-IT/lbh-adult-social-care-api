using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareBrokerageBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareApproveBrokeredBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareRequestMoreInformationUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.Controllers.ResidentialCareBrokerage
{
    [Route("api/v1/residential-care-request-more-information")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class ResidentialCareRequestMoreInformationController : Controller
    {
        private readonly ICreateResidentialCareRequestMoreInformationUseCase _createResidentialCareRequestMoreInformationUseCase;
        private readonly IChangeStatusResidentialCarePackageUseCase _changeStatusResidentialCarePackageUseCase;

        public ResidentialCareRequestMoreInformationController(ICreateResidentialCareRequestMoreInformationUseCase createResidentialCareRequestMoreInformationUseCase,
            IChangeStatusResidentialCarePackageUseCase changeStatusResidentialCarePackageUseCase)
        {
            _createResidentialCareRequestMoreInformationUseCase = createResidentialCareRequestMoreInformationUseCase;
            _changeStatusResidentialCarePackageUseCase = changeStatusResidentialCarePackageUseCase;
        }

        /// <summary>
        /// Creates the residential care request more information.
        /// </summary>
        /// <param name="residentialCareRequestMoreInformationForCreationRequest">The residential care request more information for creation.</param>
        /// <returns>A boolean value if residential care request more information succeed</returns>
        /// <response code="200">Returns boolean value</response>
        /// <response code="400">If the item is null</response>
        /// <response code="422">If the model is invalid</response>
        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> CreateResidentialCareRequestMoreInformation([FromBody] ResidentialCareRequestMoreInformationForCreationRequest residentialCareRequestMoreInformationForCreationRequest)
        {
            if (residentialCareRequestMoreInformationForCreationRequest == null)
            {
                return BadRequest("Object for creation cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var residentialCareBrokerageCreationDomain = residentialCareRequestMoreInformationForCreationRequest.ToDomain();
            var result = await _createResidentialCareRequestMoreInformationUseCase.Execute(residentialCareBrokerageCreationDomain).ConfigureAwait(false);
            await _changeStatusResidentialCarePackageUseCase
                .UpdateAsync(residentialCareRequestMoreInformationForCreationRequest.ResidentialCarePackageId, ApprovalHistoryConstants.RequestMoreInformationId, residentialCareRequestMoreInformationForCreationRequest.InformationText)
                .ConfigureAwait(false);
            return Ok(result);
        }
    }
}
