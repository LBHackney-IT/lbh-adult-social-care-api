using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Clients.Concrete
{
    public class UpsertClientsUseCase : IUpsertClientsUseCase
    {
        private readonly IClientsGateway _gateway;

        public UpsertClientsUseCase(IClientsGateway usersGateway)
        {
            _gateway = usersGateway;
        }

        public async Task<ServiceUserDomain> ExecuteAsync(ServiceUserDomain serviceUser)
        {
            var clientEntity = serviceUser.ToEntity();
            clientEntity = await _gateway.UpsertAsync(clientEntity).ConfigureAwait(false);

            if (clientEntity == null)
            {
                return null;
            }

            serviceUser = clientEntity.ToDomain();

            return serviceUser;
        }
    }
}
