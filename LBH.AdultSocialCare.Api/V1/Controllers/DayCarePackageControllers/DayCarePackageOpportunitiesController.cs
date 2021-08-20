using LBH.AdultSocialCare.Api.V1.Factories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.Controllers.DayCarePackageControllers
{
    [Route("api/v1/day-care-packages/{dayCarePackageId}/opportunities")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class DayCarePackageOpportunitiesController : ControllerBase
    {
        private readonly ICreateDayCarePackageOpportunityUseCase _createDayCarePackageOpportunityUseCase;
        private readonly IGetDayCarePackageOpportunityUseCase _getDayCarePackageOpportunityUseCase;
        private readonly IGetDayCarePackageOpportunityListUseCase _getDayCarePackageOpportunityListUseCase;
        private readonly IUpdateDayCarePackageOpportunityUseCase _updateDayCarePackageOpportunityUseCase;

        public DayCarePackageOpportunitiesController(
            ICreateDayCarePackageOpportunityUseCase createDayCarePackageOpportunityUseCase,
            IGetDayCarePackageOpportunityUseCase getDayCarePackageOpportunityUseCase,
            IGetDayCarePackageOpportunityListUseCase getDayCarePackageOpportunityListUseCase,
            IUpdateDayCarePackageOpportunityUseCase updateDayCarePackageOpportunityUseCase
        )
        {
            _createDayCarePackageOpportunityUseCase = createDayCarePackageOpportunityUseCase;
            _getDayCarePackageOpportunityUseCase = getDayCarePackageOpportunityUseCase;
            _getDayCarePackageOpportunityListUseCase = getDayCarePackageOpportunityListUseCase;
            _updateDayCarePackageOpportunityUseCase = updateDayCarePackageOpportunityUseCase;
        }

        /// <summary>
        /// Creates the day care package opportunity.
        /// </summary>
        /// <param name="dayCarePackageId">The day care package identifier.</param>
        /// <param name="dayCarePackageOpportunityForCreation">The day care package opportunity for creation.</param>
        /// <returns>A newly created day care package opportunity</returns>
        /// <response code="200">Returns ID of the newly created item</response>
        /// <response code="400">If the item is null</response>
        /// <response code="404">If the day care package for this opportunity is not found</response>
        /// <response code="422">If the model is invalid</response>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> CreateDayCarePackageOpportunity(Guid dayCarePackageId, [FromBody] DayCarePackageOpportunityForCreationRequest dayCarePackageOpportunityForCreation)
        {
            if (dayCarePackageOpportunityForCreation == null)
            {
                return BadRequest("Object for creation cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var dayCarePackageOpportunityDomain = dayCarePackageOpportunityForCreation.ToDomain(dayCarePackageId);
            var result = await _createDayCarePackageOpportunityUseCase.Execute(dayCarePackageOpportunityDomain).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Gets a single day care package opportunity.
        /// </summary>
        /// <param name="dayCarePackageId">The day care package identifier.</param>
        /// <param name="dayCarePackageOpportunityId">The day care package opportunity identifier.</param>
        /// <returns>A day care package opportunity</returns>
        /// <response code="200">Returns day care package opportunity</response>
        /// <response code="404">If the day care package or opportunity is not found</response>
        [HttpGet("{dayCarePackageOpportunityId}")]
        [ProducesResponseType(typeof(DayCarePackageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetSingleDayCarePackageOpportunity(Guid dayCarePackageId, Guid dayCarePackageOpportunityId)
        {
            var dayCarePackage = await _getDayCarePackageOpportunityUseCase.Execute(dayCarePackageId, dayCarePackageOpportunityId).ConfigureAwait(false);
            return Ok(dayCarePackage);
        }

        /// <summary>
        /// Gets the opportunity list for a day care package.
        /// </summary>
        /// <param name="dayCarePackageId">The day care package identifier.</param>
        /// <returns>List of day care package opportunities</returns>
        /// <response code="200">Returns day care package opportunity list</response>
        [ProducesResponseType(typeof(IEnumerable<DayCarePackageOpportunityResponse>), StatusCodes.Status200OK)]
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<DayCarePackageOpportunityResponse>>> GetDayCarePackageOpportunityList(Guid dayCarePackageId)
        {
            return Ok(await _getDayCarePackageOpportunityListUseCase.Execute(dayCarePackageId).ConfigureAwait(false));
        }

        /// <summary>
        /// Updates the day care package opportunity.
        /// </summary>
        /// <param name="dayCarePackageId">The day care package identifier.</param>
        /// <param name="dayCarePackageOpportunityId">The day care package opportunity identifier.</param>
        /// <param name="dayCarePackageOpportunityForUpdate">The day care package opportunity for update.</param>
        /// <returns>Updated day care package opportunity</returns>
        /// <response code="200">Returns updated day care package opportunity</response>
        /// <response code="404">If day care package or opportunity is not found</response>
        /// <response code="400">If the update item is null</response>
        /// <response code="422">If model for update is invalid</response>
        [HttpPut("{dayCarePackageOpportunityId}")]
        [ProducesResponseType(typeof(DayCarePackageOpportunityResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<DayCarePackageOpportunityResponse>> UpdateDayCarePackageOpportunity(
            Guid dayCarePackageId,
            Guid dayCarePackageOpportunityId,
            DayCarePackageOpportunityForUpdateRequest dayCarePackageOpportunityForUpdate)
        {
            if (dayCarePackageOpportunityForUpdate == null)
            {
                return BadRequest("Object for update cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var dayCarePackageOpportunityForUpdateDomain = dayCarePackageOpportunityForUpdate.ToDomain(dayCarePackageId, dayCarePackageOpportunityId);
            var result = await _updateDayCarePackageOpportunityUseCase.Execute(dayCarePackageOpportunityForUpdateDomain).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
