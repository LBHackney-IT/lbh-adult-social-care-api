using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.PackageUseCases
{
    public class GetPackageUseCase : IGetPackageUseCase
    {
        private readonly IPackageGateway _gateway;

        public GetPackageUseCase(IPackageGateway packageGateway)
        {
            _gateway = packageGateway;
        }

        public async Task<PackageDomain> GetAsync(int packageId)
        {
            var packageEntity = await _gateway.GetAsync(packageId).ConfigureAwait(false);
            return packageEntity?.ToDomain();
        }
    }
}
