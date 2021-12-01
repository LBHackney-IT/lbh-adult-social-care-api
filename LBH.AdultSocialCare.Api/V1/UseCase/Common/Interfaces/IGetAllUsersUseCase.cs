using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IGetAllUsersUseCase
    {
        Task<IEnumerable<UsersMinimalResponse>> GetUsersWithRole(RolesEnum rolesEnum);
        Task<IEnumerable<UsersMinimalResponse>> GetUsers();
    }
}
