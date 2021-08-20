using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;

namespace LBH.AdultSocialCare.Api.V1.Gateways.DayCare.Interfaces
{
    public interface IDayCarePackageOpportunityGateway
    {
        Task<Guid> CreateDayCarePackageOpportunity(DayCarePackageOpportunity dayCarePackageOpportunity);

        Task<DayCarePackageOpportunityDomain> UpdateDayCarePackageOpportunity(DayCarePackageOpportunityForUpdateDomain dayCarePackageOpportunityForUpdate);

        Task<DayCarePackageOpportunityDomain> GetDayCarePackageOpportunity(Guid dayCarePackageId, Guid dayCarePackageOpportunityId);

        Task<IEnumerable<DayCarePackageOpportunityDomain>> GetDayCarePackageOpportunityList(Guid dayCarePackageId);
    }
}
