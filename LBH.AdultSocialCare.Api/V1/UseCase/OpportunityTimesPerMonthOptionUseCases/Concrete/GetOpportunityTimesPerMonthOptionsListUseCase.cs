using LBH.AdultSocialCare.Api.V1.Boundary.OpportunityTimesPerMonthOptionBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.OpportunityTimesPerMonthOptionGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.OpportunityTimesPerMonthOptionUseCases.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.OpportunityTimesPerMonthOptionUseCases.Concrete
{
    public class GetOpportunityTimesPerMonthOptionsListUseCase : IGetOpportunityTimesPerMonthOptionsListUseCase
    {
        private readonly IOpportunityTimesPerMonthOptionGateway _opportunityTimesPerMonthOptionGateway;

        public GetOpportunityTimesPerMonthOptionsListUseCase(IOpportunityTimesPerMonthOptionGateway opportunityTimesPerMonthOptionGateway)
        {
            _opportunityTimesPerMonthOptionGateway = opportunityTimesPerMonthOptionGateway;
        }

        public async Task<IEnumerable<OpportunityTimesPerMonthOptionResponse>> Execute()
        {
            var opportunityTimesPerMonthOptions = await _opportunityTimesPerMonthOptionGateway.GetOpportunityTimesPerMonthOptionsList().ConfigureAwait(false);
            return opportunityTimesPerMonthOptions.ToResponse();
        }
    }
}
