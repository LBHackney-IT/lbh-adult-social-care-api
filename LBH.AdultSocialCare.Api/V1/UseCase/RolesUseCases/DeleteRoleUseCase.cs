using System;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.RolesUseCases
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
