using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class GetPackageTypeUseCase : IGetPackageTypeUseCase
    {
        private readonly IPackageGateway _gateway;

        public GetPackageTypeUseCase(IPackageGateway packageGateway)
        {
            _gateway = packageGateway;
        }

        public async Task<IList<Package>> GetAllAsync()
        {
            return await _gateway.ListAsync().ConfigureAwait(false);
        }

        public async Task<PackageTypeDomain> GetSingleAsync(int packageTypeId)
        {
            var packageEntity = await _gateway.GetAsync(packageTypeId).ConfigureAwait(false);
            return packageEntity?.ToDomain();
        }
    }
}
