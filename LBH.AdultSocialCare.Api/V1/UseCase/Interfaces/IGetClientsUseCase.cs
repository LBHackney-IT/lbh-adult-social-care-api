using LBH.AdultSocialCare.Api.V1.Domain;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IGetClientsUseCase
    {
        public Task<ClientsDomain> GetAsync(Guid clientId);

    }
}
