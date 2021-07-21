using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageBoundary.Response;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces
{
    public interface IChangeStatusNursingCarePackageUseCase
    {
        Task<NursingCarePackageResponse> UpdateAsync(Guid nursingCarePackageId, int statusId,
            string requestMoreInformation = null);
    }
}
