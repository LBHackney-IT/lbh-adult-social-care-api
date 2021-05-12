using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Exceptions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

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
            var dayCareCollege = await _dbContext.DayCareColleges
                .Where(dc => dc.Id.Equals(dayCareCollegeId))
                .Include(dc => dc.Creator)
                .Include(dc => dc.Updater)
                .AsNoTracking()
                .SingleOrDefaultAsync().ConfigureAwait(false);

            if (dayCareCollege == null)
            {
                throw new EntityNotFoundException($"Unable to locate day care college {dayCareCollegeId.ToString()}");
            }

            return dayCareCollege.ToDomain();
        }

        public async Task<IEnumerable<DayCareCollegeDomain>> GetDayCareCollegeList()
        {
            var dayCarePackages = await _dbContext.DayCareColleges
                .Include(dc => dc.Creator)
                .Include(dc => dc.Updater)
                .AsNoTracking()
                .ToListAsync().ConfigureAwait(false);
            return dayCarePackages?.ToDomain();
        }
    }
}
