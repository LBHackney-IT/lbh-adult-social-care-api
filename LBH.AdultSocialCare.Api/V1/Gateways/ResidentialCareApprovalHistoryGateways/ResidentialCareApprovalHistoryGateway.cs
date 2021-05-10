using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareApprovalHistoryGateways
{
    public class ResidentialCareApprovalHistoryGateway : IResidentialCareApprovalHistoryGateway
    {
        private readonly DatabaseContext _databaseContext;

        public ResidentialCareApprovalHistoryGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<ResidentialCareApprovalHistoryDomain>> ListAsync(Guid residentialCarePackageId)
        {
            var residentialCareApprovalHistories = await _databaseContext.ResidentialCareApprovalHistories
                .Where(a => a.ResidentialCarePackageId.Equals(residentialCarePackageId))
                .ToListAsync().ConfigureAwait(false);
            return residentialCareApprovalHistories?.ToDomain();
        }
    }
}
