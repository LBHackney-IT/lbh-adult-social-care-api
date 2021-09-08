using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common
{
    [Route("api/v1/care-charge")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class CareChargeController : ControllerBase
    {
        private readonly ICreateCareChargeElementUseCase _createCareChargeElementUseCase;

        public CareChargeController(ICreateCareChargeElementUseCase createCareChargeElementUseCase)
        {
            _createCareChargeElementUseCase = createCareChargeElementUseCase;
        }

        /// <summary>
        /// Creates a new Care Charge element and returns it to a client
        /// </summary>
        /// <returns>A new Care Charge element</returns>
        /// <response code="200">When Care Charge element has been created successfully</response>
        /// <response code="422">When request is invalid</response>
        [HttpPost("elements")]
        [ProducesResponseType(typeof(CareChargeElementResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        public ActionResult CreateCareChargeElement()
        {
            return Ok();
        }
    }
}
