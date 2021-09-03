using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces
{
    public interface ISetStageToNursingCarePackageUseCase
    {
        Task<bool> UpdatePackage(Guid nursingCarePackageId, int stageId);
    }
}
