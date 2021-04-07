using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
{
    public class GetRoleUseCase : IGetRoleUseCase
    {
        private readonly IRolesGateway _gateway;
        public GetRoleUseCase(IRolesGateway roleGateway)
        {
            _gateway = roleGateway;
        }

        public async Task<RolesDomain> GetAsync(Guid roleId)
        {
            var roleEntity = await _gateway.GetAsync(roleId).ConfigureAwait(false);
            return RolesFactory.ToDomain(roleEntity);
        }
    }
}
