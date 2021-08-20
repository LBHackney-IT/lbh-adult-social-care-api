using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Security.Concrete
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
