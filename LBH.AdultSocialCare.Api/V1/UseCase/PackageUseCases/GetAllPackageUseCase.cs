using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.PackageUseCases
{
    public class GetAllPackageUseCase : IGetAllPackageUseCase
    {
        private readonly IPackageGateway _gateway;
        public GetAllPackageUseCase(IPackageGateway packageGateway)
        {
            _gateway = packageGateway;
        }

        public async Task<IList<Package>> GetAllAsync()
        {
            return await _gateway.ListAsync().ConfigureAwait(false);
        }
    }
}
