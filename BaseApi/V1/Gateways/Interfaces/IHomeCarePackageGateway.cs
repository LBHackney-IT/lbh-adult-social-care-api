using BaseApi.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseApi.V1.Gateways.Interfaces
{
    public interface IHomeCarePackageGateway
    {
        public Task<HomeCarePackage> UpsertAsync(HomeCarePackage homeCarePackage);

        public Task<HomeCarePackage> ChangeStatusAsync(HomeCarePackage homeCarePackage);

        public Task<HomeCarePackage> GetAsync(Guid homeCarePackageId);

        public Task<IList<HomeCarePackage>> ListAsync();
    }
}
