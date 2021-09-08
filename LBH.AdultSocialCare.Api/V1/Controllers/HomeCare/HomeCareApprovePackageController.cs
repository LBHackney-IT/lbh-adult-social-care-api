using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;
using LBH.AdultSocialCare.Api.V1.Controllers.Common;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LBH.AdultSocialCare.Api.V1.Controllers.HomeCare
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