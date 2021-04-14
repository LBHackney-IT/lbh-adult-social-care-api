using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase
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
