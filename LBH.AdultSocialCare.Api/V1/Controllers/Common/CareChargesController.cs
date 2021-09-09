using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Factories;

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
        private readonly ICreateCareChargeElementUseCase _createCareChargeElementUseCase;

        public CareChargesController(ICareChargeUseCase careChargeUseCase, ICreateCareChargeElementUseCase createCareChargeElementUseCase)
        {
            _careChargeUseCase = careChargeUseCase;
            _createCareChargeElementUseCase = createCareChargeElementUseCase;
        }

        [HttpGet("service-users/{serviceUserId}/default")]
        [ProducesResponseType(typeof(ProvisionalCareChargeAmountPlainResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProvisionalCareChargeAmountPlainResponse>> GetProvisionalCareChargeAmountUsingServiceUserId(Guid serviceUserId)
        {
            var provisionalAmount = await _careChargeUseCase.GetUsingServiceUserIdAsync(serviceUserId).ConfigureAwait(false);
            return Ok(provisionalAmount);
        }

        /// <summary>
        /// Creates a new Care Charge element and returns it to a client
        /// </summary>
        /// <returns>A new Care Charge element</returns>
        /// <response code="200">When Care Charge element has been created successfully</response>
        /// <response code="422">When request is invalid</response>
        [HttpPost("elements")]
        [ProducesResponseType(typeof(CareChargeElementCreationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<CareChargeElementCreationResponse>> CreateCareChargeElement(CareChargeElementCreationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var careChargeElement = await _createCareChargeElementUseCase.ExecuteAsync(request.ToPlainDomain()).ConfigureAwait(false);
            return Ok(careChargeElement.ToCreationResponse());
        }
    }
}
