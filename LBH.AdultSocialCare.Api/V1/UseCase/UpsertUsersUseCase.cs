using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase
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
