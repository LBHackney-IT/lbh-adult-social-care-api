using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCarePackageBoundary.Response;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Interfaces
{
    public interface IChangeStatusResidentialCarePackageUseCase
    {
        public Task<ResidentialCarePackageResponse> UpdateAsync(Guid residentialCarePackageId, int statusId);
    }
}
