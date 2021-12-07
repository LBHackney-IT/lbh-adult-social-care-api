using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.CarePackages
{
    [Route("api/v1/care-packages/{packageId}/details")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class CarePackageBrokerageController : ControllerBase
    {
        private readonly IUpsertCarePackageBrokerageUseCase _upsertCarePackageBrokerageUseCase;
        private readonly IGetCarePackageBrokerageUseCase _getCarePackageBrokerageUseCase;

        public CarePackageBrokerageController(
            IUpsertCarePackageBrokerageUseCase upsertCarePackageBrokerageUseCase, IGetCarePackageBrokerageUseCase getCarePackageBrokerageUseCase)
        {
            _upsertCarePackageBrokerageUseCase = upsertCarePackageBrokerageUseCase;
            _getCarePackageBrokerageUseCase = getCarePackageBrokerageUseCase;
        }

        /// <summary>
        /// Returns brokerage information for package with package Id given
        /// </summary>
        /// <param name="packageId">Unique identifier of the package to get brokerage for.</param>
        /// <response code="200">If operation completed successfully.</response>
        /// <response code="204">If package doesn't have any associated details.</response>
        /// <returns>Package brokerage information</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CarePackageBrokerageResponse>> GetCarePackageBrokerageAsync(Guid packageId)
        {
            var brokerageInfo = await _getCarePackageBrokerageUseCase.ExecuteAsync(packageId);
            return Ok(brokerageInfo.ToResponse());
        }

        /// <summary>
        /// Creates or updates a list of details (core cost, additional needs etc.) for a package with the given packageId.
        /// Removes existing package details not presented in request
        /// </summary>
        /// <param name="packageId">Unique identifier of the package to create or update details for</param>
        /// <param name="request">Request with information about services and costs.</param>
        /// <returns>OK if operation is successful</returns>
        /// <response code="200">If operation have completed successfully</response>
        /// <response code="404">If package is not found</response>
        /// <response code="409">If package detail cannot be updated or deleted</response>
        /// <response code="422">If request contains some errors</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CreateCarePackageBrokerageInfo(Guid packageId, CarePackageBrokerageCreationRequest request)
        {
            await _upsertCarePackageBrokerageUseCase.ExecuteAsync(packageId, request.ToDomain());
            return Ok();
        }
    }
}
