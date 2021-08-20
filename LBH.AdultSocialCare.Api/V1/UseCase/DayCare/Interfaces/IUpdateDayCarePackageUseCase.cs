using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCare.Interfaces
{
    public interface IUpdateDayCarePackageUseCase
    {
        Task<DayCarePackageResponse> Execute(Guid dayCarePackageId, DayCarePackageForUpdateDomain dayCarePackageForUpdateDomain);
    }
}
