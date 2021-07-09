using LBH.AdultSocialCare.Api.V1.Domain.RoleDomains;
using LBH.AdultSocialCare.Api.V1.Services.Auth;
using LBH.AdultSocialCare.Api.V1.UseCase.AuthUseCases.Interfaces;
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
    }
}
