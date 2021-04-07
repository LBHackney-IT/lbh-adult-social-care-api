using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
{
    public class DeleteUsersUseCase : IDeleteUsersUseCase
    {
        private readonly IUsersGateway _gateway;
        public DeleteUsersUseCase(IUsersGateway usersGateway)
        {
            _gateway = usersGateway;
        }

        public async Task<bool> DeleteAsync(Guid userId)
        {
            return await _gateway.DeleteAsync(userId).ConfigureAwait(false);
        }
    }
}
