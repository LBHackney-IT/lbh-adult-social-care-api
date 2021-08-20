using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.UserUseCases
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
