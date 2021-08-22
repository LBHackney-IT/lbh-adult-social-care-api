using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class GetAllPrimarySupportReasonsUseCase : IGetAllPrimarySupportReasonsUseCase
    {
        private readonly IPrimarySupportReasonGateway _primarySupportReasonGateway;

        public GetAllPrimarySupportReasonsUseCase(IPrimarySupportReasonGateway primarySupportReasonGateway)
        {
            _primarySupportReasonGateway = primarySupportReasonGateway;
        }

        public async Task<IEnumerable<PrimarySupportReasonResponse>> GetAllAsync()
        {
            var result = await _primarySupportReasonGateway.ListAsync().ConfigureAwait(false);
            return result.ToResponse();
        }
    }
}
