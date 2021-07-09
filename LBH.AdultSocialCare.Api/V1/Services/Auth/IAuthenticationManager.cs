using LBH.AdultSocialCare.Api.V1.Boundary.UserBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Domain;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Services.Auth
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(string userName, string password = null);

        Task<string> CreateToken();

        public HackneyTokenRequest ValidateHackneyJwtToken(string hackneyToken);

        public HackneyTokenRequest ValidateHackneyJwtToken(HackneyTokenRequest hackneyTokenRequest);

        public Task<UsersDomain> GetOrCreateUser(HackneyTokenRequest hackneyTokenRequest);
    }
}
