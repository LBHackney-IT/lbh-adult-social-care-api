using System;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common.CareChargesControllers
{
    [Route("api/v1/care-charges")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class ProvisionalCareChargeAmountController : ControllerBase
    {
        private readonly ICareChargeUseCase _careChargeUseCase;

        public ProvisionalCareChargeAmountController(ICareChargeUseCase careChargeUseCase)
        {
            _careChargeUseCase = careChargeUseCase;
        }

        /// <summary>
        /// Gets the provisional care charge amount using service user id.
        /// </summary>
        /// <param name="serviceUserId">The service user identifier.</param>
        /// <returns>Details of provisional care charges as is set at the current moment</returns>
        /// <response code="200">When provisional amount is found</response>
        /// <response code="404">When service user is not found</response>
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
