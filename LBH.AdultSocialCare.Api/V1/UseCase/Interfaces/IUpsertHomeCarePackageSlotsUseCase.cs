using LBH.AdultSocialCare.Api.V1.Domain;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IUpsertHomeCarePackageSlotsUseCase
    {
        public Task<HomeCarePackageSlotListDomain> ExecuteAsync(HomeCarePackageSlotListDomain homeCarePackageSlotList);
    }
}
