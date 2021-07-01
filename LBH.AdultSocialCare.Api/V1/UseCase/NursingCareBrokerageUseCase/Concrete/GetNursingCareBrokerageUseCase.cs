using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareBrokerageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCareBrokerageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareBrokerageUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareBrokerageUseCase.Concrete
{
    public class GetNursingCareBrokerageUseCase : IGetNursingCareBrokerageUseCase
    {
        private readonly INursingCareBrokerageGateway _nursingCareBrokerageGateway;

        public GetNursingCareBrokerageUseCase(INursingCareBrokerageGateway nursingCareBrokerageGateway)
        {
            _nursingCareBrokerageGateway = nursingCareBrokerageGateway;
        }

        public async Task<NursingCareBrokerageInfoResponse> Execute(Guid nursingCarePackageId)
        {
            var nursingCareBrokerageInfo = await _nursingCareBrokerageGateway.GetAsync(nursingCarePackageId).ConfigureAwait(false);
            return nursingCareBrokerageInfo.ToResponse();
        }
    }
}
