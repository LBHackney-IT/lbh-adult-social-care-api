using LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Security.Concrete
{
    public class DeleteRoleUseCase : IDeleteRoleUseCase
    {
        private readonly IRolesGateway _gateway;

        public DeleteRoleUseCase(IRolesGateway roleGateway)
        {
            _gateway = roleGateway;
        }

        public async Task<bool> DeleteAsync(Guid roleId)
        {
            return await _gateway.DeleteAsync(roleId).ConfigureAwait(false);
        }
    }
}
