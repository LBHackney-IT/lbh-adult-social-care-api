using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class UpsertPackageUseCase : IUpsertPackageUseCase
    {
        private readonly IPackageGateway _gateway;

        public UpsertPackageUseCase(IPackageGateway packageGateway)
        {
            _gateway = packageGateway;
        }

        public async Task<PackageTypeDomain> ExecuteAsync(PackageTypeDomain packageType)
        {
            Package packageEntity = packageType.ToEntity();
            packageEntity = await _gateway.UpsertAsync(packageEntity).ConfigureAwait(false);
            return packageEntity?.ToDomain();
        }
    }
}
