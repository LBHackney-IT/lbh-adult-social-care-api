using Common.Exceptions.Models;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Controllers.CarePackages
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
        private readonly IGetCarePackageReclaimsUseCase _getCarePackageReclaimsUseCase;
        private readonly IGetFundedNursingCarePriceUseCase _getFundedNursingCarePriceUseCase;
        private readonly ICareChargeUseCase _getCareChargeUseCase;
        private readonly IGetSinglePackageCareChargeUseCase _getSinglePackageCareChargeUseCase;

        public CarePackageReclaimController(ICreateCarePackageReclaimUseCase createCarePackageReclaimUseCase,
            IUpdateCarePackageReclaimUseCase updateCarePackageReclaimUseCase,
            IGetCarePackageReclaimsUseCase getCarePackageReclaimsUseCase,
            IGetFundedNursingCarePriceUseCase getFundedNursingCarePriceUseCase,
            ICareChargeUseCase getCareChargeUseCase,
            IGetSinglePackageCareChargeUseCase getSinglePackageCareChargeUseCase)
        {
            _createCarePackageReclaimUseCase = createCarePackageReclaimUseCase;
            _updateCarePackageReclaimUseCase = updateCarePackageReclaimUseCase;
            _getCarePackageReclaimsUseCase = getCarePackageReclaimsUseCase;
            _getFundedNursingCarePriceUseCase = getFundedNursingCarePriceUseCase;
            _getCareChargeUseCase = getCareChargeUseCase;
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
        [AuthorizeRoles(RolesEnum.Broker)]
        public async Task<ActionResult<CarePackageReclaimResponse>> CreateFundedNursingCare([FromBody] FundedNursingCareCreationRequest fundedNursingCareCreationRequest)
        {
            var fundedNursingCareResponse = await _createCarePackageReclaimUseCase.CreateCarePackageReclaim(fundedNursingCareCreationRequest.ToDomain(), ReclaimType.Fnc);
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
        [AuthorizeRoles(RolesEnum.CareChargeManager)]
        public async Task<ActionResult<CarePackageReclaimResponse>> CreateCareChargeReclaim([FromBody] CareChargeReclaimCreationRequest careChargeReclaimCreationRequest)
        {
            var carePackageReclaimResponse = await _createCarePackageReclaimUseCase.CreateCarePackageReclaim(careChargeReclaimCreationRequest.ToDomain(), ReclaimType.CareCharge);
            return Ok(carePackageReclaimResponse);
        }

        /// <summary>Update single funded nursing care reclaim.</summary>
        /// <param name="fundedNursingCareUpdateRequest">The funded nursing care update request.</param>
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpPut("fnc")]
        [AuthorizeRoles(RolesEnum.Broker)]
        public async Task<ActionResult> UpdateFundedNursingCare([FromBody] FundedNursingCareUpdateRequest fundedNursingCareUpdateRequest)
        {
            await _updateCarePackageReclaimUseCase.UpdateAsync(fundedNursingCareUpdateRequest.ToDomain());
            return Ok();
        }

        /// <summary>Update single care charge reclaim.</summary>
        /// <param name="requestedReclaims">List of care charge reclaims to be updated.</param>
        /// <returns>List of updated care charge reclaims.</returns>
        /// <response code="200">When operation is completed successfully.</response>
        /// <response code="400">When requested reclaims belong to different care packages.</response>
        /// <response code="404">When one of requested reclaims isn't found.</response>
        /// <response code="422">When validation of requested reclaims failed.</response>
        [ProducesResponseType(typeof(IEnumerable<CarePackageReclaimResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        [HttpPut("care-charges")]
        [AuthorizeRoles(RolesEnum.CareChargeManager)]
        public async Task<ActionResult<IEnumerable<CarePackageReclaimResponse>>> UpdateCareChargeReclaims([FromForm] List<CareChargeReclaimUpdateRequest> requestedReclaims)
        {
            var result = await _updateCarePackageReclaimUseCase.UpdateListAsync(requestedReclaims.ToDomain().ToList());
            return Ok(result.ToResponse());
        }

        /// <summary>Return list of care charge reclaims for a package with optional filtering by care charge sub-type.</summary>
        /// <param name="carePackageId">The care package Id.</param>
        /// <param name="subType">One of care charge sub-types" Provisional, 1-12 weeks, 13+ weeks etc.</param>
        /// <returns>A list of care charges for a package.</returns>
        [ProducesResponseType(typeof(CarePackageReclaimResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpGet("care-charges")]
        public async Task<ActionResult<CarePackageReclaimResponse>> GetCareCharges(Guid carePackageId, ReclaimSubType? subType)
        {
            var result = await _getCarePackageReclaimsUseCase.GetListAsync(carePackageId, ReclaimType.CareCharge, subType);
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
            var result = await _getCarePackageReclaimsUseCase.GetCarePackageReclaim(carePackageId, ReclaimType.Fnc);
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

        /// <summary>
        /// Cancels a reclaim with a given reclaimId
        /// </summary>
        /// <param name="reclaimId">The unique identifier of reclaim to cancel.</param>
        /// <param name="useCase">A reference to the ICancelCarePackageReclaimsUseCase instance.</param>
        /// <response code="200">When operation has been completed successfully.</response>
        /// <response code="404">When reclaim with given id doesn't exists.</response>
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpPut("care-charges/{reclaimId}/cancel")]
        [AuthorizeRoles(RolesEnum.CareChargeManager)]
        public async Task<ActionResult<CarePackageReclaimResponse>> CancelReclaim(
            Guid reclaimId, [FromServices] ICancelCarePackageReclaimsUseCase useCase)
        {
            var reclaim = await useCase.ExecuteAsync(reclaimId);
            return Ok(reclaim.ToResponse());
        }

        /// <summary>
        /// Mark a reclaim with a given reclaimId as ended.
        /// </summary>
        /// <param name="reclaimId">The unique identifier of reclaim to end.</param>
        /// <param name="request">Extra options for ending the request.</param>
        /// <param name="useCase">A reference to the IEndCarePackageReclaimUseCase instance</param>
        /// <response code="200">When operation has been completed successfully.</response>
        /// <response code="404">When reclaim with given id doesn't exists.</response>
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpPut("care-charges/{reclaimId}/end")]
        [AuthorizeRoles(RolesEnum.CareChargeManager)]
        public async Task<ActionResult<CarePackageReclaimResponse>> EndReclaim(
            Guid reclaimId, CarePackageReclaimEndRequest request,
            [FromServices] IEndCarePackageReclaimUseCase useCase)
        {
            var reclaim = await useCase.ExecuteAsync(reclaimId, request);
            return Ok(reclaim.ToResponse());
        }
    }
}
