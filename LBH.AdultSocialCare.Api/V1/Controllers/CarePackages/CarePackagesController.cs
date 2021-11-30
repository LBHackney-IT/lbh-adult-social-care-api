using Common.Exceptions.Models;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.Controllers.CarePackages
{
    [Route("api/v1/care-packages")]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    [ApiController]
    public class CarePackagesController : ControllerBase
    {
        private readonly ICreateCarePackageUseCase _createCarePackageUseCase;
        private readonly ICarePackageOptionsUseCase _carePackageOptionsUseCase;
        private readonly IUpdateCarePackageUseCase _updateCarePackageUseCase;
        private readonly ISubmitCarePackageUseCase _submitCarePackageUseCase;
        private readonly IGetCarePackageUseCase _getCarePackageUseCase;
        private readonly IGetCarePackageSummaryUseCase _getCarePackageSummaryUseCase;
        private readonly IAssignCarePlanUseCase _assignCarePlanUseCase;
        private readonly IGetCarePackageHistoryUseCase _getCarePackageHistoryUseCase;
        private readonly ICancelCarePackageUseCase _cancelCarePackageUseCase;
        private readonly IEndCarePackageUseCase _endCarePackageUseCase;
        private readonly IApproveCarePackageUseCase _approveCarePackageUseCase;
        private readonly IDeclineCarePackageUseCase _declineCarePackageUseCase;
        private readonly IConfirmS117ServiceUserUseCase _confirmS117ServiceUserUseCase;
        private readonly IDeleteCarePackageUseCase _deleteCarePackageUseCase;

        public CarePackagesController(
            ICreateCarePackageUseCase createCarePackageUseCase, ICarePackageOptionsUseCase carePackageOptionsUseCase,
            IUpdateCarePackageUseCase updateCarePackageUseCase, ISubmitCarePackageUseCase submitCarePackageUseCase,
            IGetCarePackageUseCase getCarePackageUseCase, IGetCarePackageSummaryUseCase getCarePackageSummaryUseCase,
            IAssignCarePlanUseCase assignCarePlanUseCase, IGetCarePackageHistoryUseCase getCarePackageHistoryUseCase,
            ICancelCarePackageUseCase cancelCarePackageUseCase, IEndCarePackageUseCase endCarePackageUseCase,
            IApproveCarePackageUseCase approveCarePackageUseCase, IDeclineCarePackageUseCase declineCarePackageUseCase,
            IConfirmS117ServiceUserUseCase confirmS117ServiceUserUseCase, IDeleteCarePackageUseCase deleteCarePackageUseCase)
        {
            _createCarePackageUseCase = createCarePackageUseCase;
            _carePackageOptionsUseCase = carePackageOptionsUseCase;
            _updateCarePackageUseCase = updateCarePackageUseCase;
            _submitCarePackageUseCase = submitCarePackageUseCase;
            _getCarePackageUseCase = getCarePackageUseCase;
            _getCarePackageSummaryUseCase = getCarePackageSummaryUseCase;
            _assignCarePlanUseCase = assignCarePlanUseCase;
            _getCarePackageHistoryUseCase = getCarePackageHistoryUseCase;
            _cancelCarePackageUseCase = cancelCarePackageUseCase;
            _endCarePackageUseCase = endCarePackageUseCase;
            _approveCarePackageUseCase = approveCarePackageUseCase;
            _declineCarePackageUseCase = declineCarePackageUseCase;
            _confirmS117ServiceUserUseCase = confirmS117ServiceUserUseCase;
            _deleteCarePackageUseCase = deleteCarePackageUseCase;
        }

        /// <summary>Creates a new care package.</summary>
        /// <param name="carePackageForCreationRequest">The care package request.</param>
        /// <returns>The care package created.</returns>
        [ProducesResponseType(typeof(CarePackagePlainResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        // [AuthorizeRoles(RolesEnum.Broker)]
        public async Task<ActionResult<CarePackagePlainResponse>> CreateCarePackage([FromBody] CarePackageForCreationRequest carePackageForCreationRequest)
        {
            var residentialCarePackageResponse = await _createCarePackageUseCase.CreateAsync(carePackageForCreationRequest.ToDomain());
            return Ok(residentialCarePackageResponse);
        }

        /// <summary>Gets a list of care packages</summary>
        /// <returns>All care packages</returns>
        [ProducesResponseType(typeof(IEnumerable<CarePackageListItemResponse>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarePackageListItemResponse>>> GetAllCarePackages()
        {
            var res = await _getCarePackageUseCase.GetAllAsync();
            return Ok(res);
        }

        /// <summary>
        /// Returns information about a single package with the given carePackageId.
        /// </summary>
        /// <param name="carePackageId">Unique identifier of a package.</param>
        /// <returns>Information about a single package with the given carePackageId.</returns>
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CarePackageResponse), StatusCodes.Status200OK)]
        [HttpGet("{carePackageId}")]
        public async Task<ActionResult<CarePackageResponse>> GetCarePackageAsync(Guid carePackageId)
        {
            var package = await _getCarePackageUseCase.GetSingleAsync(carePackageId);
            return Ok(package);
        }

        /// <summary>Gets core settings for a care package.</summary>
        /// <param name="carePackageId">The care package identifier.</param>
        /// <returns>Core care package settings if success</returns>
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CarePackageResponse), StatusCodes.Status200OK)]
        [HttpGet("{carePackageId}/core")]
        public async Task<ActionResult<CarePackageResponse>> GetCarePackageCore(Guid carePackageId)
        {
            var res = await _getCarePackageUseCase.GetCarePackageCoreAsync(carePackageId);
            return Ok(res);
        }

        /// <summary>Gets care package scheduling options.</summary>
        /// <returns>All care package scheduling options</returns>
        [ProducesResponseType(typeof(IEnumerable<CarePackageSchedulingOptionResponse>), StatusCodes.Status200OK)]
        [HttpGet("package-scheduling-options")]
        public ActionResult<IEnumerable<CarePackageSchedulingOptionResponse>> GetCarePackageSchedulingOptions()
        {
            var packageSchedulingOptions = _carePackageOptionsUseCase.GetCarePackageSchedulingOptions();
            return Ok(packageSchedulingOptions);
        }

        /// <summary>Gets care package status options.</summary>
        /// <returns>All possible care package statuses</returns>
        [ProducesResponseType(typeof(IEnumerable<CarePackageStatusOptionResponse>), StatusCodes.Status200OK)]
        [HttpGet("package-status-options")]
        public ActionResult<IEnumerable<CarePackageStatusOptionResponse>> GetCarePackageStatusOptions()
        {
            var packageStatusOptions = _carePackageOptionsUseCase.GetCarePackageStatusOptions();
            return Ok(packageStatusOptions);
        }

        /// <summary>Updates the care package.</summary>
        /// <param name="carePackageId">The care package identifier.</param>
        /// <param name="carePackageUpdateRequest">The care package update request object.</param>
        /// <returns>The updated care package</returns>
        [ProducesResponseType(typeof(CarePackagePlainResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpPut("{carePackageId}")]
        // [AuthorizeRoles(RolesEnum.Broker)]
        public async Task<ActionResult<CarePackagePlainResponse>> UpdateCarePackage(Guid carePackageId, [FromBody] CarePackageUpdateRequest carePackageUpdateRequest)
        {
            var updateResult = await _updateCarePackageUseCase.UpdateAsync(carePackageId, carePackageUpdateRequest.ToDomain());
            return Ok(updateResult);
        }

        /// <summary>Submits a care package for approval.</summary>
        /// <param name="carePackageId">An unique identifier of a package to be approved.</param>
        /// <param name="request">The care package update request object.</param>
        /// <returns>Ok when operation is successful.</returns>
        [ProducesResponseType(typeof(CarePackagePlainResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpPost("{carePackageId}/submit")]
        // [AuthorizeRoles(RolesEnum.BrokerageApprover)]
        public async Task<ActionResult> SubmitForApproval(Guid carePackageId, CarePackageSubmissionRequest request)
        {
            await _submitCarePackageUseCase.ExecuteAsync(carePackageId, request.ToDomain());
            return Ok();
        }

        /// <summary>Creates a new packages for a service user with HackneyId given and assigns it to a broker.</summary>
        /// <param name="request">Care plan assignment information.</param>
        /// <returns>Ok if operation is successful.</returns>
        /// <response code="200">If operation have completed successfully</response>
        /// <response code="404">If service user with given HackneyId doesn't exists</response>
        /// <response code="500">If user has already an active package with given type assigned.</response>
        [ProducesResponseType(typeof(CarePackagePlainResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpPost("assign")]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        [RequestSizeLimit(209715200)]
        // [AuthorizeRoles(RolesEnum.Broker)]
        public async Task<ActionResult> AssignCarePlan([FromForm] CarePlanAssignmentRequest request)
        {
            await _assignCarePlanUseCase.ExecuteAsync(request.ToDomain());
            return Ok();
        }

        /// <summary>Returns a financial care package summary.</summary>
        /// <param name="carePackageId">An unique identifier of a package to get summary of.</param>
        /// <returns>A financial care package summary response.</returns>
        [ProducesResponseType(typeof(CarePackageSummaryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpGet("{carePackageId}/summary")]
        public async Task<ActionResult<CarePackageSummaryResponse>> GetSummary(Guid carePackageId)
        {
            var result = await _getCarePackageSummaryUseCase.ExecuteAsync(carePackageId);
            return Ok(result.ToResponse());
        }

        /// <summary>Gets list of care packages for the broker view </summary>
        /// <param name="queryParameters">Query parameters to filter list of packages returned.</param>
        /// <returns>List of packages if success</returns>
        [ProducesResponseType(typeof(BrokerPackageViewResponse), StatusCodes.Status200OK)]
        [HttpGet("broker-view")]
        public async Task<ActionResult<BrokerPackageViewResponse>> GetBrokerPackageView([FromQuery] BrokerPackageViewQueryParameters queryParameters)
        {
            var res = await _getCarePackageUseCase.GetBrokerPackageViewListAsync(queryParameters);
            return Ok(res);
        }

        /// <summary>Returns the care package history.</summary>
        /// <param name="carePackageId">The care package identifier.</param>
        /// <returns>History of the care package if success</returns>
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CarePackageHistoryViewResponse), StatusCodes.Status200OK)]
        [HttpGet("{carePackageId}/history")]
        public async Task<ActionResult<CarePackageResponse>> GetCarePackageHistoryAsync(Guid carePackageId)
        {
            var historyResponse = await _getCarePackageHistoryUseCase.ExecuteAsync(carePackageId);
            return Ok(historyResponse);
        }

        /// <summary>Cancel care package.</summary>
        /// <param name="carePackageId">An unique identifier of a package to be cancelled.</param>
        /// <param name="request">The notes object for attaching status change.</param>
        /// <returns>Ok when operation is successful.</returns>
        [ProducesResponseType(typeof(CarePackagePlainResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpPost("{carePackageId}/cancel")]
        // [AuthorizeRoles(RolesEnum.Broker)]
        public async Task<ActionResult> CancelPackage(Guid carePackageId, CarePackageChangeStatusRequest request)
        {
            await _cancelCarePackageUseCase.ExecuteAsync(carePackageId, request.Notes);
            return Ok();
        }

        /// <summary>End care package.</summary>
        /// <param name="carePackageId">An unique identifier of a package to be ended.</param>
        /// <param name="request">The notes object for attaching status change.</param>
        /// <returns>Ok when operation is successful.</returns>
        [ProducesResponseType(typeof(CarePackagePlainResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpPost("{carePackageId}/end")]
        // [AuthorizeRoles(RolesEnum.Broker)]
        public async Task<ActionResult> EndPackage(Guid carePackageId, CarePackageChangeStatusRequest request)
        {
            await _endCarePackageUseCase.ExecuteAsync(carePackageId, request.Notes);
            return Ok();
        }

        /// <summary>Approve care package.</summary>
        /// <param name="carePackageId">An unique identifier of a package to be approved.</param>
        /// <param name="request">The notes object for attaching status change.</param>
        /// <returns>Ok when operation is successful.</returns>
        [ProducesResponseType(typeof(CarePackagePlainResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpPost("{carePackageId}/approve")]
        // [AuthorizeRoles(RolesEnum.BrokerageApprover)]
        public async Task<ActionResult> ApprovePackage(Guid carePackageId, CarePackageChangeStatusRequest request)
        {
            await _approveCarePackageUseCase.ExecuteAsync(carePackageId, request.Notes);
            return Ok();
        }

        /// <summary>Decline care package.</summary>
        /// <param name="carePackageId">An unique identifier of a package to be declined.</param>
        /// <param name="request">The notes object for attaching status change.</param>
        /// <returns>Ok when operation is successful.</returns>
        [ProducesResponseType(typeof(CarePackagePlainResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpPost("{carePackageId}/decline")]
        // [AuthorizeRoles(RolesEnum.BrokerageApprover)]
        public async Task<ActionResult> DeclinePackage(Guid carePackageId, CarePackageChangeStatusRequest request)
        {
            await _declineCarePackageUseCase.ExecuteAsync(carePackageId, request.Notes);
            return Ok();
        }

        /// <summary>Confirm S117 Service User.</summary>
        /// <param name="carePackageId">An unique identifier of a package.</param>
        /// <returns>Ok when operation is successful.</returns>
        [ProducesResponseType(typeof(CarePackagePlainResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpPut("{carePackageId}/confirm-s117")]
        // [AuthorizeRoles(RolesEnum.CareChargeManager)]
        public async Task<ActionResult> ConfirmS117ServiceUser(Guid carePackageId)
        {
            await _confirmS117ServiceUserUseCase.ExecuteAsync(carePackageId);
            return Ok();
        }

        /// <summary>
        /// Returns a list of care packages eligible for approval
        /// </summary>
        /// <param name="queryParameters">Search parameters to filter packages by.</param>
        /// <param name="useCase">A reference to a IGetApprovedPackagesUseCase instance</param>
        /// <returns>Single page of care packages eligible for approval.</returns>
        [ProducesResponseType(typeof(PagedResponse<CarePackageApprovableListItemResponse>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpGet("approvals")]
        // [AuthorizeRoles(RolesEnum.BrokerageApprover)]
        public async Task<ActionResult<PagedResponse<CarePackageApprovableListItemResponse>>> GetApprovedPackages(
            [FromQuery] ApprovableCarePackagesQueryParameters queryParameters,
            [FromServices] IGetApprovableCarePackagesUseCase useCase)
        {
            var result = await useCase.GetListAsync(queryParameters);

            Response.AddPaginationHeaders(result.PagingMetaData);
            return Ok(result.ToPagedResponse(items => items.ToResponse()));
        }

        //TODO temp endpoint will be deleted
        /// <summary>Delete Care Package.</summary>
        /// <param name="carePackageId">An unique identifier of a package.</param>
        [ProducesResponseType(typeof(CarePackagePlainResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpDelete("{carePackageId}")]
        // [AuthorizeRoles(RolesEnum.Broker)]
        public async Task<ActionResult> DeletePackage(Guid carePackageId)
        {
            await _deleteCarePackageUseCase.ExecuteAsync(carePackageId);
            return Ok();
        }

        /// <summary>
        /// Gets care package payment history.
        /// </summary>
        /// <param name="useCase">Use case to get payment history.</param>
        /// <param name="carePackageId">The care package id.</param>
        /// <param name="parameters">Request pagination parameters</param>
        /// <returns>Paged list of package past payments if success</returns>
        [ProducesResponseType(typeof(PackagePaymentViewResponse), StatusCodes.Status200OK)]
        [HttpGet("{carePackageId:guid}/payment-history")]
        public async Task<ActionResult<PackagePaymentViewResponse>> GetCarePackagePaymentHistory([FromServices] IGetPackagePaymentHistoryUseCase useCase, Guid carePackageId, [FromQuery] RequestParameters parameters)
        {
            var res = await useCase.GetAsync(carePackageId, parameters);
            return Ok(res);
        }
    }
}
