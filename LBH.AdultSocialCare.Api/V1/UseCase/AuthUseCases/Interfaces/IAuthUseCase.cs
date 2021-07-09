using LBH.AdultSocialCare.Api.V1.Domain.RoleDomains;
using LBH.AdultSocialCare.Api.V1.Domain.UserDomains;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.AuthUseCases.Interfaces
{
    public interface IAuthUseCase
    {
        Task<bool> AssignRolesToUserUseCase(AssignRolesToUserDomain assignRolesToUserDomain);

        Task<TokenResponse> GoogleAuthenticateWithObjectUseCase(HackneyTokenDomain hackneyTokenDomain);

        Task<TokenResponse> GoogleAuthenticateUseCase(string hackneyToken);

        Task<TokenResponse> LoginWithUsernameAndPasswordUseCase(string userName, string password);
    }
}
