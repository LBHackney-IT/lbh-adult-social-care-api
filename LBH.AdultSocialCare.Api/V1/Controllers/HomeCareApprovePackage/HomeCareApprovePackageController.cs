using LBH.AdultSocialCare.Api.V1.Boundary.HomeCareApprovePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApprovePackageUseCase.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.HomeCareApprovePackage
{
    [Route("api/v1/home-care-packages/{homeCarePackageId}/approve-package")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class HomeCareApprovePackageController : BaseController
    {
        private readonly IGetHomeCareApprovePackageUseCase _getHomeCareApprovePackageUseCase;

        public HomeCareApprovePackageController(IGetHomeCareApprovePackageUseCase getHomeCareApprovePackageUseCase)
        {
            _getHomeCareApprovePackageUseCase = getHomeCareApprovePackageUseCase;
        }

        /// <summary>Gets the specified home care approve package ordered identifier.</summary>
        /// <param name="homeCarePackageId">The home care package identifier.</param>
        /// <returns>The home care approve package response.</returns>
        [HttpGet]
        public async Task<ActionResult<HomeCareApprovePackageResponse>> GetHomeCareBrokerage(Guid homeCarePackageId)
        {
            var homeCareApprovePackageResponse = await _getHomeCareApprovePackageUseCase.Execute(homeCarePackageId).ConfigureAwait(false);
            return Ok(homeCareApprovePackageResponse);
        }
    }
}
