using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareApproveCommercialBoundary.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApproveCommercialUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApprovePackageUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.Controllers.NursingCareApproveCommercial
{
    [Route("api/v1/nursing-care-packages/{nursingCarePackageId}/approve-commercials")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class NursingCareApproveCommercialController : Controller
    {
        private readonly IGetNursingCareApproveCommercialUseCase _getNursingCareApproveCommercialUseCase;

        public NursingCareApproveCommercialController(IGetNursingCareApproveCommercialUseCase getNursingCareApproveCommercialUseCase)
        {
            _getNursingCareApproveCommercialUseCase = getNursingCareApproveCommercialUseCase;
        }

        /// <summary>Gets the specified nursing care approve commercials contents identifier.</summary>
        /// <param name="nursingCarePackageId">The nursing care package identifier.</param>
        /// <returns>The nursing care approve commercials contents response.</returns>
        [HttpGet]
        public async Task<ActionResult<NursingCareApproveCommercialResponse>> GetNursingCareApproveCommercials(Guid nursingCarePackageId)
        {
            var nursingCareApproveCommercialResponse = await _getNursingCareApproveCommercialUseCase.Execute(nursingCarePackageId).ConfigureAwait(false);
            return Ok(nursingCareApproveCommercialResponse);
        }
    }
}
