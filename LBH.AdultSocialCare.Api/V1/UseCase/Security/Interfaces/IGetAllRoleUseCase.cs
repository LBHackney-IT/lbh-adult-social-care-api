using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces
{
    public interface IGetAllRoleUseCase
    {
        public Task<IList<RoleResponse>> GetAllAsync();
    }
}
