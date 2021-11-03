using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Clients.Concrete
{
    public class GetClientsUseCase : IGetClientsUseCase
    {
        private readonly IClientsGateway _gateway;

        public GetClientsUseCase(IClientsGateway usersGateway)
        {
            _gateway = usersGateway;
        }

        public async Task<ServiceUserDomain> GetAsync(Guid clientId)
        {
            var usersEntity = await _gateway.GetAsync(clientId).ConfigureAwait(false);
            return usersEntity?.ToDomain();
        }
    }
}
