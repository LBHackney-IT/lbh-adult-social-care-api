using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Concrete
{
    public class ChangeStatusNursingCarePackageUseCase : IChangeStatusNursingCarePackageUseCase
    {
        private readonly INursingCarePackageGateway _gateway;
        public ChangeStatusNursingCarePackageUseCase(INursingCarePackageGateway nursingCarePackageGateway)
        {
            _gateway = nursingCarePackageGateway;
        }

        public async Task<NursingCarePackageResponse> UpdateAsync(Guid nursingCarePackageId, int statusId)
        {
            var nursingCarePackageDomain = await _gateway.ChangeStatusAsync(nursingCarePackageId, statusId).ConfigureAwait(false);
            return nursingCarePackageDomain.ToResponse();
        }
    }
}
