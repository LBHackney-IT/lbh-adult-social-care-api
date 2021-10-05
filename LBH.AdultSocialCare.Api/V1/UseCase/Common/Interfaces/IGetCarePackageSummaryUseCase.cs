using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IGetCarePackageSummaryUseCase
    {
        Task<CarePackageSummaryDomain> ExecuteAsync(Guid packageId);
    }
}
