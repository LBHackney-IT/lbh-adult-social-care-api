using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageOpportunityBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageOpportunityDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageOpportunityGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Concrete
{
    public class UpdateDayCarePackageOpportunityUseCase : IUpdateDayCarePackageOpportunityUseCase
    {
        private readonly IDayCarePackageOpportunityGateway _dayCarePackageOpportunityGateway;

        public UpdateDayCarePackageOpportunityUseCase(IDayCarePackageOpportunityGateway dayCarePackageOpportunityGateway)
        {
            _dayCarePackageOpportunityGateway = dayCarePackageOpportunityGateway;
        }

        public async Task<DayCarePackageOpportunityResponse> Execute(DayCarePackageOpportunityForUpdateDomain dayCarePackageOpportunityForUpdateDomain)
        {
            var result = await _dayCarePackageOpportunityGateway.UpdateDayCarePackageOpportunity(dayCarePackageOpportunityForUpdateDomain).ConfigureAwait(false);
            return result.ToResponse();
        }
    }
}
