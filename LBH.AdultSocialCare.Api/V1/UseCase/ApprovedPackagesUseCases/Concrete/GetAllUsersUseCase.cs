using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ApprovedPackagesBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ApprovedPackagesGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.ApprovedPackagesUseCases.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ApprovedPackagesUseCases.Concrete
{
    public class GetAllUsersUseCase : IGetAllUsersUseCase
    {
        private readonly IApprovedPackagesGateway _approvedPackagesGateway;

        public GetAllUsersUseCase(IApprovedPackagesGateway approvedPackagesGateway)
        {
            _approvedPackagesGateway = approvedPackagesGateway;
        }

        [Obsolete("use version with 'string role' instead")]
        public async Task<IEnumerable<UsersMinimalResponse>> GetUsers(int roleId)
        {
            var result = await _approvedPackagesGateway.GetUsers(roleId).ConfigureAwait(false);
            return result.ToResponse();
        }
        
        public async Task<IEnumerable<UsersMinimalResponse>> GetUsers(string role)
        {
            var result = await _approvedPackagesGateway.GetUsers(role).ConfigureAwait(false);
            return result.ToResponse();
        }
    }
}
