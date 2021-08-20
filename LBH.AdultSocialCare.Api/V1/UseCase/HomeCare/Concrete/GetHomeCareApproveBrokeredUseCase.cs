using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Concrete
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
