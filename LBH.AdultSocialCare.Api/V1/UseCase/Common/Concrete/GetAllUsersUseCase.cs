using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class GetAllUsersUseCase : IGetAllUsersUseCase
    {
        private readonly IUsersGateway _usersGateway;

        public GetAllUsersUseCase(IUsersGateway usersGateway)
        {
            _usersGateway = usersGateway;
        }

        public async Task<IEnumerable<UsersMinimalResponse>> GetUsersWithRole(RolesEnum rolesEnum)
        {
            var result = await _usersGateway.GetUsers(rolesEnum);
            return result.ToResponse();
        }

        public async Task<IEnumerable<UsersMinimalResponse>> GetUsers()
        {
            var result = await _usersGateway.GetUsers();
            return result.ToResponse();
        }
    }
}
