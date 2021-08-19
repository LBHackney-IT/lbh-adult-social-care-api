using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Concrete
{
    public class GetAllNursingCarePackageUseCase : IGetAllNursingCarePackageUseCase
    {
        private readonly INursingCarePackageGateway _gateway;

        public GetAllNursingCarePackageUseCase(INursingCarePackageGateway nursingCareAdditionalNeedsGateway)
        {
            _gateway = nursingCareAdditionalNeedsGateway;
        }

        public async Task<IEnumerable<NursingCarePackageResponse>> GetAllAsync()
        {
            var result = await _gateway.ListAsync().ConfigureAwait(false);
            return result.ToResponse();
        }
    }
}
