using LBH.AdultSocialCare.Api.V1.Domain;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{

    public interface IHomeCarePackageSlotsGateway
    {

        public Task<HomeCarePackageSlotListDomain> UpsertAsync(HomeCarePackageSlotListDomain homeCarePackageSlotListList);

        public Task<bool> DeleteAsync(Guid homeCarePackageId);

    }

}
