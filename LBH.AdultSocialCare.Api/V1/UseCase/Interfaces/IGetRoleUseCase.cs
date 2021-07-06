using LBH.AdultSocialCare.Api.V1.Boundary.RoleBoundary.Response;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IGetRoleUseCase
    {
        public Task<RoleResponse> GetAsync(string roleId);
    }
}
