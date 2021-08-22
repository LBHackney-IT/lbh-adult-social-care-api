using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces
{
    public interface IChangeStatusNursingCarePackageUseCase
    {
        Task<NursingCarePackageResponse> UpdateAsync(Guid nursingCarePackageId, int statusId,
            string requestMoreInformation = null);
    }
}
