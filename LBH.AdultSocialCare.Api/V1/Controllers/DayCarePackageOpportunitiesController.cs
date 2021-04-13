using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageOpportunityBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageOpportunityBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.Controllers
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


        [HttpGet("{dayCarePackageOpportunityId}")]
        [ProducesResponseType(typeof(DayCarePackageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetSingleDayCarePackage(Guid dayCarePackageId, Guid dayCarePackageOpportunityId)
        {
            var dayCarePackage = await _getDayCarePackageOpportunityUseCase.Execute(dayCarePackageId, dayCarePackageOpportunityId).ConfigureAwait(false);
            return Ok(dayCarePackage);
        }

        [ProducesResponseType(typeof(IEnumerable<DayCarePackageOpportunityResponse>), StatusCodes.Status200OK)]
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<DayCarePackageOpportunityResponse>>> GetDayCarePackageOpportunityList(Guid dayCarePackageId)
        {
            return Ok(await _getDayCarePackageOpportunityListUseCase.Execute(dayCarePackageId).ConfigureAwait(false));
        }

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
