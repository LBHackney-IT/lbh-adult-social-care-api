using LBH.AdultSocialCare.Api.V1.Domain.DayCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Exceptions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCareBrokerage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants;

namespace LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageGateways
{
    public class DayCareBrokerageInfoGateway : IDayCareBrokerageInfoGateway
    {
        private readonly DatabaseContext _dbContext;

        public DayCareBrokerageInfoGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> CreateDayCareBrokerageInfo(DayCareBrokerageInfo dayCareBrokerageInfo)
        {
            var entry = await _dbContext.DayCareBrokerageInfo.AddAsync(dayCareBrokerageInfo).ConfigureAwait(false);
            try
            {
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);

                return entry.Entity.BrokerageInfoId;
            }
            catch (Exception)
            {
                throw new DbSaveFailedException("Could not save day care package brokerage info to database");
            }
        }

        public async Task<DayCareBrokerageInfoDomain> GetDayCareBrokerageInfoForPackage(Guid dayCarePackageId)
        {
            var dayCarePackage = await _dbContext.DayCareBrokerageInfo
                .Where(dc => dc.DayCarePackageId.Equals(dayCarePackageId))
                .AsNoTracking()
                .SingleOrDefaultAsync().ConfigureAwait(false);

            return dayCarePackage?.ToDomain();
        }

        public async Task<IEnumerable<DayCareBrokerageStageDomain>> GetDayCareBrokerageStages()
        {
            var statuses = await _dbContext.DayCarePackageStatuses.Where(ps =>
                    ps.IsDayCareStatus.Equals(true) && ps.IsStatusActive.Equals(true) &&
                    ps.Stage.Equals(PackageStageNameConstants.PackageBrokering))
                .AsNoTracking()
                .Select(ps => new DayCareBrokerageStageDomain
                {
                    PackageStatusId = ps.PackageStatusId,
                    StatusName = ps.StatusName,
                    CreatorId = ps.CreatorId,
                    UpdaterId = ps.UpdaterId,
                    SequenceNumber = ps.SequenceNumber,
                    IsDayCareStatus = ps.IsDayCareStatus,
                    IsStatusActive = ps.IsStatusActive,
                    Stage = ps.Stage,
                    PackageAction = ps.PackageAction
                })
                .ToListAsync().ConfigureAwait(false);
            return statuses;
        }
    }
}
