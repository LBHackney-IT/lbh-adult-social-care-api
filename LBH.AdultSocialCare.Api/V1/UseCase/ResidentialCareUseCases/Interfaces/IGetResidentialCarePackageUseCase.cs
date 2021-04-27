using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCarePackageBoundary.Response;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Interfaces
{
    public interface IGetResidentialCarePackageUseCase
    {
        public Task<ResidentialCarePackageResponse> GetAsync(Guid residentialCarePackageId);
    }
}
