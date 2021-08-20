using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class GetAllAmountOptionUseCase : IGetAllAmountOptionUseCase
    {
        private readonly IHomeCarePackageReclaimGateway _gateway;

        public GetAllAmountOptionUseCase(IHomeCarePackageReclaimGateway homeCarePackageReclaimGateway)
        {
            _gateway = homeCarePackageReclaimGateway;
        }

        public async Task<IEnumerable<ReclaimAmountOptionResponse>> GetAllAsync()
        {
            var result = await _gateway.GetListOfAmountOptionAsync().ConfigureAwait(false);
            return result.ToResponse();
        }
    }
}
