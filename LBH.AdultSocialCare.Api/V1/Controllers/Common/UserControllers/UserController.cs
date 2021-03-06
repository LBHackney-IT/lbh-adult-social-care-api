using Common.Exceptions.Models;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common.UserControllers
{
    [Route("api/v1/users")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class UserController : BaseController
    {
        private readonly IGetUsersUseCase _getUsersUseCase;
        private readonly IGetAllUsersUseCase _getAllUsersUseCase;

        public UserController(IGetUsersUseCase getUsersUseCase,
            IGetAllUsersUseCase getAllUsersUseCase)
        {
            _getUsersUseCase = getUsersUseCase;
            _getAllUsersUseCase = getAllUsersUseCase;
        }

        [ProducesResponseType(typeof(PagedResponse<AppUserResponse>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("users-with-roles")]
        public async Task<ActionResult<PagedResponse<AppUserResponse>>> GetUsersWithRoles([FromBody] UsersWithRolesRequest request, [FromQuery] AppUserListQueryParameters queryParams)
        {
            var res = await _getUsersUseCase.GetUsersWithRoles(request.Roles?.ToList(), queryParams).ConfigureAwait(false);
            return Ok(res);
        }

        /// <summary>Return list of user with broker role.</summary>
        /// <returns>The list of broker users response.</returns>
        [ProducesResponseType(typeof(UsersMinimalResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpGet("broker")]
        public async Task<ActionResult<UsersMinimalResponse>> GetBrokers()
        {
            var result = await _getAllUsersUseCase.GetUsersWithRole(RolesEnum.Broker);
            return Ok(result);
        }

        /// <summary>Return list of user with broker role.</summary>
        /// <returns>The list of broker users response.</returns>
        [ProducesResponseType(typeof(UsersMinimalResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpGet("approver")]
        public async Task<ActionResult<UsersMinimalResponse>> GetApprover()
        {
            var result = await _getAllUsersUseCase.GetUsersWithRole(RolesEnum.BrokerageApprover);
            return Ok(result);
        }

        /// <summary>Return list of users.</summary>
        /// <returns>The list of users response.</returns>
        [ProducesResponseType(typeof(UsersMinimalResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [HttpGet]
        public async Task<ActionResult<UsersMinimalResponse>> GetUsers()
        {
            var result = await _getAllUsersUseCase.GetUsers();
            return Ok(result);
        }
    }
}
