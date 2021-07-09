using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.RoleBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.UserBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Services.Auth;
using LBH.AdultSocialCare.Api.V1.UseCase.AuthUseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Controllers.UserControllers
{
    [Route("api/v1/auth")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationManager _authManager;
        private readonly IAuthUseCase _authUseCase;

        public AuthenticationController(IAuthenticationManager authManager, IAuthUseCase authUseCase)
        {
            _authManager = authManager;
            _authUseCase = authUseCase;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationRequest user)
        {
            if (!await _authManager.ValidateUser(user.UserName, user.Password).ConfigureAwait(false))
            {
                throw new ApiException("Authentication failed. Wrong user name or password.", (int) HttpStatusCode.Unauthorized);
            }

            return Ok(new { Token = await _authManager.CreateToken().ConfigureAwait(false) });
        }

        [HttpGet("claims")]
        [AuthorizeRoles(RolesEnum.Administrator)]
        public IActionResult Privacy()
        {
            var claims = User.Claims
                .Select(c => new { c.Type, c.Value })
                .ToList();
            return Ok(claims);
        }

        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleAuthenticate([FromBody] HackneyUserForAuthenticationRequest userForAuthenticationRequest)
        {
            var validToken = _authManager.ValidateHackneyJwtToken(userForAuthenticationRequest.HackneyToken);

            // Check if user exists. Not? Create
            var userDomain = await _authManager.GetOrCreateUser(validToken).ConfigureAwait(false);

            // Create token and return to  user
            if (!await _authManager.ValidateUser(userDomain.Email).ConfigureAwait(false))
            {
                throw new ApiException("Authentication failed. Wrong user name or password.", (int) HttpStatusCode.Unauthorized);
            }

            return Ok(new { Token = await _authManager.CreateToken().ConfigureAwait(false) });
        }

        [HttpPost("google-login-v2")]
        public async Task<IActionResult> GoogleAuthenticateWithObject([FromBody] HackneyTokenRequest hackneyTokenRequest)
        {
            var validToken = _authManager.ValidateHackneyJwtToken(hackneyTokenRequest);

            // Check if user exists. Not? Create
            var userDomain = await _authManager.GetOrCreateUser(validToken).ConfigureAwait(false);

            // Create token and return to  user
            if (!await _authManager.ValidateUser(userDomain.Email).ConfigureAwait(false))
            {
                throw new ApiException("Authentication failed. Wrong user name or password.", (int) HttpStatusCode.Unauthorized);
            }

            return Ok(new { Token = await _authManager.CreateToken().ConfigureAwait(false) });
        }

        [HttpPost("assign-roles")]
        [AuthorizeRoles(RolesEnum.SuperAdministrator)]
        public async Task<IActionResult> AssignRolesToUser([FromBody] AssignRolesToUserRequest assignRolesToUserRequest)
        {
            var res = await _authUseCase.AssignRolesToUserUseCase(assignRolesToUserRequest.ToDomain()).ConfigureAwait(false);

            return Ok(res);
        }
    }
}
