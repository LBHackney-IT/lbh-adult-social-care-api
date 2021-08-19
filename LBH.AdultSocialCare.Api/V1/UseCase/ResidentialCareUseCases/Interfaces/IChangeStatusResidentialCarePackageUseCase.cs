using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Interfaces
{
    public interface IChangeStatusResidentialCarePackageUseCase
    {
        Task<ResidentialCarePackageResponse> UpdateAsync(Guid residentialCarePackageId, int statusId,
            string requestMoreInformation = null);
    }
}
