using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase
{
    public class DeleteServiceUseCase : IDeleteServiceUseCase
    {
        private readonly IServiceGateway _gateway;
        public DeleteServiceUseCase(IServiceGateway serviceGateway)
        {
            _gateway = serviceGateway;
        }
        public async Task<bool> DeleteAsync(Guid serviceId)
        {
            return await _gateway.DeleteAsync(serviceId).ConfigureAwait(false);
        }
    }
}
