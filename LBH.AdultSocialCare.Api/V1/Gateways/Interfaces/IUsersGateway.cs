using LBH.AdultSocialCare.Api.V1.Domain;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{
    public interface IUsersGateway
    {
        public Task<UsersDomain> GetAsync(Guid userId);

        public Task<bool> DeleteAsync(Guid userId);
    }
}
