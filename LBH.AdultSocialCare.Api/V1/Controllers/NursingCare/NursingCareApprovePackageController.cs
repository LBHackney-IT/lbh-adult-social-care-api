using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Controllers.Common;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBH.AdultSocialCare.Api.V1.Controllers.NursingCare
{
    [Route("api/v1/nursing-care-packages/{nursingCarePackageId}/approve-package-contents")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class NursingCareApprovePackageController : BaseController
    {
        private readonly IGetNursingCareApprovePackageUseCase _getNursingCareApprovePackageUseCase;
        private readonly IChangeStatusNursingCarePackageUseCase _changeStatusNursingCarePackageUseCase;

        public NursingCareApprovePackageController(IGetNursingCareApprovePackageUseCase getNursingCareApprovePackageUseCase,
            IChangeStatusNursingCarePackageUseCase changeStatusNursingCarePackageUseCase)
        {
            _getNursingCareApprovePackageUseCase = getNursingCareApprovePackageUseCase;
            _changeStatusNursingCarePackageUseCase = changeStatusNursingCarePackageUseCase;
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

        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> ApprovePackage(Guid nursingCarePackageId)
        {
            var result = await _changeStatusNursingCarePackageUseCase.UpdateAsync(nursingCarePackageId, ApprovalHistoryConstants.PackageApprovedId).ConfigureAwait(false);
            return Ok(result);
        }
    }
}