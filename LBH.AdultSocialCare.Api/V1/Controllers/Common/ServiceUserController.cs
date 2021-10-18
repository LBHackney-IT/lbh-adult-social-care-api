using Common.Exceptions.Models;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HttpServices.Models.Requests;
using HttpServices.Models.Responses;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces;

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
        private readonly IGetServiceUserSearchUseCase _getServiceUserSearchUseCase;
        private readonly IGetServiceUserMasterSearchUseCase _getServiceUserMasterSearchUseCase;

        public ServiceUserController(IGetServiceUserUseCase getServiceUserUseCase, IGetServiceUserSearchUseCase getServiceUserSearchUseCase,
            IGetServiceUserMasterSearchUseCase getServiceUserMasterSearchUseCase)
        {
            _getServiceUserUseCase = getServiceUserUseCase;
            _getServiceUserSearchUseCase = getServiceUserSearchUseCase;
            _getServiceUserMasterSearchUseCase = getServiceUserMasterSearchUseCase;
        }

        /// <summary>Return service user information.</summary>
        /// <param name="hackneyId">The hackney identifier.</param>
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

        /// <summary>Return service user response.</summary>
        /// <param name="queryParameters">Query parameters to filter list of service user returned.</param>
        /// <returns>The Service User Information response.</returns>
        [ProducesResponseType(typeof(ServiceUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpGet("search")]
        public async Task<ActionResult<ServiceUserResponse>> SearchServiceUser([FromQuery] ServiceUserQueryParameters queryParameters)
        {
            var result = await _getServiceUserSearchUseCase.GetServiceUsers(queryParameters);
            return Ok(result);
        }

        /// <summary>Return service user information.</summary>
        /// <param name="request">Request to filter list of service user returned.</param>
        /// <returns>The Service User Information response.</returns>
        [ProducesResponseType(typeof(ServiceUserInformationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpGet("master-search")]
        public async Task<ActionResult<ServiceUserInformationResponse>> SearchServiceUser([FromQuery] ServiceUserQueryRequest request)
        {
            var result = await _getServiceUserMasterSearchUseCase.GetServiceUsers(request);
            return Ok(result);
        }
    }
}
