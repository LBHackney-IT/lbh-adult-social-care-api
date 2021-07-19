using LBH.AdultSocialCare.Api.V1.Boundary.RoleBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.RoleDomains;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IUpsertRoleUseCase
    {
        public Task<RoleResponse> ExecuteAsync(RoleForCreationDomain roleForCreation);
    }
}
