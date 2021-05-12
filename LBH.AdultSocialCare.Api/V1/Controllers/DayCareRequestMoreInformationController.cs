using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCareBrokerageBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareBrokerageBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCareRequestMoreInformationUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareRequestMoreInformationUseCase.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.Controllers
{
    [Route("api/v1/day-care-request-more-information")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class DayCareRequestMoreInformationController : BaseController
    {
        private readonly ICreateDayCareRequestMoreInformationUseCase _createDayCareRequestMoreInformationUseCase;

        public DayCareRequestMoreInformationController(ICreateDayCareRequestMoreInformationUseCase createDayCareRequestMoreInformationUseCase)
        {
            _createDayCareRequestMoreInformationUseCase = createDayCareRequestMoreInformationUseCase;
        }

        /// <summary>
        /// Creates the day care request more information.
        /// </summary>
        /// <param name="dayCareRequestMoreInformationForCreationRequest">The day care request more information for creation.</param>
        /// <returns>A boolean value if day care request more information succeed</returns>
        /// <response code="200">Returns boolean value</response>
        /// <response code="400">If the item is null</response>
        /// <response code="422">If the model is invalid</response>
        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> CreateDayCareRequestMoreInformation([FromBody] DayCareRequestMoreInformationForCreationRequest dayCareRequestMoreInformationForCreationRequest)
        {
            if (dayCareRequestMoreInformationForCreationRequest == null)
            {
                return BadRequest("Object for creation cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var dayCareBrokerageCreationDomain = dayCareRequestMoreInformationForCreationRequest.ToDomain();
            var result = await _createDayCareRequestMoreInformationUseCase.Execute(dayCareBrokerageCreationDomain).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
