using System;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common.CareChargesControllers
{
    [Route("api/v1/package-care-charges")]
    [ApiController]
    public class PackageCareChargesController : ControllerBase
    {
        private readonly ICancelOrEndCareChargeElementUseCase _cancelOrEndCareChargeElementUseCase;

        public PackageCareChargesController(ICancelOrEndCareChargeElementUseCase cancelOrEndCareChargeElementUseCase)
        {
            _cancelOrEndCareChargeElementUseCase = cancelOrEndCareChargeElementUseCase;
        }

        [HttpPut("{packageCareChargeId}/care-charges/{careElementId}/cancel")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProvisionalCareChargeAmountPlainResponse>> ChangeCareChargeElementStatus(Guid packageCareChargeId, Guid careElementId)
        {
            var cancelResult = await _cancelOrEndCareChargeElementUseCase.ExecuteCancelAsync(packageCareChargeId, careElementId).ConfigureAwait(false);
            return Ok(cancelResult);
        }
    }
}
