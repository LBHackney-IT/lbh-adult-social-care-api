using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{
    public interface IPackageGateway
    {
        public Task<Package> UpsertAsync(Package package);

        public Task<Package> GetAsync(int packageId);

        public Task<IList<Package>> ListAsync();

        public Task<bool> DeleteAsync(int packageId);
    }
}
