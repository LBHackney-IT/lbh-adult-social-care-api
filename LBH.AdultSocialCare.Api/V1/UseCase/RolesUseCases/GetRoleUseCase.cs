using System;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces;

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
