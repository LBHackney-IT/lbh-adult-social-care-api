using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class GetTermTimeConsiderationOptionsListUseCase : IGetTermTimeConsiderationOptionsListUseCase
    {
        private readonly ITermTimeConsiderationOptionGateway _termTimeConsiderationOptionGateway;

        public GetTermTimeConsiderationOptionsListUseCase(ITermTimeConsiderationOptionGateway termTimeConsiderationOptionGateway)
        {
            _termTimeConsiderationOptionGateway = termTimeConsiderationOptionGateway;
        }

        public async Task<IEnumerable<TermTimeConsiderationOptionResponse>> Execute()
        {
            var termTimeConsiderationOptions = await _termTimeConsiderationOptionGateway.GetTermTimeConsiderationOptionsList().ConfigureAwait(false);
            return termTimeConsiderationOptions.ToResponse();
        }
    }
}