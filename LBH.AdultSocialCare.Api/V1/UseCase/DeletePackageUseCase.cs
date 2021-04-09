using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase
{
    public class DeletePackageUseCase : IDeletePackageUseCase
    {
        private readonly IPackageGateway _gateway;
        public DeletePackageUseCase(IPackageGateway packageGateway)
        {
            _gateway = packageGateway;
        }

        public async Task<bool> DeleteAsync(Guid packageId)
        {
            return await _gateway.DeleteAsync(packageId).ConfigureAwait(false);
        }
    }
}
