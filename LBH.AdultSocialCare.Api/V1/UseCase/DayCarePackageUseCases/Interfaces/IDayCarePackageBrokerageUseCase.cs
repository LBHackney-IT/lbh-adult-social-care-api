using LBH.AdultSocialCare.Api.V1.Boundary.DayCareBrokerageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.DayCareBrokerageDomains;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces
{
    public interface IDayCarePackageBrokerageUseCase
    {
        Task<DayCarePackageForBrokerageResponse> GetDayCarePackageForBrokerage(Guid dayCarePackageId);

        Task<IEnumerable<DayCareBrokerageStageResponse>> GetDayCarePackageBrokerageStages();

        Task<Guid> CreateDayPackageBrokerageInfo(DayCareBrokerageInfoForCreationDomain dayCareBrokerageInfoForCreationDomain);
    }
}
