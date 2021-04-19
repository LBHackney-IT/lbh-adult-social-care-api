using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.PackageUseCases
{
    public class UpsertPackageUseCase : IUpsertPackageUseCase
    {
        private readonly IPackageGateway _gateway;
        public UpsertPackageUseCase(IPackageGateway packageGateway)
        {
            _gateway = packageGateway;
        }

        public async Task<PackageDomain> ExecuteAsync(PackageDomain package)
        {
            Package packageEntity = PackageFactory.ToEntity(package);
            packageEntity = await _gateway.UpsertAsync(packageEntity).ConfigureAwait(false);
            if (packageEntity == null) return package = null;
            else
            {
                package = PackageFactory.ToDomain(packageEntity);
            }
            return package;
        }
    }
}