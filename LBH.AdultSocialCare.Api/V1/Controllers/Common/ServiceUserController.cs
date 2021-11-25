using Common.Exceptions.Models;
using HttpServices.Models.Requests;
using HttpServices.Models.Responses;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

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
        private readonly IGetServiceUserPackagesUseCase _getServiceUserPackagesUseCase;

        public ServiceUserController(IGetServiceUserUseCase getServiceUserUseCase, IGetServiceUserSearchUseCase getServiceUserSearchUseCase,
            IGetServiceUserMasterSearchUseCase getServiceUserMasterSearchUseCase, IGetServiceUserPackagesUseCase getServiceUserPackagesUseCase)
        {
            _getServiceUserUseCase = getServiceUserUseCase;
            _getServiceUserSearchUseCase = getServiceUserSearchUseCase;
            _getServiceUserMasterSearchUseCase = getServiceUserMasterSearchUseCase;
            _getServiceUserPackagesUseCase = getServiceUserPackagesUseCase;
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
        // [AuthorizeRoles(RolesEnum.Broker, RolesEnum.BrokerageApprover)]
        public async Task<ActionResult<ServiceUserInformationResponse>> SearchServiceUser([FromQuery] ServiceUserQueryRequest request)
        {
            var result = await _getServiceUserMasterSearchUseCase.GetServiceUsers(request);
            return Ok(result);
        }

        /// <summary>Get all the packages for a service user</summary>
        /// <param name="serviceUserId">The service user identifier.</param>
        /// <returns>A list of packages the service users has if success</returns>
        [ProducesResponseType(typeof(ServiceUserPackagesViewResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [HttpGet("{serviceUserId}/care-packages")]
        public async Task<ActionResult<ServiceUserPackagesViewResponse>> GetServiceUserPackages(Guid serviceUserId)
        {
            var result = await _getServiceUserPackagesUseCase.ExecuteAsync(serviceUserId);
            return Ok(result);
        }
    }
}
