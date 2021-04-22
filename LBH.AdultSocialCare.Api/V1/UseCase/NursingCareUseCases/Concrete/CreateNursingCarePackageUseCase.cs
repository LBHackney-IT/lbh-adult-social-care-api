using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Concrete
{
    public class CreateNursingCarePackageUseCase : ICreateNursingCarePackageUseCase
    {
        private readonly INursingCarePackageGateway _nursingCarePackageGateway;

        public CreateNursingCarePackageUseCase(INursingCarePackageGateway nursingCarePackageGateway)
        {
            _nursingCarePackageGateway = nursingCarePackageGateway;
        }

        public async Task<NursingCarePackageResponse> ExecuteAsync(NursingCarePackageForCreationDomain nursingCarePackageForCreation)
        {
            var nursingCarePackageEntity = nursingCarePackageForCreation.ToDb();
            var res = await _nursingCarePackageGateway.CreateAsync(nursingCarePackageEntity).ConfigureAwait(false);
            return res.ToResponse();
        }
    }
}
