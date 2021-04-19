using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ClientsUseCases
{
    public class GetClientsUseCase : IGetClientsUseCase
    {
        private readonly IClientsGateway _gateway;
        public GetClientsUseCase(IClientsGateway usersGateway)
        {
            _gateway = usersGateway;
        }

        public async Task<ClientsDomain> GetAsync(Guid clientId)
        {
            var usersEntity = await _gateway.GetAsync(clientId).ConfigureAwait(false);
            return ClientsFactory.ToDomain(usersEntity);
        }
    }
}
