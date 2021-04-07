using BaseApi.V1.Domain;
using System;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase.Interfaces
{
    public interface IGetUsersUseCase
    {
        public Task<UsersDomain> GetAsync(Guid userId);
    }
}
