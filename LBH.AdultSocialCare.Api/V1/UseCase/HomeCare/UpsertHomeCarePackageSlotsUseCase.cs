using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare
{

    public class UpsertHomeCarePackageSlotsUseCase : IUpsertHomeCarePackageSlotsUseCase
    {

        private readonly IHomeCarePackageSlotsGateway _gateway;

        public UpsertHomeCarePackageSlotsUseCase(IHomeCarePackageSlotsGateway homeCarePackageSlotsGateway)
        {
            _gateway = homeCarePackageSlotsGateway;
        }

        public async Task<HomeCarePackageSlotListDomain> ExecuteAsync(
            HomeCarePackageSlotListDomain homeCarePackageSlotList)
        {
            return await _gateway.UpsertAsync(homeCarePackageSlotList).ConfigureAwait(false);
        }

    }

}
