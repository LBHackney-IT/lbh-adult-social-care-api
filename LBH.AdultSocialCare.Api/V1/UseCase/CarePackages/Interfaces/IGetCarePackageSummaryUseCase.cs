using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IGetCarePackageSummaryUseCase
    {
        Task<CarePackageSummaryDomain> ExecuteAsync(Guid packageId);
    }
}
