using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IGetCarePackageBrokerageUseCase
    {
        Task<CarePackageBrokerageDomain> ExecuteAsync(Guid packageId);
    }
}
