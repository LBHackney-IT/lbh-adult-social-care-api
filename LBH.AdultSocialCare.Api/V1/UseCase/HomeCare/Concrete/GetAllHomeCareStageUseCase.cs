using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Concrete
{
    public class GetAllHomeCareStageUseCase : IGetAllHomeCareStageUseCase
    {
        private readonly IHomeCareStageGateway _homeCareStageGateway;

        public GetAllHomeCareStageUseCase(IHomeCareStageGateway homeCareStageGateway)
        {
            _homeCareStageGateway = homeCareStageGateway;
        }

        public async Task<IEnumerable<StageResponse>> GetAllAsync()
        {
            var result = await _homeCareStageGateway.ListAsync().ConfigureAwait(false);
            return result.ToResponse();
        }
    }
}
