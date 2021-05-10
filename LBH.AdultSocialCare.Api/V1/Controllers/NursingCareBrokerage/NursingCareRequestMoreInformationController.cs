using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareBrokerageBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareRequestMoreInformationUseCase.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.Controllers.NursingCareBrokerage
{
    [Route("api/v1/nursing-care-request-more-information")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class NursingCareRequestMoreInformationController : BaseController
    {
        private readonly ICreateNursingCareRequestMoreInformationUseCase _createNursingCareRequestMoreInformationUseCase;

        public NursingCareRequestMoreInformationController(ICreateNursingCareRequestMoreInformationUseCase createNursingCareRequestMoreInformationUseCase)
        {
            _createNursingCareRequestMoreInformationUseCase = createNursingCareRequestMoreInformationUseCase;
        }

        /// <summary>
        /// Creates the nursing care request more information.
        /// </summary>
        /// <param name="nursingCareRequestMoreInformationForCreationRequest">The nursing care request more information for creation.</param>
        /// <returns>A boolean value if nursing care request more information succeed</returns>
        /// <response code="200">Returns boolean value</response>
        /// <response code="400">If the item is null</response>
        /// <response code="422">If the model is invalid</response>
        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> CreateNursingCareRequestMoreInformation([FromBody] NursingCareRequestMoreInformationForCreationRequest nursingCareRequestMoreInformationForCreationRequest)
        {
            if (nursingCareRequestMoreInformationForCreationRequest == null)
            {
                return BadRequest("Object for creation cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var nursingCareBrokerageCreationDomain = nursingCareRequestMoreInformationForCreationRequest.ToDomain();
            var result = await _createNursingCareRequestMoreInformationUseCase.Execute(nursingCareBrokerageCreationDomain).ConfigureAwait(false);
            return Ok(result);
        }
    }
}