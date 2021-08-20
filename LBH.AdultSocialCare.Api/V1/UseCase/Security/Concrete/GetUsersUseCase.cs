using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Security.Concrete
{
    public class GetUsersUseCase : IGetUsersUseCase
    {
        private readonly IUsersGateway _gateway;

        public GetUsersUseCase(IUsersGateway usersGateway)
        {
            _gateway = usersGateway;
        }

        public async Task<UsersResponse> GetAsync(Guid userId)
        {
            var usersEntity = await _gateway.GetAsync(userId).ConfigureAwait(false);
            return usersEntity?.ToResponse();
        }
    }
}
