using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Security.Concrete
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
