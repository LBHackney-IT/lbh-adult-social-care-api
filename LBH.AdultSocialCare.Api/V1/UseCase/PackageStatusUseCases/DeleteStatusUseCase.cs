using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.PackageStatusUseCases
{
    public class DeleteStatusUseCase : IDeleteStatusUseCase
    {
        private readonly IStatusGateway _gateway;
        public DeleteStatusUseCase(IStatusGateway roleGateway)
        {
            _gateway = roleGateway;
        }

        public async Task<bool> DeleteAsync(int statusId)
        {
            return await _gateway.DeleteAsync(statusId).ConfigureAwait(false);
        }
    }
}
