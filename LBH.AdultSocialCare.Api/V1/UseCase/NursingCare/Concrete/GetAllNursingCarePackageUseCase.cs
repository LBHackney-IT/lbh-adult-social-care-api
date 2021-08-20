using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Concrete
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
