using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{
    public interface IHomeCarePackageSlotsGateway
    {
        public Task<HomeCarePackageSlotsList> UpsertAsync(HomeCarePackageSlotsList homeCarePackageSlotsList);

        public Task<bool> DeleteAsync(Guid homeCarePackageId);
    }
}
