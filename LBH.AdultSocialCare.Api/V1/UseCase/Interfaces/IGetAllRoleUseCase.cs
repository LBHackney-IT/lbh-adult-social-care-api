using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.RoleBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IGetAllRoleUseCase
    {
        public Task<IList<RoleResponse>> GetAllAsync();
    }
}
