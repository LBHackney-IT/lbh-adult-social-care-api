using LBH.AdultSocialCare.Api.V1.Domain.DayCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCareBrokerage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageGateways
{
    public interface IDayCareBrokerageInfoGateway
    {
        Task<Guid> CreateDayCareBrokerageInfo(DayCareBrokerageInfo dayCareBrokerageInfo);
        Task<DayCareBrokerageInfoDomain> GetDayCareBrokerageInfoForPackage(Guid dayCarePackageId);
        Task<IEnumerable<DayCareBrokerageStageDomain>> GetDayCareBrokerageStages();
        Task UpdateEscortPackage(DayCareBrokerageInfo dayCareBrokerageInfo);
        Task UpdateTransportPackage(DayCareBrokerageInfo dayCareBrokerageInfo);
        Task UpdateTransportEscortPackage(DayCareBrokerageInfo dayCareBrokerageInfo);

    }
}
