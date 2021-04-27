using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Concrete
{
    public class GetAllNursingCareHomeTypeUseCase : IGetAllNursingCareHomeTypeUseCase
    {
        private readonly INursingCarePackageGateway _gateway;

        public GetAllNursingCareHomeTypeUseCase(INursingCarePackageGateway nursingCarePackageGateway)
        {
            _gateway = nursingCarePackageGateway;
        }

        public async Task<IEnumerable<TypeOfNursingCareHomeResponse>> GetAllAsync()
        {
            var result = await _gateway.GetListOfTypeOfNursingCareHomeAsync().ConfigureAwait(false);
            return result.ToResponse();
        }
    }
}