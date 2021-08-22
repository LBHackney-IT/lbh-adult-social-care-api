using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Security;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces
{
    public interface IAuthUseCase
    {
        Task<bool> AssignRolesToUserUseCase(AssignRolesToUserDomain assignRolesToUserDomain);

        Task<TokenResponse> GoogleAuthenticateWithObjectUseCase(HackneyTokenDomain hackneyTokenDomain);

        Task<TokenResponse> GoogleAuthenticateUseCase(string hackneyToken);

        Task<TokenResponse> LoginWithUsernameAndPasswordUseCase(string userName, string password);
    }
}
