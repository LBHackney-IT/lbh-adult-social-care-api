using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Security.Concrete
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
