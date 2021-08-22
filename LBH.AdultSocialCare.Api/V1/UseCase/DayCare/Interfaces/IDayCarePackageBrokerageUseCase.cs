using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCare.Interfaces
{
    public interface IDayCarePackageBrokerageUseCase
    {
        Task<DayCarePackageForBrokerageResponse> GetDayCarePackageForBrokerage(Guid dayCarePackageId);

        Task<IEnumerable<DayCareBrokerageStageResponse>> GetDayCarePackageBrokerageStages();

        Task<Guid> CreateDayPackageBrokerageInfo(DayCareBrokerageInfoForCreationDomain dayCareBrokerageInfoForCreationDomain);
    }
}
