using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Concrete
{
    public class ChangeStatusResidentialCarePackageUseCase : IChangeStatusResidentialCarePackageUseCase
    {
        private readonly IResidentialCarePackageGateway _gateway;
        public ChangeStatusResidentialCarePackageUseCase(IResidentialCarePackageGateway residentialCarePackageGateway)
        {
            _gateway = residentialCarePackageGateway;
        }

        public async Task<ResidentialCarePackageResponse> UpdateAsync(Guid residentialCarePackageId, int statusId)
        {
            var residentialCarePackageDomain = await _gateway.ChangeStatusAsync(residentialCarePackageId, statusId).ConfigureAwait(false);
            return residentialCarePackageDomain.ToResponse();
        }
    }
}
