using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageBoundary.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces
{
    public interface IGetAllNursingCarePackageUseCase
    {
        public Task<IEnumerable<NursingCarePackageResponse>> GetAllAsync();
    }
}
