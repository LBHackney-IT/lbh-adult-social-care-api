using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageBoundary.Response;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces
{
    public interface IChangeStatusNursingCarePackageUseCase
    {
        public Task<NursingCarePackageResponse> UpdateAsync(Guid nursingCarePackageId, int statusId);
    }
}