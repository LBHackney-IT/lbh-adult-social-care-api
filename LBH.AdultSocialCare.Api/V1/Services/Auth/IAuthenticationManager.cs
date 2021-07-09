using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Domain.UserDomains;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Services.Auth
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(string userName, string password = null);

        Task<string> CreateToken();

        public HackneyTokenDomain ValidateHackneyJwtToken(string hackneyToken);

        public HackneyTokenDomain ValidateHackneyJwtToken(HackneyTokenDomain hackneyTokenDomain);

        public Task<UsersDomain> GetOrCreateUser(HackneyTokenDomain hackneyTokenDomain);

        Task<bool> AssignRolesToUser(Guid userId, IEnumerable<string> roles);
    }
}
