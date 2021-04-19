using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare
{
    public class UpsertHomeCarePackageUseCase : IUpsertHomeCarePackageUseCase
    {
        private readonly IHomeCarePackageGateway _gateway;
        public UpsertHomeCarePackageUseCase(IHomeCarePackageGateway homecarePackageGateway)
        {
            _gateway = homecarePackageGateway;
        }
        public async Task<HomeCarePackageDomain> ExecuteAsync(HomeCarePackageDomain homeCarePackage)
        {
            var homeCarePackageEntity = HomeCarePackageFactory.ToEntity(homeCarePackage);
            homeCarePackageEntity = await _gateway.UpsertAsync(homeCarePackageEntity).ConfigureAwait(false);
            if (homeCarePackageEntity == null) return homeCarePackage = null;
            else
            {
                homeCarePackage = HomeCarePackageFactory.ToDomain(homeCarePackageEntity);
            }
            return homeCarePackage;
        }
    }
}
