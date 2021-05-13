using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareApproveBrokeredBoundary.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialApproveBrokeredUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialApprovePackageUseCase.Interfaces;

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

        public ResidentialCareApproveBrokeredController(IGetResidentialCareApproveBrokeredUseCase getResidentialCareApproveBrokeredUseCase)
        {
            _getResidentialCareApproveBrokeredUseCase = getResidentialCareApproveBrokeredUseCase;
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
    }
}
