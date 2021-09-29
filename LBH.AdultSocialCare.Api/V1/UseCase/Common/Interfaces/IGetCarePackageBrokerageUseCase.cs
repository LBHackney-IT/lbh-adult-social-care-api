using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IGetCarePackageBrokerageUseCase
    {
        Task<CarePackageBrokerageDomain> ExecuteAsync(Guid packageId);
    }
}
