using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.UserUseCases
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
