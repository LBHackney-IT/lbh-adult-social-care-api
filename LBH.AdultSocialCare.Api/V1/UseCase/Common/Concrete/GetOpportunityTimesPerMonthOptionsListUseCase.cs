using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
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
