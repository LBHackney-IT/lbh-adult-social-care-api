using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.ClientDomains;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ClientsUseCases.Interfaces
{
    public interface IGetClientsUseCase
    {
        public Task<ClientsDomain> GetAsync(Guid clientId);
    }
}
