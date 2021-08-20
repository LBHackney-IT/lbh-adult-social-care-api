using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.RolesUseCases
{
    public class GetAllRoleUseCase : IGetAllRoleUseCase
    {
        private readonly IRolesGateway _gateway;

        public GetAllRoleUseCase(IRolesGateway roleGateway)
        {
            _gateway = roleGateway;
        }

        public async Task<IList<RoleResponse>> GetAllAsync()
        {
            var res = await _gateway.ListAsync().ConfigureAwait(false);
            return res.ToResponse();
        }
    }
}
