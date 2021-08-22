using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Security;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces
{
    public interface IUpsertRoleUseCase
    {
        public Task<RoleResponse> ExecuteAsync(RoleForCreationDomain roleForCreation);
    }
}
