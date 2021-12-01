using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces
{
    public interface IAuthUseCase
    {
        Task<TokenResponse> GoogleAuthenticateUseCase(string hackneyToken);
    }
}
