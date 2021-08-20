using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Concrete
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
