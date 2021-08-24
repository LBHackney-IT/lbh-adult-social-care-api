using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class GetFncCollectorsUseCase : IGetFncCollectorsUseCase
    {
        private readonly IPackageCostClaimersGateway _gateway;

        public GetFncCollectorsUseCase(IPackageCostClaimersGateway gateway)
        {
            _gateway = gateway;
        }

        public async Task<IEnumerable<FncCollectorDomain>> GetFncCollectorsAsync()
        {
            return await _gateway.GetFncCollectorsAsync().ConfigureAwait(false);
        }
    }
}
