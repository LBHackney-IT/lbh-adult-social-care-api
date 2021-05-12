using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareApprovalHistoryBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Request.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareApprovalHistoryBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareApprovalHistoryUseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBH.AdultSocialCare.Api.V1.Controllers.ResidentialCare
{
    [Route("api/v1/residential-care-packages")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class ResidentialCarePackageController : BaseController
    {
        private readonly IUpdateResidentialCarePackageUseCase _updateResidentialCarePackageUseCase;
        private readonly IGetResidentialCarePackageUseCase _getResidentialCarePackageUseCase;
        private readonly IChangeStatusResidentialCarePackageUseCase _changeStatusResidentialCarePackageUseCase;
        private readonly IGetAllResidentialCarePackageUseCase _getAllResidentialCarePackageUseCase;
        private readonly IGetAllResidentialCareHomeTypeUseCase _getAllResidentialCareHomeTypeUseCase;
        private readonly IGetAllResidentialCareTypeOfStayOptionUseCase _getAllResidentialCareTypeOfStayOptionUseCase;
        private readonly ICreateResidentialCarePackageUseCase _createResidentialCarePackageUseCase;
        private readonly IGetAllResidentialCareApprovalHistoryUseCase _getAllResidentialCareApprovalHistoryUseCase;

        public ResidentialCarePackageController(IUpdateResidentialCarePackageUseCase updateResidentialCarePackageUseCase,
            IGetResidentialCarePackageUseCase getResidentialCarePackageUseCase,
            IChangeStatusResidentialCarePackageUseCase changeStatusResidentialCarePackageUseCase,
            IGetAllResidentialCarePackageUseCase getAllResidentialCarePackageUseCase,
            IGetAllResidentialCareHomeTypeUseCase getAllResidentialCareHomeTypeUseCase,
            IGetAllResidentialCareTypeOfStayOptionUseCase getAllResidentialCareTypeOfStayOptionUseCase,
            ICreateResidentialCarePackageUseCase createResidentialCarePackageUseCase,
            IGetAllResidentialCareApprovalHistoryUseCase getAllResidentialCareApprovalHistoryUseCase
            )
        {
            _updateResidentialCarePackageUseCase = updateResidentialCarePackageUseCase;
            _getResidentialCarePackageUseCase = getResidentialCarePackageUseCase;
            _changeStatusResidentialCarePackageUseCase = changeStatusResidentialCarePackageUseCase;
            _getAllResidentialCarePackageUseCase = getAllResidentialCarePackageUseCase;
            _getAllResidentialCareHomeTypeUseCase = getAllResidentialCareHomeTypeUseCase;
            _getAllResidentialCareTypeOfStayOptionUseCase = getAllResidentialCareTypeOfStayOptionUseCase;
            _createResidentialCarePackageUseCase = createResidentialCarePackageUseCase;
            _getAllResidentialCareApprovalHistoryUseCase = getAllResidentialCareApprovalHistoryUseCase;
        }

        /// <summary>Creates the specified residential care package request.</summary>
        /// <param name="residentialCarePackageForCreationRequest">The residential care package request.</param>
        /// <returns>The residential care package created.</returns>
        [ProducesResponseType(typeof(ResidentialCarePackageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public async Task<ActionResult<ResidentialCarePackageResponse>> CreateResidentialCarePackage(ResidentialCarePackageForCreationRequest residentialCarePackageForCreationRequest)
        {
            if (residentialCarePackageForCreationRequest == null)
            {
                return BadRequest("Object for creation cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var residentialCarePackageForCreationDomain = residentialCarePackageForCreationRequest.ToDomain();
            var residentialCarePackageResponse = await _createResidentialCarePackageUseCase.ExecuteAsync(residentialCarePackageForCreationDomain).ConfigureAwait(false);
            return Ok(residentialCarePackageResponse);
        }

        [HttpPut("{residentialCarePackageId}")]
        [ProducesResponseType(typeof(ResidentialCarePackageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ResidentialCarePackageResponse>> UpdateResidentialCarePackage(
            Guid residentialCarePackageId,
            ResidentialCarePackageForUpdateRequest residentialCarePackageForUpdate)
        {
            if (residentialCarePackageForUpdate == null)
            {
                return BadRequest("Object for update cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var residentialCarePackageForUpdateDomain = residentialCarePackageForUpdate.ToDomain(residentialCarePackageId);
            var result = await _updateResidentialCarePackageUseCase.ExecuteAsync(residentialCarePackageForUpdateDomain).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>Gets the specified residential care package identifier.</summary>
        /// <param name="residentialCarePackageId">The residential care package identifier.</param>
        /// <returns>The residential care package response.</returns>
        [HttpGet]
        [Route("{residentialCarePackageId}")]
        public async Task<ActionResult<ResidentialCarePackageResponse>> GetSingleResidentialCarePackage(Guid residentialCarePackageId)
        {
            var residentialCarePackageResponse = await _getResidentialCarePackageUseCase.GetAsync(residentialCarePackageId).ConfigureAwait(false);
            return Ok(residentialCarePackageResponse);
        }

        /// <summary>Change the residential care package status.</summary>
        /// <param name="residentialCarePackageId"></param>
        /// <param name="statusId"></param>
        /// <returns>The residential care package response model.</returns>
        [ProducesResponseType(typeof(ResidentialCarePackageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPut]
        [Route("{residentialCarePackageId}/change-status/{statusId}")]
        public async Task<ActionResult<ResidentialCarePackageResponse>> ChangeResidentialCarePackageStatus(
            Guid residentialCarePackageId, int statusId)
        {
            var residentialCarePackageResponse = await _changeStatusResidentialCarePackageUseCase
                .UpdateAsync(residentialCarePackageId, statusId)
                .ConfigureAwait(false);
            return Ok(residentialCarePackageResponse);
        }

        /// <summary>Get all Residential Care Packages</summary>
        /// <returns>The list of Residential Care Package Response model</returns>
        [ProducesResponseType(typeof(IEnumerable<ResidentialCarePackageResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("get-all")]
        public async Task<ActionResult<IEnumerable<ResidentialCarePackageResponse>>> GetResidentialCareList()
        {
            var result = await _getAllResidentialCarePackageUseCase.GetAllAsync().ConfigureAwait(false);
            return Ok(result);
        }

        [ProducesResponseType(typeof(IEnumerable<TypeOfResidentialCareHomeResponse>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("type-of-residential-care-homes")]
        public async Task<ActionResult<IEnumerable<TypeOfResidentialCareHomeResponse>>> GetTypeOfResidentialCareHomeOptionsList()
        {
            var result = await _getAllResidentialCareHomeTypeUseCase.GetAllAsync().ConfigureAwait(false);
            return Ok(result);
        }

        [ProducesResponseType(typeof(IEnumerable<ResidentialCareTypeOfStayOptionResponse>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("type-of-stay-options")]
        public async Task<ActionResult<IEnumerable<ResidentialCareTypeOfStayOptionResponse>>> GetTypeOfStayOptionList()
        {
            var result = await _getAllResidentialCareTypeOfStayOptionUseCase.GetAllAsync().ConfigureAwait(false);
            return Ok(result);
        }

        [ProducesResponseType(typeof(IEnumerable<ResidentialCareApprovalHistoryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("approval-history/{residentialCarePackageId}")]
        public async Task<ActionResult<IEnumerable<ResidentialCareApprovalHistoryResponse>>> GetApprovalHistoryList(Guid residentialCarePackageId)
        {
            var result = await _getAllResidentialCareApprovalHistoryUseCase.GetAllAsync(residentialCarePackageId).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
