using BaseApi.V1.Infrastructure.Entities;
using System;
using System.Threading.Tasks;

namespace BaseApi.V1.Gateways.Interfaces
{
    public interface IHomeCarePackageSlotsGateway
    {
        public Task<HomeCarePackageSlotsList> UpsertAsync(HomeCarePackageSlotsList homeCarePackageSlotsList);

        public Task<bool> DeleteAsync(Guid homeCarePackageId);
    }
}
