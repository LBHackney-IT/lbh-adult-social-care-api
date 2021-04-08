using BaseApi.V1.Domain;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase.Interfaces
{
    public interface IUpsertUsersUseCase
    {
        public Task<UsersDomain> ExecuteAsync(UsersDomain users);
    }
}
