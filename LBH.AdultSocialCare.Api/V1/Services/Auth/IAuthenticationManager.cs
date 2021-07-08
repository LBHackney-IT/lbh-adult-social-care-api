using LBH.AdultSocialCare.Api.V1.Boundary.UserBoundary.Request;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain;

namespace LBH.AdultSocialCare.Api.V1.Services.Auth
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(string userName, string password = null);

        Task<string> CreateToken();

        public HackneyTokenRequest ValidateHackneyJwtToken(string hackneyToken);

        public Task<UsersDomain> GetOrCreateUser(HackneyTokenRequest hackneyTokenRequest);
    }
}
