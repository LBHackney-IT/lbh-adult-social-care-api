using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.PrimarySupportReasonBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.PrimarySupportReasonGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.PrimarySupportReasonUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.PrimarySupportReasonUseCase.Concrete
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