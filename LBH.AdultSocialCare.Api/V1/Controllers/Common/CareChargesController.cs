using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common
{
    [Route("api/v1/care-charges")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class CareChargesController : ControllerBase
    {
        private readonly ICareChargeUseCase _careChargeUseCase;

        public CareChargesController(ICareChargeUseCase careChargeUseCase)
        {
            _careChargeUseCase = careChargeUseCase;
        }

        [HttpGet("service-users/{serviceUserId}/default")]
        [ProducesResponseType(typeof(ProvisionalCareChargeAmountPlainResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProvisionalCareChargeAmountPlainResponse>> GetProvisionalCareChargeAmountUsingServiceUserId(Guid serviceUserId)
        {
            var provisionalAmount = await _careChargeUseCase.GetUsingServiceUserIdAsync(serviceUserId).ConfigureAwait(false);
            return Ok(provisionalAmount);
        }
    }
}
