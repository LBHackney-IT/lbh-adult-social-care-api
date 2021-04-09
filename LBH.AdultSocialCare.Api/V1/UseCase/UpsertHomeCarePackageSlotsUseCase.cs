using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
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
        public async Task<HomeCarePackageSlotsDomain> ExecuteAsync(HomeCarePackageSlotsDomain homeCarePackageSlots)
        {
            HomeCarePackageSlotsList homeCarePackageSlotsEntity = HomeCarePackageSlotsFactory.ToEntity(homeCarePackageSlots);
            homeCarePackageSlotsEntity = await _gateway.UpsertAsync(homeCarePackageSlotsEntity).ConfigureAwait(false);
            if (homeCarePackageSlotsEntity == null) return homeCarePackageSlots = null;
            else
            {
                homeCarePackageSlots = HomeCarePackageSlotsFactory.ToDomain(homeCarePackageSlotsEntity);
            }
            return homeCarePackageSlots;
        }
    }
}
