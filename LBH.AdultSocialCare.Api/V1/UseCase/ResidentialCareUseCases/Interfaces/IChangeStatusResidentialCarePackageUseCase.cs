using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareAdditionalNeedsBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Interfaces
{
    public interface IChangeStatusResidentialCarePackageUseCase
    {
        public Task<ResidentialCarePackageResponse> UpdateAsync(Guid residentialCarePackageId, int statusId);
    }
}
