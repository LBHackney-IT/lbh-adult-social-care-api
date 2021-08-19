using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageOpportunityGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Interfaces;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Concrete
{
    public class GetDayCarePackageOpportunityUseCase : IGetDayCarePackageOpportunityUseCase
    {
        private readonly IDayCarePackageOpportunityGateway _dayCarePackageOpportunityGateway;

        public GetDayCarePackageOpportunityUseCase(IDayCarePackageOpportunityGateway dayCarePackageOpportunityGateway)
        {
            _dayCarePackageOpportunityGateway = dayCarePackageOpportunityGateway;
        }

        public async Task<DayCarePackageOpportunityResponse> Execute(Guid dayCarePackageId, Guid dayCarePackageOpportunityId)
        {
            var dayCarePackageOpportunity = await _dayCarePackageOpportunityGateway.GetDayCarePackageOpportunity(dayCarePackageId, dayCarePackageOpportunityId).ConfigureAwait(false);
            return dayCarePackageOpportunity.ToResponse();
        }
    }
}
