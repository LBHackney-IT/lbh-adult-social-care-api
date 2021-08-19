using LBH.AdultSocialCare.Api.V1.Domain;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IGetUsersUseCase
    {
        public Task<UsersResponse> GetAsync(Guid userId);
    }
}
