using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Concrete
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
            var homeCarePackageEntity = homeCarePackage.ToEntity();
            homeCarePackageEntity = await _gateway.UpsertAsync(homeCarePackageEntity).ConfigureAwait(false);
            return homeCarePackageEntity?.ToDomain();
        }
    }
}
