using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Security;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{
    public interface IUsersGateway
    {
        public Task<UsersDomain> GetAsync(Guid userId);

        public Task<bool> DeleteAsync(Guid userId);
    }
}
