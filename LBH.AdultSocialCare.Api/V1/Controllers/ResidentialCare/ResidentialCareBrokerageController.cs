using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.ResidentialCare
{
    [Route("api/v1/residential-care-packages/{residentialCarePackageId}/brokerage")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class ResidentialCareBrokerageController : Controller
    {
        private readonly IGetResidentialCareBrokerageUseCase _getResidentialCareBrokerageUseCase;
        private readonly ICreateResidentialCareBrokerageUseCase _createResidentialCareBrokerageUseCase;
        private readonly IChangeStatusResidentialCarePackageUseCase _changeStatusResidentialCarePackageUseCase;
        private readonly ISetStageToResidentialCarePackageUseCase _setStageToResidentialCarePackageUseCase;

        public ResidentialCareBrokerageController(IGetResidentialCareBrokerageUseCase getResidentialCareBrokerageUseCase,
            ICreateResidentialCareBrokerageUseCase createResidentialCareBrokerageUseCase,
            IChangeStatusResidentialCarePackageUseCase changeStatusResidentialCarePackageUseCase,
            ISetStageToResidentialCarePackageUseCase setStageToResidentialCarePackageUseCase)
        {
            _getResidentialCareBrokerageUseCase = getResidentialCareBrokerageUseCase;
            _createResidentialCareBrokerageUseCase = createResidentialCareBrokerageUseCase;
            _changeStatusResidentialCarePackageUseCase = changeStatusResidentialCarePackageUseCase;
            _setStageToResidentialCarePackageUseCase = setStageToResidentialCarePackageUseCase;
        }

        /// <summary>Gets the specified residential care package identifier.</summary>
        /// <param name="residentialCarePackageId">The residential care package identifier.</param>
        /// <returns>The residential care brokerage response.</returns>
        [HttpGet]
        public async Task<ActionResult<ResidentialCareBrokerageInfoResponse>> GetResidentialCareBrokerage(Guid residentialCarePackageId)
        {
            var residentialCareBrokerageResponse = await _getResidentialCareBrokerageUseCase.Execute(residentialCarePackageId).ConfigureAwait(false);
            return Ok(residentialCareBrokerageResponse);
        }

        /// <summary>
        /// Creates the residential care package brokerage.
        /// </summary>
        /// <param name="residentialCareBrokerageForCreationRequest">The residential care package brokerage for creation.</param>
        /// <returns>A newly created residential care package brokerage</returns>
        /// <response code="200">Returns ID of the newly created item</response>
        /// <response code="400">If the item is null</response>
        /// <response code="404">If the residential care package for this brokerage is not found</response>
        /// <response code="422">If the model is invalid</response>
        [HttpPost]
        [ProducesResponseType(typeof(ResidentialCareBrokerageInfoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ResidentialCareBrokerageInfoResponse>> CreateResidentialCareBrokerage([FromBody] ResidentialCareBrokerageForCreationRequest residentialCareBrokerageForCreationRequest)
        {
            var result = await _createResidentialCareBrokerageUseCase.ExecuteAsync(residentialCareBrokerageForCreationRequest.ToDomain()).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPut("stage/{stageId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> SetStageToPackage(Guid residentialCarePackageId, int stageId)
        {
            var result = await _setStageToResidentialCarePackageUseCase.UpdatePackage(residentialCarePackageId, stageId).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPut("clarifying-commercials")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> ApprovePackage(Guid residentialCarePackageId, [FromBody] string requestMoreInformationText)
        {
            var result = await _changeStatusResidentialCarePackageUseCase.UpdateAsync(residentialCarePackageId, ApprovalHistoryConstants.ClarifyingCommercialsId, requestMoreInformationText).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
