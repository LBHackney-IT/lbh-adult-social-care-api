using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.RolesUseCases
{
    public class GetRoleUseCase : IGetRoleUseCase
    {
        private readonly IRolesGateway _gateway;
        public GetRoleUseCase(IRolesGateway roleGateway)
        {
            _gateway = roleGateway;
        }

        public async Task<RolesDomain> GetAsync(int roleId)
        {
            var roleEntity = await _gateway.GetAsync(roleId).ConfigureAwait(false);
            return RolesFactory.ToDomain(roleEntity);
        }
    }
}
