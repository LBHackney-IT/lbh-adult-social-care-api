using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase.Interfaces
{
    public interface IDeleteStatusUseCase
    {
        public Task<bool> DeleteAsync(Guid statusId);
    }
}
