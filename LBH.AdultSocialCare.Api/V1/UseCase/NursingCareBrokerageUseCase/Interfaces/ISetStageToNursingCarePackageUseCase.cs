using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareBrokerageUseCase.Interfaces
{
    public interface ISetStageToNursingCarePackageUseCase
    {
        Task<bool> UpdatePackage(Guid nursingCarePackageId, int stageId);
    }
}
