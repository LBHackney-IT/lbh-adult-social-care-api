using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareBrokerageUseCase.Interfaces
{
    public interface ISetStageToResidentialCarePackageUseCase
    {
        Task<bool> UpdatePackage(Guid residentialCarePackageId, int stageId);
    }
}
