using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
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
