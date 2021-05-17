using LBH.AdultSocialCare.Api.V1.Boundary.DayCareBrokerageBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCareBrokerageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.DayCarePackageControllers
{
    [Route("api/v1/day-care-packages")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class DayCareBrokerageController : ControllerBase
    {
        private readonly IDayCarePackageBrokerageUseCase _dayCarePackageBrokerageUseCase;

        public DayCareBrokerageController(IDayCarePackageBrokerageUseCase dayCarePackageBrokerageUseCase)
        {
            _dayCarePackageBrokerageUseCase = dayCarePackageBrokerageUseCase;
        }

        /// <summary>Creates the day care package brokerage information.</summary>
        /// <param name="dayCarePackageId">The day care package identifier.</param>
        /// <param name="dayCareBrokerageInfoForCreation">The day care brokerage information for creation.</param>
        /// <returns>Id of the newly created brokerage info object</returns>
        /// <response code="200">Returns ID of the newly created item</response>
        /// <response code="400">If the item is null</response>
        /// <response code="422">If the model is invalid</response>
        [HttpPost("{dayCarePackageId}/brokerage")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> CreateDayCarePackageBrokerageInfo(Guid dayCarePackageId, [FromBody] DayCareBrokerageInfoForCreationRequest dayCareBrokerageInfoForCreation)
        {
            if (dayCareBrokerageInfoForCreation == null)
            {
                return BadRequest("Object for creation cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var dayCarePackageDomain = dayCareBrokerageInfoForCreation.ToDomain(dayCarePackageId);
            var result = await _dayCarePackageBrokerageUseCase.CreateDayPackageBrokerageInfo(dayCarePackageDomain).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>Gets the day care package details for brokerage.</summary>
        /// <param name="dayCarePackageId">The day care package identifier.</param>
        /// <returns>Day care package details</returns>
        /// <response code="200">Returns day care package details</response>
        /// <response code="404">If the day care package is not found</response>
        [HttpGet("{dayCarePackageId}/brokerage")]
        [ProducesResponseType(typeof(DayCarePackageForBrokerageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<DayCarePackageForBrokerageResponse>> GetDayCarePackageDetailsForBrokerage(Guid dayCarePackageId)
        {
            var dayCarePackage = await _dayCarePackageBrokerageUseCase.GetDayCarePackageForBrokerage(dayCarePackageId).ConfigureAwait(false);
            return Ok(dayCarePackage);
        }

        /// <summary>Gets the day care package brokerage stages.</summary>
        /// <returns>List of day care brokerage stages</returns>
        /// <response code="200">Returns day care package brokerage stage list</response>
        [HttpGet("brokerage/stages")]
        [ProducesResponseType(typeof(IEnumerable<DayCareBrokerageStageResponse>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<DayCareBrokerageStageResponse>>> GetDayCarePackageBrokerageStages()
        {
            var brokerageStages = await _dayCarePackageBrokerageUseCase.GetDayCarePackageBrokerageStages().ConfigureAwait(false);
            return Ok(brokerageStages);
        }
    }
}
