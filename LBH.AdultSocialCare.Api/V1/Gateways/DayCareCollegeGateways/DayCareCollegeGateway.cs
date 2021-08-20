using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.DayCareCollegeGateways
{
    public class DayCareCollegeGateway : IDayCareCollegeGateway
    {
        private readonly DatabaseContext _dbContext;

        public DayCareCollegeGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateDayCareCollege(DayCareCollege dayCareCollege)
        {
            var entry = await _dbContext.DayCareColleges.AddAsync(dayCareCollege).ConfigureAwait(false);
            try
            {
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);

                return entry.Entity.Id;
            }
            catch (Exception)
            {
                throw new DbSaveFailedException("Could not save day care college to database");
            }
        }

        public async Task<DayCareCollegeDomain> GetDayCareCollege(int dayCareCollegeId)
        {
            var dayCareCollegeDomain = await _dbContext.DayCareColleges
                .Where(dc => dc.Id.Equals(dayCareCollegeId))
                .Select(dcc => new DayCareCollegeDomain
                {
                    Id = dcc.Id,
                    CollegeName = dcc.CollegeName,
                    StartDate = dcc.StartDate,
                    EndDate = dcc.EndDate,
                    CreatorId = dcc.CreatorId,
                    UpdaterId = dcc.UpdaterId,
                    CreatorName = $"{dcc.Creator.Name}",
                    UpdaterName = dcc.Updater != null ? $"{dcc.Updater.Name}" : null
                })
                .AsNoTracking()
                .SingleOrDefaultAsync().ConfigureAwait(false);

            if (dayCareCollegeDomain == null)
            {
                throw new EntityNotFoundException($"Unable to locate day care college {dayCareCollegeId.ToString()}");
            }

            return dayCareCollegeDomain;
        }

        public async Task<IEnumerable<DayCareCollegeDomain>> GetDayCareCollegeList()
        {
            var dayCarePackages = await _dbContext.DayCareColleges
                .Select(dcc => new DayCareCollegeDomain
                {
                    Id = dcc.Id,
                    CollegeName = dcc.CollegeName,
                    StartDate = dcc.StartDate,
                    EndDate = dcc.EndDate,
                    CreatorId = dcc.CreatorId,
                    UpdaterId = dcc.UpdaterId,
                    CreatorName = $"{dcc.Creator.Name}",
                    UpdaterName = dcc.Updater != null ? $"{dcc.Updater.Name}" : null
                })
                .AsNoTracking()
                .ToListAsync().ConfigureAwait(false);
            return dayCarePackages;
        }
    }
}
