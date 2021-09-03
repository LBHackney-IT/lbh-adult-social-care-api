using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common.UserControllers
{
    [Route("api/v1/users")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class UserController : BaseController
    {
        private readonly IRegisterUserUseCase _registerUserUseCase;
        private readonly IGetUsersUseCase _getUsersUseCase;
        private readonly IDeleteUsersUseCase _deleteUsersUseCase;

        public UserController(IRegisterUserUseCase registerUserUseCase,
            IGetUsersUseCase getUsersUseCase,
            IDeleteUsersUseCase deleteUsersUseCase)
        {
            _registerUserUseCase = registerUserUseCase;
            _getUsersUseCase = getUsersUseCase;
            _deleteUsersUseCase = deleteUsersUseCase;
        }

        /// <summary>Creates the specified users request.</summary>
        /// <param name="usersRequest">The users request.</param>
        /// <returns>The created User Response model</returns>
        [ProducesResponseType(typeof(UsersResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UsersResponse>> RegisterUser([FromBody] UserForRegistrationRequest usersRequest)
        {
            var userForRegistrationDomain = usersRequest.ToDomain();
            var res = await _registerUserUseCase.RegisterUserAsync(userForRegistrationDomain).ConfigureAwait(false);
            return Ok(res);
        }

        /// <summary>Gets the specified user identifier.</summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The User Response model</returns>
        [ProducesResponseType(typeof(UsersResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpGet]
        [Route("{userId}")]
        public async Task<ActionResult<UsersResponse>> Get(Guid userId)
        {
            var res = await _getUsersUseCase.GetAsync(userId).ConfigureAwait(false);
            return Ok(res);
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpDelete]
        [Route("{userId}")]
        public async Task<ActionResult<bool>> Delete(Guid userId)
        {
            return await _deleteUsersUseCase.DeleteAsync(userId).ConfigureAwait(false);
        }
    }
}
