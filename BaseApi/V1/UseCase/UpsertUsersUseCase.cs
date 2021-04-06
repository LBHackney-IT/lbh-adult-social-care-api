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
    public class UpsertUsersUseCase : IUpsertUsersUseCase
    {
        private readonly IUsersGateway _gateway;
        public UpsertUsersUseCase(IUsersGateway usersGateway)
        {
            _gateway = usersGateway;
        }

        public async Task<UsersDomain> ExecuteAsync(UsersDomain users)
        {
            Users userEntity = UserFactory.ToEntity(users);
            userEntity = await _gateway.UpsertAsync(userEntity).ConfigureAwait(false);
            if (userEntity == null) return users = null;
            else
            {
                users = UserFactory.ToDomain(userEntity);
            }
            return users;
        }
    }
}
