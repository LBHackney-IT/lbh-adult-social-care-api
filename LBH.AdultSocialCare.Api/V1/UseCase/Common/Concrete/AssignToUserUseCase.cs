using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class AssignToUserUseCase : IAssignToUserUseCase
    {
        private readonly IBrokeredPackagesGateway _brokeredPackagesGateway;

        public AssignToUserUseCase(IBrokeredPackagesGateway brokeredPackagesGateway)
        {
            _brokeredPackagesGateway = brokeredPackagesGateway;
        }

        public async Task<bool> AssignToUser(Guid packageId, Guid userId)
        {
            var result = await _brokeredPackagesGateway.AssignToUser(packageId, userId).ConfigureAwait(false);
            return result;
        }
    }
}
