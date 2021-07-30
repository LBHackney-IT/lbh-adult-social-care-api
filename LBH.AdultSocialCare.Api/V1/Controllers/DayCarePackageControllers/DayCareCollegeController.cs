using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCareCollegeUseCase.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBH.AdultSocialCare.Api.V1.Controllers.DayCarePackageControllers
{
    [Route("api/v1/day-care-packages/colleges")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    [Authorize]
    public class DayCareCollegeController : BaseController
    {
        private readonly ICreateDayCareCollegeUseCase _createDayCareCollegeUseCase;
        private readonly IGetDayCareCollegeUseCase _getDayCareCollegeUseCase;
        private readonly IGetDayCareCollegeListUseCase _getDayCareCollegeListUseCase;

        public DayCareCollegeController(
            ICreateDayCareCollegeUseCase createDayCareCollegeUseCase,
            IGetDayCareCollegeUseCase getDayCareCollegeUseCase,
            IGetDayCareCollegeListUseCase getDayCareCollegeListUseCase)
        {
            _createDayCareCollegeUseCase = createDayCareCollegeUseCase;
            _getDayCareCollegeUseCase = getDayCareCollegeUseCase;
            _getDayCareCollegeListUseCase = getDayCareCollegeListUseCase;
        }

        /// <summary>Creates the day care college.</summary>
        /// <param name="dayCareCollegeForCreation">The day care college for creation.</param>
        /// <returns>A newly created day care college</returns>
        /// <response code="200">Returns ID of the newly created item</response>
        /// <response code="400">If the item is null</response>
        /// <response code="422">If the model is invalid</response>
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> CreateDayCareCollege([FromBody] DayCareCollegeForCreationRequest dayCareCollegeForCreation)
        {
            if (dayCareCollegeForCreation == null)
            {
                return BadRequest("Object for creation cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var dayCareCollegeDomain = dayCareCollegeForCreation.ToDomain();
            var result = await _createDayCareCollegeUseCase.Execute(dayCareCollegeDomain).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>Get a day care package by Id</summary>
        /// <returns>A day care package</returns>
        /// <response code="200">Returns day care package</response>
        /// <response code="404">If the day care package is not found</response>
        [HttpGet("{dayCareCollegeId}")]
        [ProducesResponseType(typeof(DayCareCollegeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetSingleDayCareCollege(int dayCareCollegeId)
        {
            var dayCareCollege = await _getDayCareCollegeUseCase.Execute(dayCareCollegeId).ConfigureAwait(false);
            return Ok(dayCareCollege);
        }

        /// <summary>Gets the day care college list.</summary>
        /// <returns>List of day care colleges</returns>
        /// <response code="200">Returns day care college list</response>
        [ProducesResponseType(typeof(IEnumerable<DayCareCollegeResponse>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayCareCollegeResponse>>> GetDayCareCollegeList()
        {
            return Ok(await _getDayCareCollegeListUseCase.Execute().ConfigureAwait(false));
        }
    }
}
