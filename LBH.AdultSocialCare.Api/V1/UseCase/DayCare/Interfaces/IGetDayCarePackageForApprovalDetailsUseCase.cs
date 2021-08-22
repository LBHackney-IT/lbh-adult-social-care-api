using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCare.Interfaces
{
    public interface IGetDayCarePackageForApprovalDetailsUseCase
    {
        Task<DayCarePackageForApprovalDetailsResponse> Execute(Guid dayCarePackageId);
    }
}
