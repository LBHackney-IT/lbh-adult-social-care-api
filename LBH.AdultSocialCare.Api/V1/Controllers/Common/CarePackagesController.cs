using Common.Exceptions.Models;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Request;
using LBH.AdultSocialCare.Api.V1.Factories;
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

        public CarePackagesController(ICreateCarePackageUseCase createCarePackageUseCase, ICarePackageOptionsUseCase carePackageOptionsUseCase, IUpdateCarePackageUseCase updateCarePackageUseCase)
        {
            _createCarePackageUseCase = createCarePackageUseCase;
            _carePackageOptionsUseCase = carePackageOptionsUseCase;
            _updateCarePackageUseCase = updateCarePackageUseCase;
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
    }
}
