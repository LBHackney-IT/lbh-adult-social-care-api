using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Gateways.BrokeredPackagesGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.BrokeredPackagesUseCases.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.BrokeredPackagesUseCases.Concrete
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
