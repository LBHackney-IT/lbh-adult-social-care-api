using Common.Exceptions.Models;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Services.Auth;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Controllers.Common.UserControllers
{
    [Route("api/v1/auth")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationManager _authManager;
        private readonly IAuthUseCase _authUseCase;

        public AuthenticationController(IAuthenticationManager authManager, IAuthUseCase authUseCase)
        {
            _authManager = authManager;
            _authUseCase = authUseCase;
        }

        /// <summary>
        /// Authenticates the user with username and password.
        /// </summary>
        /// <param name="user">The user request object</param>
        /// <returns>A token if authentication is successful</returns>
        /// <response code="200">Returns token</response>
        /// <response code="404">User not found</response>
        /// <response code="422">If the request object is invalid</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status500InternalServerError)]
        [HttpPost("login")]
        public async Task<ActionResult<TokenResponse>> Authenticate([FromBody] UserForAuthenticationRequest user)
        {
            var res = await _authUseCase.LoginWithUsernameAndPasswordUseCase(user.UserName, user.Password)
                .ConfigureAwait(false);

            return Ok(res);
        }

        /// <summary>
        /// Get claims in token
        /// </summary>
        /// <returns>Token type and name</returns>
        /// <response code="200">Returns claims</response>
        /// <response code="403">If user is not authenticated or authorized</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status500InternalServerError)]
        [HttpGet("claims")]
        [Authorize]
        public IActionResult Privacy()
        {
            var claims = User.Claims
                .Select(c => new { c.Type, c.Value })
                .ToList();
            return Ok(claims);
        }

        /// <summary>
        /// Authenticate using hackney token.
        /// </summary>
        /// <param name="userForAuthenticationRequest">The user authentication request object.</param>
        /// <returns>A token if authentication is successful</returns>
        /// <response code="200">Returns token</response>
        /// <response code="400">User not found and cannot be created</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">User not found</response>
        /// <response code="422">If the request object is invalid</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status500InternalServerError)]
        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleAuthenticate([FromBody] HackneyUserForAuthenticationRequest userForAuthenticationRequest)
        {
            var res = await _authUseCase.GoogleAuthenticateUseCase(userForAuthenticationRequest.HackneyToken)
                .ConfigureAwait(false);

            return Ok(res);
        }


        /// <summary>
        /// Assigns roles to a user.
        /// </summary>
        /// <param name="assignRolesToUserRequest">The assign roles to user request object.</param>
        /// <returns>True if roles are added successfully</returns>
        /// <response code="200">Returns token</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">User not found</response>
        /// <response code="422">If the request object is invalid</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status500InternalServerError)]
        [HttpPost("assign-roles")]
        [AuthorizeRoles(RolesEnum.SuperUser)]
        public async Task<IActionResult> AssignRolesToUser([FromBody] AssignRolesToUserRequest assignRolesToUserRequest)
        {
            var res = await _authUseCase.AssignRolesToUserUseCase(assignRolesToUserRequest.ToDomain()).ConfigureAwait(false);

            return Ok(res);
        }
    }
}
