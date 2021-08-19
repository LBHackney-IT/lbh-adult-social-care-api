using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Interfaces
{
    public interface IChangeDatesOfResidentialCarePackageUseCase
    {
        Task<ResidentialCarePackageResponse> UpdateAsync(Guid residentialCarePackageId, DateTimeOffset? startDate, DateTimeOffset? endDate);
    }
}
