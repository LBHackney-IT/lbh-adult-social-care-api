using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareApprovePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApprovePackageUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialApprovePackageUseCase.Interfaces;

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

        public ResidentialCareApprovePackageController(IGetResidentialCareApprovePackageUseCase getResidentialCareApprovePackageUseCase)
        {
            _getResidentialCareApprovePackageUseCase = getResidentialCareApprovePackageUseCase;
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
    }
}
