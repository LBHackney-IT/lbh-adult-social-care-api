using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareApprovePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApprovePackageUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialApprovePackageUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.Controllers.ResidentialCareApprovePackage
{
    [Route("api/v1/residential-care-packages/{residentialCarePackageId}/approve-package-contents")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class ResidentialCareApprovePackageController : Controller
    {
        private readonly IGetResidentialCareApprovePackageUseCase _getResidentialCareApprovePackageUseCase;
        private readonly IChangeStatusResidentialCarePackageUseCase _changeStatusResidentialCarePackageUseCase;

        public ResidentialCareApprovePackageController(IGetResidentialCareApprovePackageUseCase getResidentialCareApprovePackageUseCase,
            IChangeStatusResidentialCarePackageUseCase changeStatusResidentialCarePackageUseCase)
        {
            _getResidentialCareApprovePackageUseCase = getResidentialCareApprovePackageUseCase;
            _changeStatusResidentialCarePackageUseCase = changeStatusResidentialCarePackageUseCase;
        }

        /// <summary>Gets the specified residential care approve package contents identifier.</summary>
        /// <param name="residentialCarePackageId">The residential care package identifier.</param>
        /// <returns>The residential care approve package contents response.</returns>
        [HttpGet]
        public async Task<ActionResult<ResidentialCareApprovePackageResponse>> GetResidentialCareApprovePackageContent(Guid residentialCarePackageId)
        {
            var residentialCareApprovePackageResponse = await _getResidentialCareApprovePackageUseCase.Execute(residentialCarePackageId).ConfigureAwait(false);
            return Ok(residentialCareApprovePackageResponse);
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> ApprovePackage(Guid residentialCarePackageId)
        {
            var result = await _changeStatusResidentialCarePackageUseCase.UpdateAsync(residentialCarePackageId, ApprovalHistoryConstants.PackageApprovedId).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
