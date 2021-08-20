using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Concrete
{
    public class GetDayCarePackageOpportunityListUseCase : IGetDayCarePackageOpportunityListUseCase
    {
        private readonly IDayCarePackageOpportunityGateway _dayCarePackageOpportunityGateway;

        public GetDayCarePackageOpportunityListUseCase(IDayCarePackageOpportunityGateway dayCarePackageOpportunityGateway)
        {
            _dayCarePackageOpportunityGateway = dayCarePackageOpportunityGateway;
        }

        public async Task<IEnumerable<DayCarePackageOpportunityResponse>> Execute(Guid dayCarePackageId)
        {
            var dayCarePackageOpportunities = await _dayCarePackageOpportunityGateway.GetDayCarePackageOpportunityList(dayCarePackageId).ConfigureAwait(false);
            return dayCarePackageOpportunities.ToResponse();
        }
    }
}
