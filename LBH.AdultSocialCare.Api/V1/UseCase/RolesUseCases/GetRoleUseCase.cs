using System;
using LBH.AdultSocialCare.Api.V1.Boundary.RoleBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.RolesUseCases
{
    public class GetRoleUseCase : IGetRoleUseCase
    {
        private readonly IRolesGateway _gateway;

        public GetRoleUseCase(IRolesGateway roleGateway)
        {
            _gateway = roleGateway;
        }

        public async Task<RoleResponse> GetAsync(Guid roleId)
        {
            var roleEntity = await _gateway.GetAsync(roleId).ConfigureAwait(false);
            return roleEntity?.ToResponse();
        }
    }
}
