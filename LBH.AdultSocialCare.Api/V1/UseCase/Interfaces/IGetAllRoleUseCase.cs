using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IGetAllRoleUseCase
    {
        public Task<IList<Role>> GetAllAsync();
    }
}
