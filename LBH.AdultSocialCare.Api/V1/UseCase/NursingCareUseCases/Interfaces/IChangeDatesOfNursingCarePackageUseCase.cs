using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageBoundary.Response;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces
{
    public interface IChangeDatesOfNursingCarePackageUseCase
    {
        Task<NursingCarePackageResponse> UpdateAsync(Guid nursingCarePackageId, DateTimeOffset? startDate, DateTimeOffset? endDate);
    }
}
