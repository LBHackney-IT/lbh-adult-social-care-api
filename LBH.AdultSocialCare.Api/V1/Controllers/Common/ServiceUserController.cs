using Common.Exceptions.Models;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common
{
    [Route("api/v1/service-user")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class ServiceUserController : ControllerBase
    {
        private readonly IGetServiceUserUseCase _getServiceUserUseCase;

        public ServiceUserController(IGetServiceUserUseCase getServiceUserUseCase)
        {
            _getServiceUserUseCase = getServiceUserUseCase;
        }

        /// <summary>Return service user information.</summary>
        /// <returns>The Service User Information response.</returns>
        [ProducesResponseType(typeof(ServiceUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpGet("{hackneyId}")]
        public async Task<ActionResult<ServiceUserResponse>> GetServiceUserInformation(int hackneyId)
        {
            var result = await _getServiceUserUseCase.GetServiceUserInformation(hackneyId);
            return Ok(result);
        }
    }
}
