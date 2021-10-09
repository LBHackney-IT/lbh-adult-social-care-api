using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Security;

namespace LBH.AdultSocialCare.Api.V1.Services.Auth
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(string userName, string password = null);

        User GetUser();

        Task<string> CreateToken();

        public HackneyTokenDomain ValidateHackneyJwtToken(string hackneyToken);

        public HackneyTokenDomain ValidateHackneyJwtToken(HackneyTokenDomain hackneyTokenDomain);

        public Task<AppUserDomain> GetOrCreateUser(HackneyTokenDomain hackneyTokenDomain);

        Task<bool> AssignRolesToUser(Guid userId, IEnumerable<string> roles);
    }
}
