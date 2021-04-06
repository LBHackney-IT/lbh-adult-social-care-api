using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase.Interfaces
{
    public interface IDeleteServiceUseCase
    {
        public Task<bool> DeleteAsync(Guid serviceId);
    }
}
