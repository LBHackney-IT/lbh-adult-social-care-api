using BaseApi.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.Gateways.Interfaces
{
    public interface IPackageGateway
    {
        public Task<Package> UpsertAsync(Package package);

        public Task<Package> GetAsync(Guid packageId);

        public Task<IList<Package>> ListAsync();

        public Task<bool> DeleteAsync(Guid packageId);
    }
}
