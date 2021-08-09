using LBH.AdultSocialCare.Api.V1.Domain;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCareDomains;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{

    public interface IHomeCarePackageSlotsGateway
    {

        public Task<HomeCarePackageSlotListDomain> UpsertAsync(HomeCarePackageSlotListDomain homeCarePackageSlotListList);
    }

}
