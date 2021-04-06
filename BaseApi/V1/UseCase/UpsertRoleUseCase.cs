using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.Infrastructure.Entities;
using BaseApi.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
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
            Roles roleEntity = RolesFactory.ToEntity(role);
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
