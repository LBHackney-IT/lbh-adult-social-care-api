using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces
{
    public interface IAuthUseCase
    {
        Task<bool> AssignRolesToUserUseCase(AssignRolesToUserDomain assignRolesToUserDomain);

        Task<TokenResponse> GoogleAuthenticateWithObjectUseCase(HackneyTokenDomain hackneyTokenDomain);

        Task<TokenResponse> GoogleAuthenticateUseCase(string hackneyToken);
    }
}
