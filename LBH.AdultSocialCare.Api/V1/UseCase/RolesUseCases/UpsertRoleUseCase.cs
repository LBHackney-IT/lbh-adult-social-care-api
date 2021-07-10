using LBH.AdultSocialCare.Api.V1.Boundary.RoleBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.RoleDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.RolesUseCases
{
    public class UpsertRoleUseCase : IUpsertRoleUseCase
    {
        private readonly IRolesGateway _gateway;

        public UpsertRoleUseCase(IRolesGateway roleGateway)
        {
            _gateway = roleGateway;
        }

        public async Task<RoleResponse> ExecuteAsync(RoleForCreationDomain roleForCreation)
        {
            var roleDomain = await _gateway.UpsertAsync(roleForCreation.ToEntity()).ConfigureAwait(false);
            return roleDomain?.ToResponse();
        }
    }
}
