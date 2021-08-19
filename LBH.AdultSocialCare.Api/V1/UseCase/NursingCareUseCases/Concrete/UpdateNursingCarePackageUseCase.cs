using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Concrete
{
    public class UpdateNursingCarePackageUseCase : IUpdateNursingCarePackageUseCase
    {
        private readonly INursingCarePackageGateway _gateway;

        public UpdateNursingCarePackageUseCase(INursingCarePackageGateway nursingCarePackageGateway)
        {
            _gateway = nursingCarePackageGateway;
        }

        public async Task<NursingCarePackageResponse> ExecuteAsync(NursingCarePackageForUpdateDomain nursingCarePackageForUpdate)
        {
            var nursingCarePackageDomain = await _gateway.UpdateAsync(nursingCarePackageForUpdate).ConfigureAwait(false);
            return nursingCarePackageDomain.ToResponse();
        }
    }
}
