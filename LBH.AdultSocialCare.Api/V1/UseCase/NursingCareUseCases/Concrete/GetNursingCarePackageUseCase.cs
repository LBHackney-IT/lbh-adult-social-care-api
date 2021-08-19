using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Concrete
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
