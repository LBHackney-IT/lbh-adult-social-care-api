using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.UserBoundary.Request;

namespace LBH.AdultSocialCare.Api.V1.Services.Auth
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(string userName, string password);

        Task<string> CreateToken();

        public HackneyTokenRequest ValidateHackneyJwtToken(string hackneyToken);
    }
}
