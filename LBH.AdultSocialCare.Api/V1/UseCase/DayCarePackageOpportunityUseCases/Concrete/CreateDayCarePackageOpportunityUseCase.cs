using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageOpportunityDomains;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Interfaces;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageOpportunityGateways;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Concrete
{
    public class CreateDayCarePackageOpportunityUseCase : ICreateDayCarePackageOpportunityUseCase
    {
        private readonly IDayCarePackageOpportunityGateway _dayCarePackageOpportunityGateway;

        public CreateDayCarePackageOpportunityUseCase(IDayCarePackageOpportunityGateway dayCarePackageOpportunityGateway)
        {
            _dayCarePackageOpportunityGateway = dayCarePackageOpportunityGateway;
        }
        public async Task<Guid> Execute(DayCarePackageOpportunityForCreationDomain dayCarePackageOpportunityForCreationDomain)
        {
            var dayCarePackageOpportunityEntity = dayCarePackageOpportunityForCreationDomain.ToDb();
            var id = await _dayCarePackageOpportunityGateway.CreateDayCarePackageOpportunity(dayCarePackageOpportunityEntity).ConfigureAwait(false);
            return id;
        }
    }
}
