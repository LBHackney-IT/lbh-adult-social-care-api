using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces
{
    public interface IGetUsersUseCase
    {
        public Task<UsersResponse> GetAsync(Guid userId);
    }
}
