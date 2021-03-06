using Common.Exceptions.CustomExceptions;
using Common.Exceptions.Models;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using LBH.AdultSocialCare.Data.Constants.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.CarePackages
{
    [Route("api/v1/care-packages/{carePackageId}/reclaims")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class CarePackageReclaimController : ControllerBase
    {
        private readonly ICreateProvisionalCareChargeUseCase _createProvisionalCareChargeUseCase;
        private readonly IUpdateProvisionalCareChargeUseCase _updateProvisionalCareChargeUseCase;
        private readonly IGetCarePackageReclaimsUseCase _getCarePackageReclaimsUseCase;
        private readonly IGetFundedNursingCarePriceUseCase _getFundedNursingCarePriceUseCase;
        private readonly ICareChargeUseCase _getCareChargeUseCase;
        private readonly IGetSinglePackageCareChargeUseCase _getSinglePackageCareChargeUseCase;
        private readonly IUpsertCareChargesUseCase _upsertCareChargesUseCase;

        public CarePackageReclaimController(ICreateProvisionalCareChargeUseCase createProvisionalCareChargeUseCase,
            IUpdateProvisionalCareChargeUseCase updateProvisionalCareChargeUseCase,
            IGetCarePackageReclaimsUseCase getCarePackageReclaimsUseCase,
            IGetFundedNursingCarePriceUseCase getFundedNursingCarePriceUseCase,
            ICareChargeUseCase getCareChargeUseCase,
            IGetSinglePackageCareChargeUseCase getSinglePackageCareChargeUseCase,
            IUpsertCareChargesUseCase upsertCareChargesUseCase)
        {
            _createProvisionalCareChargeUseCase = createProvisionalCareChargeUseCase;
            _updateProvisionalCareChargeUseCase = updateProvisionalCareChargeUseCase;
            _getCarePackageReclaimsUseCase = getCarePackageReclaimsUseCase;
            _getFundedNursingCarePriceUseCase = getFundedNursingCarePriceUseCase;
            _getCareChargeUseCase = getCareChargeUseCase;
            _getSinglePackageCareChargeUseCase = getSinglePackageCareChargeUseCase;
            _upsertCareChargesUseCase = upsertCareChargesUseCase;
        }

        /// <summary>Creates a new funded nursing care reclaim.</summary>
        /// <param name="request">The funded nursing care request.</param>
        /// <param name="useCase">A reference to an instance of the ICreateFncReclaimUseCase.</param>
        /// <returns>The created funded nursing care package reclaim.</returns>
        [ProducesResponseType(typeof(CarePackageReclaimResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpPost("fnc")]
        [AuthorizeRoles(RolesEnum.Broker)]
        public async Task<ActionResult<CarePackageReclaimResponse>> CreateFundedNursingCare(
            [FromForm] FundedNursingCareCreationRequest request,
            [FromServices] ICreateFundedNursingCareUseCase useCase)
        {
            var response = await useCase.ExecuteAsync(request.ToDomain());
            return Ok(response);
        }

        /// <summary>Update single funded nursing care reclaim.</summary>
        /// <param name="request">The funded nursing care update request.</param>
        /// <param name="carePackageId">A unique care package identifier.</param>
        /// <param name="useCase">A reference to an IUpdateFundedNursingCareUseCase instance.</param>
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpPut("fnc")]
        [AuthorizeRoles(RolesEnum.Broker)]
        public async Task<ActionResult> UpdateFundedNursingCare(
            [FromForm] FundedNursingCareUpdateRequest request, Guid carePackageId,
            [FromServices] IUpdateFundedNursingCareUseCase useCase)
        {
            await useCase.UpdateAsync(request.ToDomain(), carePackageId);
            return Ok();
        }

        /// <summary>
        /// Create and update care charge reclaims.
        /// </summary>
        /// <param name="careChargesCreationRequest">Request object.</param>
        /// <param name="carePackageId">Care package Id.</param>
        /// <returns>Ok if success</returns>
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        [HttpPut("care-charges")]
        [AuthorizeRoles(RolesEnum.CareChargeManager)]
        public async Task<ActionResult> UpdateCareChargeReclaims([FromBody] CareChargesCreationRequest careChargesCreationRequest, Guid carePackageId)
        {
            await _upsertCareChargesUseCase.ExecuteAsync(carePackageId, careChargesCreationRequest.ToeDomain());
            return Ok();
        }

        /// <summary>
        /// Uploads care charge assessment file.
        /// </summary>
        /// <param name="useCase">The use case.</param>
        /// <param name="carePackageId">The care package identifier.</param>
        /// <returns>Package Resource Id</returns>
        [ProducesResponseType(typeof(Guid), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPost("care-charges/assessment-file"), DisableRequestSizeLimit]
        [AuthorizeRoles(RolesEnum.CareChargeManager)]
        public async Task<ActionResult> UploadCareChargeAssessmentFile([FromServices] ICreatePackageResourceUseCase useCase, Guid carePackageId)
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files[0];

                if (file == null)
                {
                    throw new ApiException($"Please select a file and try again", HttpStatusCode.BadRequest);
                }

                var resourceId =
                    await useCase.CreateFileAsync(carePackageId, PackageResourceType.CareChargeAssessmentFile, file);

                return Ok(resourceId);
            }
            catch (Exception e)
            {
                throw new ApiException($"An error occurred: {e.Message} {e.InnerException?.Message}");
            }
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
        [AuthorizeRoles(RolesEnum.CareChargeManager)]
        public async Task<ActionResult<CarePackageReclaimResponse>> GetCareCharges(Guid carePackageId, ReclaimSubType? subType)
        {
            var result = await _getCarePackageReclaimsUseCase.GetListAsync(carePackageId, ReclaimType.CareCharge, subType);
            return Ok(result);
        }

        /// <summary>
        /// Gets financial assessment details.
        /// </summary>
        /// <param name="carePackageId">Care package Id.</param>
        /// <returns>Returns current care charges on package if success</returns>
        [ProducesResponseType(typeof(CarePackageReclaimResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [HttpGet("care-charges/assessment-details")]
        [AuthorizeRoles(RolesEnum.CareChargeManager)]
        public async Task<ActionResult<FinancialAssessmentViewResponse>> GetFinancialAssessmentDetails(Guid carePackageId)
        {
            var result = await _getCarePackageReclaimsUseCase.GetFinancialAssessmentDetailsAsync(carePackageId);
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
        [AuthorizeRoles(RolesEnum.Broker)]
        public async Task<ActionResult<CarePackageReclaimResponse>> GetFundedNursingCare(Guid carePackageId)
        {
            var result = await _getCarePackageReclaimsUseCase.GetFundedNursingCare(carePackageId);
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
        [AuthorizeRoles(RolesEnum.Broker, RolesEnum.CareChargeManager)]
        public async Task<ActionResult<decimal>> GetProvisionalCareChargeAmountUsingServiceUserId(Guid serviceUserId)
        {
            var provisionalAmount = await _getCareChargeUseCase.GetUsingServiceUserIdAsync(serviceUserId);
            return Ok(provisionalAmount?.Amount);
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
        [AuthorizeRoles(RolesEnum.CareChargeManager)]
        public async Task<ActionResult<SinglePackageCareChargeResponse>> GetSinglePackageCareCharge(Guid carePackageId)
        {
            var singlePackageCareCharge = await _getSinglePackageCareChargeUseCase.GetSinglePackageCareCharge(carePackageId).ConfigureAwait(false);
            return Ok(singlePackageCareCharge);
        }

        /// <summary>
        /// Cancels a reclaim with a given reclaimId
        /// </summary>
        /// <param name="reclaimId">The unique identifier of reclaim to cancel.</param>
        /// <param name="useCase">A reference to the ICancelCareChargeUseCase instance.</param>
        /// <response code="200">When operation has been completed successfully.</response>
        /// <response code="404">When reclaim with given id doesn't exists.</response>
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpPut("care-charges/{reclaimId}/cancel")]
        [AuthorizeRoles(RolesEnum.CareChargeManager)]
        public async Task<ActionResult<CarePackageReclaimResponse>> CancelReclaim(
            Guid reclaimId, [FromServices] ICancelCareChargeUseCase useCase)
        {
            var reclaim = await useCase.ExecuteAsync(reclaimId);
            return Ok(reclaim.ToResponse());
        }

        /// <summary>
        /// Mark a reclaim with a given reclaimId as ended.
        /// </summary>
        /// <param name="reclaimId">The unique identifier of reclaim to end.</param>
        /// <param name="request">Extra options for ending the request.</param>
        /// <param name="useCase">A reference to the IEndCareChargeUseCase instance</param>
        /// <response code="200">When operation has been completed successfully.</response>
        /// <response code="404">When reclaim with given id doesn't exists.</response>
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpPut("care-charges/{reclaimId}/end")]
        [AuthorizeRoles(RolesEnum.CareChargeManager)]
        public async Task<ActionResult<CarePackageReclaimResponse>> EndReclaim(
            Guid reclaimId, CarePackageReclaimEndRequest request,
            [FromServices] IEndCareChargeUseCase useCase)
        {
            var reclaim = await useCase.ExecuteAsync(reclaimId, request);
            return Ok(reclaim.ToResponse());
        }

        /// <summary>Update single care charge reclaim.</summary>
        /// <param name="carePackageId">An unique identifier of a package containing the given reclaim.</param>
        /// <param name="requestedReclaim">Care charge reclaim to be updated.</param>
        /// <returns>Care charge reclaims to be updated.</returns>
        /// <response code="200">When operation is completed successfully.</response>
        /// <response code="400">When requested reclaims belong to different care packages.</response>
        /// <response code="404">When one of requested reclaims isn't found.</response>
        /// <response code="422">When validation of requested reclaims failed.</response>
        [ProducesResponseType(typeof(Task), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        [HttpPut("care-charges/{careChargeId}")]
        [AuthorizeRoles(RolesEnum.CareChargeManager)]
        public async Task<ActionResult> UpdateProvisionalCareChargeReclaims(Guid carePackageId, CareChargeReclaimUpdateRequest requestedReclaim)
        {
            await _updateProvisionalCareChargeUseCase.UpdateAsync(carePackageId, requestedReclaim.ToDomain());
            return Ok();
        }

        /// <summary>Return single provisional care charge reclaims</summary>
        /// <param name="carePackageId">The care package Id.</param>
        /// <returns>A provisional care charges for a package.</returns>
        [ProducesResponseType(typeof(CarePackageReclaimResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpGet("care-charges/provisional")]
        [AuthorizeRoles(RolesEnum.CareChargeManager, RolesEnum.Broker)]
        public async Task<ActionResult<CarePackageReclaimResponse>> GetProvisionalCareCharges(Guid carePackageId)
        {
            var result = await _getCarePackageReclaimsUseCase.GetProvisionalCareCharge(carePackageId);
            return Ok(result);
        }

        /// <summary>Creates a provisional care charge reclaim.</summary>
        /// <param name="careChargeReclaimCreationRequest">The care charge reclaim request.</param>
        /// <returns>The created provisional care charge reclaim.</returns>
        [ProducesResponseType(typeof(CarePackageReclaimResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpPost("care-charges/provisional")]
        [AuthorizeRoles(RolesEnum.CareChargeManager, RolesEnum.Broker)]
        public async Task<ActionResult<CarePackageReclaimResponse>> CreateProvisionalCareChargeReclaim(CareChargeReclaimCreationRequest careChargeReclaimCreationRequest)
        {
            var carePackageReclaimResponse = await _createProvisionalCareChargeUseCase.CreateProvisionalCareCharge(careChargeReclaimCreationRequest.ToDomain(), ReclaimType.CareCharge);
            return Ok(carePackageReclaimResponse);
        }
    }
}
