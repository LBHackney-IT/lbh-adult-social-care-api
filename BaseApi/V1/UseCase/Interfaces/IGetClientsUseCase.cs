using BaseApi.V1.Domain;
using System;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase.Interfaces
{
    public interface IGetClientsUseCase
    {
        public Task<ClientsDomain> GetAsync(Guid clientId);

    }
}
