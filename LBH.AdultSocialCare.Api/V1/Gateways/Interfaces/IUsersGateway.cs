using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{
    public interface IUsersGateway
    {
        public Task<Users> UpsertAsync(Users users);

        public Task<Users> GetAsync(Guid userId);

        public Task<bool> DeleteAsync(Guid userId);
    }
}
