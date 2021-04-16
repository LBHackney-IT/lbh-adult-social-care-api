using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.OpportunityLengthOptionBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.TermTimeConsiderationOptionBoundary.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.OpportunityLengthOptionUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.TermTimeConsiderationOptionUseCases.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/day-care-packages")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class DayCarePackageController : ControllerBase
    {
        private readonly ICreateDayCarePackageUseCase _createDayCarePackageUseCase;
        private readonly IGetDayCarePackageUseCase _getDayCarePackageUseCase;
        private readonly IGetDayCarePackageListUseCase _getDayCarePackageListUseCase;
        private readonly IUpdateDayCarePackageUseCase _updateDayCarePackageUseCase;
        private readonly IGetTermTimeConsiderationOptionsListUseCase _getTermTimeConsiderationOptionsListUseCase;
        private readonly IGetOpportunityLengthOptionsListUseCase _getOpportunityLengthOptionsListUseCase;

        public DayCarePackageController(
            ICreateDayCarePackageUseCase createdDayCarePackageUseCase,
            IGetDayCarePackageUseCase getDayCarePackageUseCase,
            IGetDayCarePackageListUseCase getDayCarePackageListUseCase,
            IUpdateDayCarePackageUseCase updateDayCarePackageUseCase,
            IGetTermTimeConsiderationOptionsListUseCase getTermTimeConsiderationOptionsListUseCase,
            IGetOpportunityLengthOptionsListUseCase getOpportunityLengthOptionsListUseCase)
        {
            _createDayCarePackageUseCase = createdDayCarePackageUseCase;
            _getDayCarePackageUseCase = getDayCarePackageUseCase;
            _getDayCarePackageListUseCase = getDayCarePackageListUseCase;
            _updateDayCarePackageUseCase = updateDayCarePackageUseCase;
            _getTermTimeConsiderationOptionsListUseCase = getTermTimeConsiderationOptionsListUseCase;
            _getOpportunityLengthOptionsListUseCase = getOpportunityLengthOptionsListUseCase;
        }

        /// <summary>Creates the day care package.</summary>
        /// <param name="dayCarePackageForCreation">The day care package for creation.</param>
        /// <returns>A newly created day care package</returns>
        /// <response code="200">Returns ID of the newly created item</response>
        /// <response code="400">If the item is null</response>
        /// <response code="422">If the model is invalid</response>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> CreateDayCarePackage([FromBody] DayCarePackageForCreationRequest dayCarePackageForCreation)
        {
            if (dayCarePackageForCreation == null)
            {
                return BadRequest("Object for creation cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var dayCarePackageDomain = dayCarePackageForCreation.ToDomain();
            var result = await _createDayCarePackageUseCase.Execute(dayCarePackageDomain).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>Get a day care package by Id</summary>
        /// <param name="dayCarePackageId">The day care package ID</param>
        /// <returns>A day care package</returns>
        /// <response code="200">Returns day care package</response>
        /// <response code="404">If the day care package is not found</response>
        [HttpGet("{dayCarePackageId}")]
        [ProducesResponseType(typeof(DayCarePackageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetSingleDayCarePackage(Guid dayCarePackageId)
        {
            var dayCarePackage = await _getDayCarePackageUseCase.Execute(dayCarePackageId).ConfigureAwait(false);
            return Ok(dayCarePackage);
        }

        /// <summary>Gets the day care package list.</summary>
        /// <returns>List of day care packages</returns>
        /// <response code="200">Returns day care package list</response>
        [ProducesResponseType(typeof(IEnumerable<DayCarePackageResponse>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayCarePackageResponse>>> GetDayCarePackageList()
        {
            return Ok(await _getDayCarePackageListUseCase.Execute().ConfigureAwait(false));
        }

        /// <summary>Updates the day care package.</summary>
        /// <param name="dayCarePackageId">The day care package identifier.</param>
        /// <param name="dayCarePackageForUpdate">The day care package for update.</param>
        /// <returns>Updated day care package</returns>
        /// <response code="200">Returns updated day care package</response>
        /// <response code="404">If day care package is not found</response>
        /// <response code="400">If day care package for update is null</response>
        /// <response code="422">If model for update is invalid</response>
        [HttpPut("{dayCarePackageId}")]
        [ProducesResponseType(typeof(DayCarePackageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<DayCarePackageResponse>> UpdateDayCarePackage(
            Guid dayCarePackageId,
            DayCarePackageForUpdateRequest dayCarePackageForUpdate)
        {
            if (dayCarePackageForUpdate == null)
            {
                return BadRequest("Object for update cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var dayCarePackageForUpdateDomain = dayCarePackageForUpdate.ToDomain();
            var result = await _updateDayCarePackageUseCase.Execute(dayCarePackageId, dayCarePackageForUpdateDomain).ConfigureAwait(false);
            return Ok(result);
        }



        #region DayCarePackageOptions

        /// <summary>
        /// Gets the term time consideration option list.
        /// </summary>
        /// <returns>List of term time consideration options</returns>
        /// <response code="200">Returns term time consideration option list</response>
        [ProducesResponseType(typeof(IEnumerable<TermTimeConsiderationOptionResponse>), StatusCodes.Status200OK)]
        [HttpGet("term-time-considerations")]
        public async Task<ActionResult<IEnumerable<TermTimeConsiderationOptionResponse>>> GetTermTimeConsiderationOptionList()
        {
            return Ok(await _getTermTimeConsiderationOptionsListUseCase.Execute().ConfigureAwait(false));
        }

        /// <summary>
        /// Gets the opportunity length option list.
        /// </summary>
        /// <returns>List of possible day care opportunity length e.g 45 minutes, 1 hour</returns>
        /// <response code="200">Returns opportunity length list</response>
        [ProducesResponseType(typeof(IEnumerable<OpportunityLengthOptionResponse>), StatusCodes.Status200OK)]
        [HttpGet("opportunity-length-options")]
        public async Task<ActionResult<IEnumerable<OpportunityLengthOptionResponse>>> GetOpportunityLengthOptionList()
        {
            return Ok(await _getOpportunityLengthOptionsListUseCase.Execute().ConfigureAwait(false));
        }

        #endregion
    }
}
