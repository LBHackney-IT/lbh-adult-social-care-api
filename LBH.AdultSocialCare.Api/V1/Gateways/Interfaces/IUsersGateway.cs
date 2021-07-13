using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{
    public interface IUsersGateway
    {
        public Task<User> UpsertAsync(User user);

        public Task<User> GetAsync(Guid userId);

        public Task<bool> DeleteAsync(Guid userId);
    }
}
