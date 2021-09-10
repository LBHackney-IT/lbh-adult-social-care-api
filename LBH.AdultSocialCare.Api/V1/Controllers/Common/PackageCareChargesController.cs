using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common
{
    [Route("api/v1/package-care-charges")]
    [ApiController]
    public class PackageCareChargesController : ControllerBase
    {
        private readonly ICancelCareChargeElementUseCase _cancelCareChargeElementUseCase;

        public PackageCareChargesController(ICancelCareChargeElementUseCase cancelCareChargeElementUseCase)
        {
            _cancelCareChargeElementUseCase = cancelCareChargeElementUseCase;
        }

        [HttpPut("{packageCareChargeId}/care-charges/{careElementId}/cancel")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProvisionalCareChargeAmountPlainResponse>> ChangeCareChargeElementStatus(Guid packageCareChargeId, Guid careElementId)
        {
            var cancelResult = await _cancelCareChargeElementUseCase.ExecuteAsync(packageCareChargeId, careElementId).ConfigureAwait(false);
            return Ok(cancelResult);
        }
    }
}
