using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Concrete
{
    public class GetNursingCarePackageUseCase : IGetNursingCarePackageUseCase
    {
        private readonly INursingCarePackageGateway _gateway;

        public GetNursingCarePackageUseCase(INursingCarePackageGateway nursingCarePackageGateway)
        {
            _gateway = nursingCarePackageGateway;
        }

        public async Task<NursingCarePackageResponse> GetAsync(Guid nursingCarePackageId)
        {
            var packageDomain = await _gateway.GetAsync(nursingCarePackageId).ConfigureAwait(false);
            return packageDomain.ToResponse();
        }
    }
}
