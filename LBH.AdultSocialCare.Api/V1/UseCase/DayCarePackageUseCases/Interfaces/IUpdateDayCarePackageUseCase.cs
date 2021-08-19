using System;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces
{
    public interface IUpdateDayCarePackageUseCase
    {
        Task<DayCarePackageResponse> Execute(Guid dayCarePackageId, DayCarePackageForUpdateDomain dayCarePackageForUpdateDomain);
    }
}
