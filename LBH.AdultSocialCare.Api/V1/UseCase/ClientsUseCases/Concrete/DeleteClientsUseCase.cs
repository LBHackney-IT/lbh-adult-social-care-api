using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ClientsUseCases.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ClientsUseCases.Concrete
{
    public class DeleteClientsUseCase : IDeleteClientsUseCase
    {
        private readonly IClientsGateway _gateway;
        public DeleteClientsUseCase(IClientsGateway usersGateway)
        {
            _gateway = usersGateway;
        }

        public async Task<bool> DeleteAsync(Guid clientId)
        {
            return await _gateway.DeleteAsync(clientId).ConfigureAwait(false);
        }
    }
}
