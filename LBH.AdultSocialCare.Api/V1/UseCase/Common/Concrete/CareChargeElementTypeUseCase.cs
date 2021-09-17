using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class CareChargeElementTypeUseCase : ICareChargeElementTypeUseCase
    {
        private readonly ICareChargeElementTypeGateway _careChargeElementTypeGateway;

        public CareChargeElementTypeUseCase(ICareChargeElementTypeGateway careChargeElementTypeGateway)
        {
            _careChargeElementTypeGateway = careChargeElementTypeGateway;
        }

        public async Task<IEnumerable<CareChargeElementTypePlainResponse>> GetAllAsync()
        {
            var res = await _careChargeElementTypeGateway.GetAllAsync().ConfigureAwait(false);
            return res.ToResponse();
        }
    }
}
