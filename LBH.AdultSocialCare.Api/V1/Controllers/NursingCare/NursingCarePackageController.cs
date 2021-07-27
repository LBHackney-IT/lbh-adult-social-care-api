using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCareApprovalHistoryBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareApprovalHistoryBoundary.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApprovalHistoryUseCase.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace LBH.AdultSocialCare.Api.V1.Controllers.NursingCare
{
    [Route("api/v1/nursing-care-packages")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    [Authorize]
    public class NursingCarePackageController : BaseController
    {
        private readonly IUpdateNursingCarePackageUseCase _updateNursingCarePackageUseCase;
        private readonly IGetNursingCarePackageUseCase _getNursingCarePackageUseCase;
        private readonly IChangeStatusNursingCarePackageUseCase _changeStatusNursingCarePackageUseCase;
        private readonly IGetAllNursingCarePackageUseCase _getAllNursingCarePackageUseCase;
        private readonly IGetAllNursingCareHomeTypeUseCase _getAllNursingCareHomeTypeUseCase;
        private readonly IGetAllNursingCareTypeOfStayOptionUseCase _getAllNursingCareTypeOfStayOptionUseCase;
        private readonly ICreateNursingCarePackageUseCase _createNursingCarePackageUseCase;
        private readonly IGetAllNursingCareApprovalHistoryUseCase _getAllNursingCareApprovalHistoryUseCase;

        public NursingCarePackageController(IUpdateNursingCarePackageUseCase updateNursingCarePackageUseCase,
            IGetNursingCarePackageUseCase getNursingCarePackageUseCase,
            IChangeStatusNursingCarePackageUseCase changeStatusNursingCarePackageUseCase,
            IGetAllNursingCarePackageUseCase getAllNursingCarePackageUseCase,
            IGetAllNursingCareHomeTypeUseCase getAllNursingCareHomeTypeUseCase,
            IGetAllNursingCareTypeOfStayOptionUseCase getAllNursingCareTypeOfStayOptionUseCase,
            ICreateNursingCarePackageUseCase createNursingCarePackageUseCase,
            IGetAllNursingCareApprovalHistoryUseCase getAllNursingCareApprovalHistoryUseCase
            )
        {
            _updateNursingCarePackageUseCase = updateNursingCarePackageUseCase;
            _getNursingCarePackageUseCase = getNursingCarePackageUseCase;
            _changeStatusNursingCarePackageUseCase = changeStatusNursingCarePackageUseCase;
            _getAllNursingCarePackageUseCase = getAllNursingCarePackageUseCase;
            _getAllNursingCareHomeTypeUseCase = getAllNursingCareHomeTypeUseCase;
            _getAllNursingCareTypeOfStayOptionUseCase = getAllNursingCareTypeOfStayOptionUseCase;
            _createNursingCarePackageUseCase = createNursingCarePackageUseCase;
            _getAllNursingCareApprovalHistoryUseCase = getAllNursingCareApprovalHistoryUseCase;
        }

        /// <summary>Creates the specified nursing care package request.</summary>
        /// <param name="nursingCarePackageForCreationRequest">The nursing care package request.</param>
        /// <returns>The nursing care package created.</returns>
        [ProducesResponseType(typeof(NursingCarePackageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public async Task<ActionResult<NursingCarePackageResponse>> CreateNursingCarePackage(NursingCarePackageForCreationRequest nursingCarePackageForCreationRequest)
        {
            if (nursingCarePackageForCreationRequest == null)
            {
                return BadRequest("Object for creation cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var nursingCarePackageForCreationDomain = nursingCarePackageForCreationRequest.ToDomain();
            var nursingCarePackageResponse = await _createNursingCarePackageUseCase.ExecuteAsync(nursingCarePackageForCreationDomain).ConfigureAwait(false);

            //Change status of package
            await _changeStatusNursingCarePackageUseCase
                .UpdateAsync(nursingCarePackageResponse.Id, ApprovalHistoryConstants.NewPackageId)
                .ConfigureAwait(false);

            await _changeStatusNursingCarePackageUseCase
                .UpdateAsync(nursingCarePackageResponse.Id, ApprovalHistoryConstants.SubmittedForApprovalId)
                .ConfigureAwait(false);
            return Ok(nursingCarePackageResponse);
        }

        [HttpPut("{nursingCarePackageId}")]
        [ProducesResponseType(typeof(NursingCarePackageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<NursingCarePackageResponse>> UpdateNursingCarePackage(
            Guid nursingCarePackageId,
            NursingCarePackageForUpdateRequest nursingCarePackageForUpdate)
        {
            if (nursingCarePackageForUpdate == null)
            {
                return BadRequest("Object for update cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var nursingCarePackageForUpdateDomain = nursingCarePackageForUpdate.ToDomain(nursingCarePackageId);
            var result = await _updateNursingCarePackageUseCase.ExecuteAsync(nursingCarePackageForUpdateDomain).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>Gets the specified nursing care package identifier.</summary>
        /// <param name="nursingCarePackageId">The nursing care package identifier.</param>
        /// <returns>The nursing care package response.</returns>
        [HttpGet]
        [Route("{nursingCarePackageId}")]
        public async Task<ActionResult<NursingCarePackageResponse>> GetSingleNursingCarePackage(Guid nursingCarePackageId)
        {
            var nursingCarePackageResponse = await _getNursingCarePackageUseCase.GetAsync(nursingCarePackageId).ConfigureAwait(false);
            return Ok(nursingCarePackageResponse);
        }

        /// <summary>Change the nursing care package status.</summary>
        /// <param name="nursingCarePackageId"></param>
        /// <param name="statusId"></param>
        /// <returns>The nursing care package response model.</returns>
        [ProducesResponseType(typeof(NursingCarePackageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPut]
        [Route("{nursingCarePackageId}/change-status/{statusId}")]
        public async Task<ActionResult<NursingCarePackageResponse>> ChangeNursingCarePackageStatus(
            Guid nursingCarePackageId, int statusId)
        {
            var nursingCarePackageResponse = await _changeStatusNursingCarePackageUseCase
                .UpdateAsync(nursingCarePackageId, statusId)
                .ConfigureAwait(false);
            return Ok(nursingCarePackageResponse);
        }

        /// <summary>Get all Nursing Care Packages</summary>
        /// <returns>The list of Nursing Care Package Response model</returns>
        [ProducesResponseType(typeof(IEnumerable<NursingCarePackageResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("get-all")]
        public async Task<ActionResult<IEnumerable<NursingCarePackageResponse>>> GetNursingCareList()
        {
            var result = await _getAllNursingCarePackageUseCase.GetAllAsync().ConfigureAwait(false);
            return Ok(result);
        }

        [ProducesResponseType(typeof(IEnumerable<TypeOfNursingCareHomeResponse>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("type-of-nursing-care-homes")]
        public async Task<ActionResult<IEnumerable<TypeOfNursingCareHomeResponse>>> GetTypeOfNursingCareHomeOptionsList()
        {
            var result = await _getAllNursingCareHomeTypeUseCase.GetAllAsync().ConfigureAwait(false);
            return Ok(result);
        }

        [ProducesResponseType(typeof(IEnumerable<NursingCareTypeOfStayOptionResponse>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("type-of-stay-options")]
        public async Task<ActionResult<IEnumerable<NursingCareTypeOfStayOptionResponse>>> GetTypeOfStayOptionList()
        {
            var result = await _getAllNursingCareTypeOfStayOptionUseCase.GetAllAsync().ConfigureAwait(false);
            return Ok(result);
        }

        [ProducesResponseType(typeof(IEnumerable<NursingCareApprovalHistoryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("approval-history/{nursingCarePackageId}")]
        public async Task<ActionResult<IEnumerable<NursingCareApprovalHistoryResponse>>> GetApprovalHistoryList(Guid nursingCarePackageId)
        {
            var result = await _getAllNursingCareApprovalHistoryUseCase.GetAllAsync(nursingCarePackageId).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
