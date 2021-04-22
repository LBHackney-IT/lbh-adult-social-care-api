using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
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
            Role roleEntity = RolesFactory.ToEntity(role);
            roleEntity = await _gateway.UpsertAsync(roleEntity).ConfigureAwait(false);
            if (roleEntity == null) return role = null;
            else
            {
                role = RolesFactory.ToDomain(roleEntity);
            }
            return role;
        }
    }
}
