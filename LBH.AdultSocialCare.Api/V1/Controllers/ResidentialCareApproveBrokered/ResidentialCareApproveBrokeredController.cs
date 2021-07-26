using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareApproveBrokeredBoundary.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialApproveBrokeredUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialApprovePackageUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.Controllers.ResidentialCareApproveBrokered
{
    [Route("api/v1/residential-care-packages/{residentialCarePackageId}/approve-brokered-deal")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class ResidentialCareApproveBrokeredController : Controller
    {
        private readonly IGetResidentialCareApproveBrokeredUseCase _getResidentialCareApproveBrokeredUseCase;
        private readonly IChangeStatusResidentialCarePackageUseCase _changeStatusResidentialCarePackageUseCase;

        public ResidentialCareApproveBrokeredController(IGetResidentialCareApproveBrokeredUseCase getResidentialCareApproveBrokeredUseCase,
            IChangeStatusResidentialCarePackageUseCase changeStatusResidentialCarePackageUseCase)
        {
            _getResidentialCareApproveBrokeredUseCase = getResidentialCareApproveBrokeredUseCase;
            _changeStatusResidentialCarePackageUseCase = changeStatusResidentialCarePackageUseCase;
        }

        /// <summary>Gets the specified residential care approve brokered deal identifier.</summary>
        /// <param name="residentialCarePackageId">The residential care package identifier.</param>
        /// <returns>The residential care approve brokered deal response.</returns>
        [HttpGet]
        public async Task<ActionResult<ResidentialCareApproveBrokeredResponse>> GetResidentialCareApprovePackageContent(Guid residentialCarePackageId)
        {
            var residentialCareApproveBrokeredResponse = await _getResidentialCareApproveBrokeredUseCase.Execute(residentialCarePackageId).ConfigureAwait(false);
            return Ok(residentialCareApproveBrokeredResponse);
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> ApprovePackage(Guid residentialCarePackageId)
        {
            var result = await _changeStatusResidentialCarePackageUseCase.UpdateAsync(residentialCarePackageId, ApprovalHistoryConstants.PackageBrokeredId).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
