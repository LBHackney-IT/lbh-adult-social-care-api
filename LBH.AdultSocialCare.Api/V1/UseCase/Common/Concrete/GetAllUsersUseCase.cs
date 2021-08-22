using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class GetAllUsersUseCase : IGetAllUsersUseCase
    {
        private readonly IApprovedPackagesGateway _approvedPackagesGateway;

        public GetAllUsersUseCase(IApprovedPackagesGateway approvedPackagesGateway)
        {
            _approvedPackagesGateway = approvedPackagesGateway;
        }

        public async Task<IEnumerable<UsersMinimalResponse>> GetUsers(Guid roleId)
        {
            var result = await _approvedPackagesGateway.GetUsers(roleId).ConfigureAwait(false);
            return result.ToResponse();
        }
    }
}
