using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces
{
    public interface IGetClientsUseCase
    {
        public Task<ServiceUserDomain> GetAsync(Guid clientId);
    }
}
