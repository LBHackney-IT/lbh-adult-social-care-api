using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageOpportunityBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageOpportunityGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Concrete
{
    public class GetDayCarePackageOpportunityUseCase : IGetDayCarePackageOpportunityUseCase
    {
        private readonly IDayCarePackageOpportunityGateway _dayCarePackageOpportunityGateway;

        public GetDayCarePackageOpportunityUseCase(IDayCarePackageOpportunityGateway dayCarePackageOpportunityGateway)
        {
            _dayCarePackageOpportunityGateway = dayCarePackageOpportunityGateway;
        }

        public async Task<DayCarePackageOpportunityResponse> Execute(Guid dayCarePackageOpportunityId)
        {
            var dayCarePackageOpportunity = await _dayCarePackageOpportunityGateway.GetDayCarePackageOpportunity(dayCarePackageOpportunityId).ConfigureAwait(false);
            return dayCarePackageOpportunity.ToResponse();
        }
    }
}
