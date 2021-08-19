using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCareApproveBrokeredGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApproveBrokeredUseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApproveBrokeredUseCase.Concrete
{
    public class GetHomeCareApproveBrokeredUseCase : IGetHomeCareApproveBrokeredUseCase
    {
        private readonly IHomeCareApproveBrokeredGateway _homeCareApproveBrokeredGateway;

        public GetHomeCareApproveBrokeredUseCase(IHomeCareApproveBrokeredGateway homeCareApprovePackageGateway)
        {
            _homeCareApproveBrokeredGateway = homeCareApprovePackageGateway;
        }

        public async Task<HomeCareApproveBrokeredResponse> Execute(Guid homeCarePackageId)
        {
            var homeCareApproveBrokered = await _homeCareApproveBrokeredGateway.GetAsync(homeCarePackageId).ConfigureAwait(false);
            return homeCareApproveBrokered.ToResponse();
        }
    }
}
