using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareApprovePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApprovePackageUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApprovePackageUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.Controllers.NursingCareApprovePackage
{
    [Route("api/v1/nursing-care-packages/{nursingCarePackageId}/approve-package-contents")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class NursingCareApprovePackageController : BaseController
    {
        private readonly IGetNursingCareApprovePackageUseCase _getNursingCareApprovePackageUseCase;

        public NursingCareApprovePackageController(IGetNursingCareApprovePackageUseCase getNursingCareApprovePackageUseCase)
        {
            _getNursingCareApprovePackageUseCase = getNursingCareApprovePackageUseCase;
        }

        /// <summary>Gets the specified nursing care approve package contents identifier.</summary>
        /// <param name="nursingCarePackageId">The nursing care package identifier.</param>
        /// <returns>The nursing care approve package contents response.</returns>
        [HttpGet]
        public async Task<ActionResult<NursingCareApprovePackageResponse>> GetNursingCareApprovePackageContent(Guid nursingCarePackageId)
        {
            var nursingCareApprovePackageResponse = await _getNursingCareApprovePackageUseCase.Execute(nursingCarePackageId).ConfigureAwait(false);
            return Ok(nursingCareApprovePackageResponse);
        }
    }
}
