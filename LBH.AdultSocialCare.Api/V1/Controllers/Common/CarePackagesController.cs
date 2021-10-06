using Common.Exceptions.CustomExceptions;
using Common.Exceptions.Models;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Request;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common
{
    [Route("api/v1/care-packages")]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    [ApiController]
    public class CarePackagesController : ControllerBase
    {
        private readonly ICreateCarePackageUseCase _createCarePackageUseCase;
        private readonly ICarePackageOptionsUseCase _carePackageOptionsUseCase;
        private readonly IUpdateCarePackageUseCase _updateCarePackageUseCase;
        private readonly ISubmitCarePackageUseCase _submitCarePackageUseCase;
        private readonly IGetCarePackageUseCase _getCarePackageUseCase;
        private readonly IGetCarePackageSummaryUseCase _getCarePackageSummaryUseCase;

        public CarePackagesController(
            ICreateCarePackageUseCase createCarePackageUseCase, ICarePackageOptionsUseCase carePackageOptionsUseCase,
            IUpdateCarePackageUseCase updateCarePackageUseCase, ISubmitCarePackageUseCase submitCarePackageUseCase,
            IGetCarePackageUseCase getCarePackageUseCase, IGetCarePackageSummaryUseCase getCarePackageSummaryUseCase)
        {
            _createCarePackageUseCase = createCarePackageUseCase;
            _carePackageOptionsUseCase = carePackageOptionsUseCase;
            _updateCarePackageUseCase = updateCarePackageUseCase;
            _submitCarePackageUseCase = submitCarePackageUseCase;
            _getCarePackageUseCase = getCarePackageUseCase;
            _getCarePackageSummaryUseCase = getCarePackageSummaryUseCase;
        }

        /// <summary>Creates a new care package.</summary>
        /// <param name="carePackageForCreationRequest">The care package request.</param>
        /// <returns>The care package created.</returns>
        [ProducesResponseType(typeof(CarePackagePlainResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<ActionResult<CarePackagePlainResponse>> CreateCarePackage([FromBody] CarePackageForCreationRequest carePackageForCreationRequest)
        {
            var residentialCarePackageResponse = await _createCarePackageUseCase.CreateAsync(carePackageForCreationRequest.ToDomain());
            return Ok(residentialCarePackageResponse);
        }

        /// <summary>Gets a list of care packages</summary>
        /// <returns>All care packages</returns>
        [ProducesResponseType(typeof(IEnumerable<CarePackageListItemResponse>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarePackageListItemResponse>>> GetAllCarePackages()
        {
            var res = await _getCarePackageUseCase.GetAllAsync();
            return Ok(res);
        }

        /// <summary>
        /// Returns information about a single package with the given carePackageId.
        /// </summary>
        /// <param name="carePackageId">Unique identifier of a package.</param>
        /// <returns>Information about a single package with the given carePackageId.</returns>
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CarePackageResponse), StatusCodes.Status200OK)]
        [HttpGet("{carePackageId}")]
        public async Task<ActionResult<CarePackageResponse>> GetCarePackageAsync(Guid carePackageId)
        {
            var package = await _getCarePackageUseCase.GetSingleAsync(carePackageId);
            return Ok(package.ToResponse());
        }

        /// <summary>Gets settings for a care package.</summary>
        /// <param name="carePackageId">The care package identifier.</param>
        /// <returns>Care package settings if success</returns>
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CarePackageSettingsResponse), StatusCodes.Status200OK)]
        [HttpGet("{carePackageId}/settings")]
        public async Task<ActionResult<CarePackageSettingsResponse>> GetCarePackageSettings(Guid carePackageId)
        {
            var res = await _getCarePackageUseCase.GetCarePackageSettingsAsync(carePackageId);
            return Ok(res);
        }

        /// <summary>Gets care package scheduling options.</summary>
        /// <returns>All care package scheduling options</returns>
        [ProducesResponseType(typeof(IEnumerable<CarePackageSchedulingOptionResponse>), StatusCodes.Status200OK)]
        [HttpGet("package-scheduling-options")]
        public ActionResult<IEnumerable<CarePackageSchedulingOptionResponse>> GetCarePackageSchedulingOptions()
        {
            var packageSchedulingOptions = _carePackageOptionsUseCase.GetCarePackageSchedulingOptions();
            return Ok(packageSchedulingOptions);
        }

        /// <summary>Updates the care package.</summary>
        /// <param name="carePackageId">The care package identifier.</param>
        /// <param name="carePackageUpdateRequest">The care package update request object.</param>
        /// <returns>The updated care package</returns>
        [ProducesResponseType(typeof(CarePackagePlainResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpPut("{carePackageId}")]
        public async Task<ActionResult<CarePackagePlainResponse>> UpdateCarePackage(Guid carePackageId, [FromBody] CarePackageUpdateRequest carePackageUpdateRequest)
        {
            var residentialCarePackageResponse = await _updateCarePackageUseCase.UpdateAsync(carePackageId, carePackageUpdateRequest.ToDomain());
            return Ok(residentialCarePackageResponse);
        }

        /// <summary>Submits a care package for approval.</summary>
        /// <param name="carePackageId">An unique identifier of a package to be approved.</param>
        /// <param name="request">The care package update request object.</param>
        /// <returns>Ok when operation is successful.</returns>
        [HttpPost("{carePackageId}/submit")]
        [ProducesResponseType(typeof(CarePackagePlainResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> SubmitForApproval(Guid carePackageId, CarePackageSubmissionRequest request)
        {
            await _submitCarePackageUseCase.ExecuteAsync(carePackageId, request.ToDomain());
            return Ok();
        }

        /// <summary>Returns a financial care package summary.</summary>
        /// <param name="carePackageId">An unique identifier of a package to get summary of.</param>
        /// <returns>A financial care package summary response.</returns>
        [HttpGet("{carePackageId}/summary")]
        [ProducesResponseType(typeof(CarePackageSummaryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CarePackageSummaryResponse>> GetSummary(Guid carePackageId)
        {
            var result = await _getCarePackageSummaryUseCase.ExecuteAsync(carePackageId);
            return Ok(result);
        }

        /// <summary>Gets list of care packages for the broker view </summary>
        /// <param name="queryParameters">Query parameters to filter list of packages returned.</param>
        /// <returns>List of packages if success</returns>
        [ProducesResponseType(typeof(BrokerPackageViewResponse), StatusCodes.Status200OK)]
        [HttpGet("broker-view")]
        public async Task<ActionResult<BrokerPackageViewResponse>> GetBrokerPackageView([FromQuery] BrokerPackageViewQueryParameters queryParameters)
        {
            var res = await _getCarePackageUseCase.GetBrokerPackageViewListAsync(queryParameters);
            return Ok(res);
        }
    }
}
