using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCareBrokerage;

namespace LBH.AdultSocialCare.Api.V1.Gateways.DayCare.Interfaces
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
