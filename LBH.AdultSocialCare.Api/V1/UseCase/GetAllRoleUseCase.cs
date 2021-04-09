using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase
{
    public class GetAllRoleUseCase : IGetAllRoleUseCase
    {
        private readonly IRolesGateway _gateway;
        public GetAllRoleUseCase(IRolesGateway roleGateway)
        {
            _gateway = roleGateway;
        }
        public async Task<IList<Roles>> GetAllAsync()
        {
            return await _gateway.ListAsync().ConfigureAwait(false);
        }
    }
}
