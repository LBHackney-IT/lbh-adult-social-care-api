using BaseApi.V1.Domain;
using System;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase.Interfaces
{
    public interface IGetStatusUseCase
    {
        public Task<StatusDomain> GetAsync(Guid statusId);
    }
}
