using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Concrete
{
    public class GetAllNursingCareTypeOfStayOptionUseCase : IGetAllNursingCareTypeOfStayOptionUseCase
    {
        private readonly INursingCarePackageGateway _gateway;

        public GetAllNursingCareTypeOfStayOptionUseCase(INursingCarePackageGateway nursingCarePackageGateway)
        {
            _gateway = nursingCarePackageGateway;
        }

        public async Task<IEnumerable<NursingCareTypeOfStayOptionResponse>> GetAllAsync()
        {
            var result = await _gateway.GetListOfNursingCareTypeOfStayOptionAsync().ConfigureAwait(false);
            return result.ToResponse();
        }
    }
}
