using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;
using Newtonsoft.Json;

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
        private readonly IGetCareChargePackagesUseCase _getCareChargePackagesUseCase;

        public CareChargesController(ICareChargeUseCase careChargeUseCase, ICreateCareChargeElementUseCase createCareChargeElementUseCase,
            IGetCareChargePackagesUseCase getCareChargePackagesUseCase)
        {
            _careChargeUseCase = careChargeUseCase;
            _createCareChargeElementUseCase = createCareChargeElementUseCase;
            _getCareChargePackagesUseCase = getCareChargePackagesUseCase;
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
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CareChargeElementCreationResponse>> CreateCareChargeElement(CareChargeElementCreationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var newElements = await _createCareChargeElementUseCase
                .ExecuteAsync(new List<CareChargeElementPlainDomain> { request.ToPlainDomain() })
                .ConfigureAwait(false);

            return Ok(newElements.First().ToCreationResponse());
        }

        /// <summary>
        /// Adds a new Financial Assessment with provisional amounts for 1-12 and 13+ weeks
        /// </summary>
        /// <returns>True if operation is successful</returns>
        /// <response code="200">When a new Financial Assessment has been created successfully</response>
        /// <response code="422">When request is invalid</response>
        [HttpPost("financial-assessment")]
        [ProducesResponseType(typeof(CareChargeElementCreationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> AddFinancialAssessment(IEnumerable<CareChargeElementCreationRequest> request)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var careChargeElements = await _createCareChargeElementUseCase
                .ExecuteAsync(request.ToPlainDomain())
                .ConfigureAwait(false);

            return Ok(careChargeElements.ToCreationResponse());
        }

        [HttpGet("packages")]
        [ProducesResponseType(typeof(PagedCareChargePackagesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagedCareChargePackagesResponse>> GetCareChargePackages([FromQuery] CareChargePackagesParameters parameters)
        {
            var result = await _getCareChargePackagesUseCase.GetCareChargePackages(parameters).ConfigureAwait(false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.PagingMetaData));
            return Ok(result);
        }
    }
}
