using System;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase.Interfaces
{
    public interface IDeleteRoleUseCase
    {
        public Task<bool> DeleteAsync(Guid roleId);
    }
}
