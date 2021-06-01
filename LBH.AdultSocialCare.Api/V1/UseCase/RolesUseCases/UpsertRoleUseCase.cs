using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.RolesUseCases
{
    public class UpsertRoleUseCase : IUpsertRoleUseCase
    {
        private readonly IRolesGateway _gateway;

        public UpsertRoleUseCase(IRolesGateway roleGateway)
        {
            _gateway = roleGateway;
        }

        public async Task<RolesDomain> ExecuteAsync(RolesDomain role)
        {
            var roleEntity = role.ToEntity();
            roleEntity = await _gateway.UpsertAsync(roleEntity).ConfigureAwait(false);
            return roleEntity?.ToDomain();
        }
    }
}
