using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Exceptions.Models;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common
{
    [Route("api/v1/care-packages/{carePackageId}/reclaims")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class CarePackageReclaimController : ControllerBase
    {
        private readonly ICreateCarePackageReclaimUseCase _createCarePackageReclaimUseCase;
        private readonly IUpdateCarePackageReclaimUseCase _updateCarePackageReclaimUseCase;
        private readonly IGetCarePackageReclaimUseCase _getCarePackageReclaimUseCase;
        private readonly IGetFundedNursingCarePriceUseCase _getFundedNursingCarePriceUseCase;
        private readonly ICareChargeUseCase _getCareChargeUseCase;
        private readonly IGetCareChargePackagesUseCase _getCareChargePackagesUseCase;
        private readonly IGetSinglePackageCareChargeUseCase _getSinglePackageCareChargeUseCase;

        public CarePackageReclaimController(ICreateCarePackageReclaimUseCase createCarePackageReclaimUseCase,
            IUpdateCarePackageReclaimUseCase updateCarePackageReclaimUseCase,
            IGetCarePackageReclaimUseCase getCarePackageReclaimUseCase,
            IGetFundedNursingCarePriceUseCase getFundedNursingCarePriceUseCase,
            ICareChargeUseCase getCareChargeUseCase,
            IGetCareChargePackagesUseCase getCareChargePackagesUseCase,
            IGetSinglePackageCareChargeUseCase getSinglePackageCareChargeUseCase)
        {
            _createCarePackageReclaimUseCase = createCarePackageReclaimUseCase;
            _updateCarePackageReclaimUseCase = updateCarePackageReclaimUseCase;
            _getCarePackageReclaimUseCase = getCarePackageReclaimUseCase;
            _getFundedNursingCarePriceUseCase = getFundedNursingCarePriceUseCase;
            _getCareChargeUseCase = getCareChargeUseCase;
            _getCareChargePackagesUseCase = getCareChargePackagesUseCase;
            _getSinglePackageCareChargeUseCase = getSinglePackageCareChargeUseCase;
        }

        /// <summary>Creates a new funded nursing care reclaim.</summary>
        /// <param name="fundedNursingCareCreationRequest">The funded nursing care request.</param>
        /// <returns>The created funded nursing care package reclaim.</returns>
        [ProducesResponseType(typeof(CarePackageReclaimResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpPost("fnc")]
        public async Task<ActionResult<CarePackageReclaimResponse>> CreateFundedNursingCare([FromBody] FundedNursingCareCreationRequest fundedNursingCareCreationRequest)
        {
            var fundedNursingCareResponse = await _createCarePackageReclaimUseCase.CreateCarePackageReclaim(fundedNursingCareCreationRequest.ToDomain());
            return Ok(fundedNursingCareResponse);
        }

        /// <summary>Creates a new care charge reclaim.</summary>
        /// <param name="careChargeReclaimCreationRequest">The care charge reclaim request.</param>
        /// <returns>The created care charge reclaim.</returns>
        [ProducesResponseType(typeof(CarePackageReclaimResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpPost("care-charges")]
        public async Task<ActionResult<CarePackageReclaimResponse>> CreateCareChargeReclaim([FromBody] CareChargeReclaimCreationRequest careChargeReclaimCreationRequest)
        {
            var carePackageReclaimResponse = await _createCarePackageReclaimUseCase.CreateCarePackageReclaim(careChargeReclaimCreationRequest.ToDomain());
            return Ok(carePackageReclaimResponse);
        }

        /// <summary>Update single funded nursing care reclaim.</summary>
        /// <param name="fundedNursingCareUpdateRequest">The funded nursing care update request.</param>
        /// <returns>The boolean response.</returns>
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpPut("fnc")]
        public async Task<ActionResult<bool>> UpdateFundedNursingCare([FromBody] FundedNursingCareUpdateRequest fundedNursingCareUpdateRequest)
        {
            var result = await _updateCarePackageReclaimUseCase.UpdateCarePackageReclaim(fundedNursingCareUpdateRequest.ToDomain());
            return Ok(result);
        }

        /// <summary>Update single care charge reclaim.</summary>
        /// <param name="careChargeReclaimUpdateRequest">The care charge reclaim update request.</param>
        /// <returns>The boolean response.</returns>
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpPut("care-charges")]
        public async Task<ActionResult<bool>> UpdateCareChargeReclaim([FromBody] CareChargeReclaimUpdateRequest careChargeReclaimUpdateRequest)
        {
            var result = await _updateCarePackageReclaimUseCase.UpdateCarePackageReclaim(careChargeReclaimUpdateRequest.ToDomain());
            return Ok(result);
        }

        /// <summary>Return single care charge reclaim.</summary>
        /// <param name="carePackageId">The care package Id.</param>
        /// <returns>The Care Package Claim response.</returns>
        [ProducesResponseType(typeof(CarePackageReclaimResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpGet("care-charges")]
        public async Task<ActionResult<CarePackageReclaimResponse>> GetCareCharge(Guid carePackageId)
        {
            var result = await _getCarePackageReclaimUseCase.GetCarePackageReclaim(carePackageId, ReclaimType.CareCharge);
            return Ok(result);
        }

        /// <summary>Return single funded nursing care package reclaim.</summary>
        /// <param name="carePackageId">The care package Id.</param>
        /// <returns>The Care Package Claim response.</returns>
        [ProducesResponseType(typeof(CarePackageReclaimResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpGet("fnc")]
        public async Task<ActionResult<CarePackageReclaimResponse>> GetFundedNursingCare(Guid carePackageId)
        {
            var result = await _getCarePackageReclaimUseCase.GetCarePackageReclaim(carePackageId, ReclaimType.Fnc);
            return Ok(result);
        }

        /// <summary>
        /// Returns FNC price active at current date
        /// </summary>
        /// <returns>Returns FNC price active at current date or 404 Not Found if no price is defined.</returns>
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpGet("fnc/active-price")]
        public async Task<decimal> GetActiveFundedNursingCarePrice()
        {
            return await _getFundedNursingCarePriceUseCase.GetActiveFundedNursingCarePriceAsync();
        }

        /// <summary>
        /// Gets the provisional care charge amount using service user id.
        /// </summary>
        /// <param name="serviceUserId">The service user identifier.</param>
        /// <returns>Details of provisional care charges as is set at the current moment</returns>
        /// <response code="200">When provisional amount is found</response>
        /// <response code="404">When service user is not found</response>
        [HttpGet("care-charges/{serviceUserId}/default")]
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<decimal>> GetProvisionalCareChargeAmountUsingServiceUserId(Guid serviceUserId)
        {
            var provisionalAmount = await _getCareChargeUseCase.GetUsingServiceUserIdAsync(serviceUserId);
            return Ok(provisionalAmount.Amount);
        }

        /// <summary>
        /// Gets the paginated care package list with care charge information.
        /// </summary>
        /// <param name="parameters">Parameters to filter list of care packages.</param>
        /// <returns>List of care packages with care charge status</returns>
        [HttpGet("care-charges/packages")]
        [ProducesResponseType(typeof(PagedCareChargePackagesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagedCareChargePackagesResponse>> GetCareChargePackages([FromQuery] CareChargePackagesParameters parameters)
        {
            var result = await _getCareChargePackagesUseCase.GetCareChargePackages(parameters).ConfigureAwait(false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.PagingMetaData));
            return Ok(result);
        }

        /// <summary>
        /// Gets the single package care charge detail.
        /// </summary>
        /// <param name="carePackageId">The care package id.</param>
        /// <returns>Details of care charges with care package information.</returns>
        /// <response code="200">When care package has care charges</response>
        /// <response code="404">When care package is not found</response>
        [HttpGet("care-charges/detail")]
        [ProducesResponseType(typeof(SinglePackageCareChargeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<SinglePackageCareChargeResponse>> GetSinglePackageCareCharge(Guid carePackageId)
        {
            var singlePackageCareCharge = await _getSinglePackageCareChargeUseCase.GetSinglePackageCareCharge(carePackageId).ConfigureAwait(false);
            return Ok(singlePackageCareCharge);
        }
    }
}
