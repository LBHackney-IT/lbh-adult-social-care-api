using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.RolesUseCases
{
    public class DeleteRoleUseCase : IDeleteRoleUseCase
    {
        private readonly IRolesGateway _gateway;

        public DeleteRoleUseCase(IRolesGateway roleGateway)
        {
            _gateway = roleGateway;
        }

        public async Task<bool> DeleteAsync(string roleId)
        {
            return await _gateway.DeleteAsync(roleId).ConfigureAwait(false);
        }
    }
}
