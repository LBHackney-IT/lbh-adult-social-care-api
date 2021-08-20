using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.PackageUseCases
{
    public class DeletePackageUseCase : IDeletePackageUseCase
    {
        private readonly IPackageGateway _gateway;
        public DeletePackageUseCase(IPackageGateway packageGateway)
        {
            _gateway = packageGateway;
        }

        public async Task<bool> DeleteAsync(int packageId)
        {
            return await _gateway.DeleteAsync(packageId).ConfigureAwait(false);
        }
    }
}
