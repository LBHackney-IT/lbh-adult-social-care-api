using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Interfaces
{
    public interface ISetStageToResidentialCarePackageUseCase
    {
        Task<bool> UpdatePackage(Guid residentialCarePackageId, int stageId);
    }
}
