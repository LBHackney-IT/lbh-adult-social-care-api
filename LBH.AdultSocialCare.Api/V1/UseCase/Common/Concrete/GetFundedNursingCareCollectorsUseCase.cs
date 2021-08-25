using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class GetFundedNursingCareCollectorsUseCase : IGetFundedNursingCareCollectorsUseCase
    {
        private readonly IPackageCostClaimersGateway _gateway;

        public GetFundedNursingCareCollectorsUseCase(IPackageCostClaimersGateway gateway)
        {
            _gateway = gateway;
        }

        public async Task<IEnumerable<FundedNursingCareCollectorDomain>> GetFundedNursingCareCollectorsAsync()
        {
            return await _gateway
                .GetFundedNursingCareCollectorsAsync()
                .ConfigureAwait(false);
        }
    }
}
