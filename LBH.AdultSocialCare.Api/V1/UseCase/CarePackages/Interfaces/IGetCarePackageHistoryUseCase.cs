using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IGetCarePackageHistoryUseCase
    {
        Task<CarePackageHistoryViewResponse> ExecuteAsync(Guid packageId);
    }
}
