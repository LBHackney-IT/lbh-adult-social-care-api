using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces
{
    public interface IGetNursingCarePackageUseCase
    {
        public Task<NursingCarePackageResponse> GetAsync(Guid nursingCarePackageId);
    }
}
