using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class GetOpportunityLengthOptionsListUseCase : IGetOpportunityLengthOptionsListUseCase
    {
        private readonly IOpportunityLengthOptionGateway _opportunityLengthOptionGateway;

        public GetOpportunityLengthOptionsListUseCase(IOpportunityLengthOptionGateway opportunityLengthOptionGateway)
        {
            _opportunityLengthOptionGateway = opportunityLengthOptionGateway;
        }

        public async Task<IEnumerable<OpportunityLengthOptionResponse>> Execute()
        {
            var opportunityLengthOptions = await _opportunityLengthOptionGateway.GetOpportunityLengthOptionsList().ConfigureAwait(false);
            return opportunityLengthOptions.ToResponse();
        }
    }
}
