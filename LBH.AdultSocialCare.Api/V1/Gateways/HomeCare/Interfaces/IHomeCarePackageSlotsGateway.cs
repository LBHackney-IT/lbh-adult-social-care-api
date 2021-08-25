using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces
{

    public interface IHomeCarePackageSlotsGateway
    {

        public Task<HomeCarePackageSlotListDomain> UpsertAsync(HomeCarePackageSlotListDomain homeCarePackageSlotListList);
    }

}