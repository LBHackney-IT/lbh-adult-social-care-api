using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
{
    public class GetUsersUseCase : IGetUsersUseCase
    {
        private readonly IUsersGateway _gateway;
        public GetUsersUseCase(IUsersGateway usersGateway)
        {
            _gateway = usersGateway;
        }
        public async Task<UsersDomain> GetAsync(Guid userId)
        {
            var usersEntity = await _gateway.GetAsync(userId).ConfigureAwait(false);
            return UserFactory.ToDomain(usersEntity);
        }
    }
}
