using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageBoundary.Response;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces
{
    public interface IGetDayCarePackageForApprovalDetailsUseCase
    {
        Task<DayCarePackageForApprovalDetailsResponse> Execute(Guid dayCarePackageId);
    }
}
