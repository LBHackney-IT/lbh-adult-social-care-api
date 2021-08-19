using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCareStageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareBrokerageUseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.StageBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCareBrokerageUseCase.Concrete
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
