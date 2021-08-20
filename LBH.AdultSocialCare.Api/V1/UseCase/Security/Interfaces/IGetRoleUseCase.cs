using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces
{
    public interface IGetRoleUseCase
    {
        public Task<RoleResponse> GetAsync(Guid roleId);
    }
}
