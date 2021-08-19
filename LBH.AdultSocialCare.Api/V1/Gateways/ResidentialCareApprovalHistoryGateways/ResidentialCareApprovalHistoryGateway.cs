using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                .OrderByDescending(a => a.DateCreated)
                .ToListAsync().ConfigureAwait(false);
            return residentialCareApprovalHistories?.ToDomain();
        }

        public async Task<ResidentialCareApprovalHistoryDomain> CreateAsync(ResidentialCareApprovalHistory residentialCareApprovalHistory)
        {
            var entry = await _databaseContext.ResidentialCareApprovalHistories.AddAsync(residentialCareApprovalHistory).ConfigureAwait(false);
            try
            {
                await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
                return entry.Entity.ToDomain();
            }
            catch (Exception)
            {
                throw new DbSaveFailedException("Could not save approval history to database");
            }
        }
    }
}
