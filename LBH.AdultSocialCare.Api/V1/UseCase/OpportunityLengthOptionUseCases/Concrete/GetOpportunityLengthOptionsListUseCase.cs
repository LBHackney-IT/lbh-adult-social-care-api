using LBH.AdultSocialCare.Api.V1.Boundary.OpportunityLengthOptionBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Gateways.OpportunityLengthOptionGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.OpportunityLengthOptionUseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Factories;

namespace LBH.AdultSocialCare.Api.V1.UseCase.OpportunityLengthOptionUseCases.Concrete
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