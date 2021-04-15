using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase
{
    public class ChangeStatusHomeCarePackageUseCase : IChangeStatusHomeCarePackageUseCase
    {
        private readonly IHomeCarePackageGateway _gateway;
        public ChangeStatusHomeCarePackageUseCase(IHomeCarePackageGateway homeCarePackageGateway)
        {
            _gateway = homeCarePackageGateway;
        }

        public async Task<HomeCarePackageDomain> UpdateAsync(HomeCarePackageDomain homeCarePackage)
        {
            var homeCarePackageEntity = HomeCarePackageFactory.ToEntity(homeCarePackage);
            homeCarePackageEntity = await _gateway.ChangeStatusAsync(homeCarePackageEntity).ConfigureAwait(false);
            if (homeCarePackageEntity == null) return homeCarePackage = null;
            else
            {
                homeCarePackage = HomeCarePackageFactory.ToDomain(homeCarePackageEntity);
            }
            return homeCarePackage;
        }
    }
}
