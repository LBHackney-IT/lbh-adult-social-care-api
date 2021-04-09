using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{
    public interface IServiceGateway
    {
        public Task<PackageServices> UpsertAsync(PackageServices service);

        public Task<PackageServices> GetAsync(Guid serviceId);

        public Task<IList<PackageServices>> ListAsync();

        public Task<bool> DeleteAsync(Guid serviceId);
    }
}
