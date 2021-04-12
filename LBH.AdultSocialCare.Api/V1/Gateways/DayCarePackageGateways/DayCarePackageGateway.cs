using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Exceptions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageGateways
{
    public class DayCarePackageGateway : IDayCarePackageGateway
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public DayCarePackageGateway(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Guid> CreateDayCarePackage(Infrastructure.Entities.DayCarePackage dayCarePackage)
        {
            var entry = await _dbContext.DayCarePackages.AddAsync(dayCarePackage).ConfigureAwait(false);
            try
            {
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);

                return entry.Entity.DayCarePackageId;
            }
            catch (Exception)
            {
                throw new DbSaveFailedException("Could not save day care package to database");
            }
        }

        public async Task<DayCarePackageDomain> UpdateDayCarePackage(DayCarePackageForUpdateDomain dayCarePackageForUpdate)
        {
            var dayCarePackageEntity = await _dbContext.DayCarePackages
                .Where(dc => dc.DayCarePackageId.Equals(dayCarePackageForUpdate.DayCarePackageId))
                .SingleOrDefaultAsync().ConfigureAwait(false);
            if (dayCarePackageEntity == null)
            {
                throw new EntityNotFoundException($"Unable to locate day care package {dayCarePackageForUpdate.DayCarePackageId.ToString()}");
            }
            // Map fields with auto mapper and save
            _mapper.Map(dayCarePackageForUpdate, dayCarePackageEntity);
            dayCarePackageEntity.DateUpdated = DateTimeOffset.Now;
            // DbUpdateConcurrencyException
            try
            {
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                return dayCarePackageEntity.ToDomain();
            }
            catch (Exception)
            {
                throw new DbSaveFailedException($"Update for day care package {dayCarePackageForUpdate.DayCarePackageId.ToString()} failed");
            }
        }

        public async Task<DayCarePackageDomain> GetDayCarePackage(Guid dayCarePackageId)
        {
            var dayCarePackage = await _dbContext.DayCarePackages
                .Where(dc => dc.DayCarePackageId.Equals(dayCarePackageId))
                .AsNoTracking()
                .Include(dc => dc.Package)
                .Include(dc => dc.Client)
                .Include(dc => dc.TermTimeConsiderationOption)
                .Include(dc => dc.Creator)
                .Include(dc => dc.Updater)
                .SingleOrDefaultAsync().ConfigureAwait(false);

            if (dayCarePackage == null)
            {
                throw new EntityNotFoundException($"Unable to locate day care package {dayCarePackageId.ToString()}");
            }

            return dayCarePackage.ToDomain();
        }

        public async Task<IEnumerable<DayCarePackageDomain>> GetDayCarePackageList()
        {
            var dayCarePackages = await _dbContext.DayCarePackages
                .Include(dc => dc.Package)
                .Include(dc => dc.Client)
                .Include(dc => dc.TermTimeConsiderationOption)
                .Include(dc => dc.Creator)
                .Include(dc => dc.Updater)
                .AsNoTracking()
                .ToListAsync().ConfigureAwait(false);
            return dayCarePackages?.ToDomain();
        }
    }
}
