using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.Infrastructure.Entities;
using BaseApi.V1.UseCase.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
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
