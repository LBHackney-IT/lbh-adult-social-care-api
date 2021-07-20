using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.RoleDomains;
using LBH.AdultSocialCare.Api.V1.Domain.UserDomains;
using LBH.AdultSocialCare.Api.V1.Services.Auth;
using LBH.AdultSocialCare.Api.V1.UseCase.AuthUseCases.Interfaces;
using System.Net;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.AuthUseCases.Concrete
{
    public class AuthUseCase : IAuthUseCase
    {
        private readonly IAuthenticationManager _authManager;

        public AuthUseCase(IAuthenticationManager authManager)
        {
            _authManager = authManager;
        }

        public async Task<bool> AssignRolesToUserUseCase(AssignRolesToUserDomain assignRolesToUserDomain)
        {
            var res = await _authManager
                .AssignRolesToUser(assignRolesToUserDomain.UserId, assignRolesToUserDomain.Roles).ConfigureAwait(false);

            return res;
        }

        public async Task<TokenResponse> GoogleAuthenticateWithObjectUseCase(HackneyTokenDomain hackneyTokenDomain)
        {
            var validToken = _authManager.ValidateHackneyJwtToken(hackneyTokenDomain);

            // Check if user exists. Not? Create
            var userDomain = await _authManager.GetOrCreateUser(validToken).ConfigureAwait(false);

            // Create token and return to  user
            if (!await _authManager.ValidateUser(userDomain.Email).ConfigureAwait(false))
            {
                throw new ApiException("Authentication failed. Wrong user name or password.", (int) HttpStatusCode.Unauthorized);
            }

            var res = new TokenResponse { Token = await _authManager.CreateToken().ConfigureAwait(false) };

            return res;
        }

        public async Task<TokenResponse> GoogleAuthenticateUseCase(string hackneyToken)
        {
            var validToken = _authManager.ValidateHackneyJwtToken(hackneyToken);

            // Check if user exists. Not? Create
            var userDomain = await _authManager.GetOrCreateUser(validToken).ConfigureAwait(false);

            // Create token and return to  user
            if (!await _authManager.ValidateUser(userDomain.Email).ConfigureAwait(false))
            {
                throw new ApiException("Authentication failed. Wrong user name or password.", (int) HttpStatusCode.Unauthorized);
            }

            var res = new TokenResponse { Token = await _authManager.CreateToken().ConfigureAwait(false) };

            return res;
        }

        public async Task<TokenResponse> LoginWithUsernameAndPasswordUseCase(string userName, string password)
        {
            if (!await _authManager.ValidateUser(userName, password).ConfigureAwait(false))
            {
                throw new ApiException("Authentication failed. Wrong user name or password.", (int) HttpStatusCode.Unauthorized);
            }

            var res = new TokenResponse { Token = await _authManager.CreateToken().ConfigureAwait(false) };

            return res;
        }
    }
}