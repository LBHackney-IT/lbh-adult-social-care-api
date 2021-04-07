using System;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase.Interfaces
{
    public interface IDeleteClientsUseCase
    {
        public Task<bool> DeleteAsync(Guid clientId);
    }
}
