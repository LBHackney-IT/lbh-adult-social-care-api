using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Security.Concrete
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
