using BaseApi.V1.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase.Interfaces
{
    public interface IGetAllStatusUseCase
    {
        public Task<IList<Status>> GetAllAsync();
    }
}
