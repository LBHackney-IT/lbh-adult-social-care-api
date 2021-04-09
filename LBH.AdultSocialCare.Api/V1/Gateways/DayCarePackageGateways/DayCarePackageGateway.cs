using Amazon.DynamoDBv2.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;

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
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            return entry.Entity.DayCarePackageId;
        }

        public async Task<DayCarePackageDomain> UpdateDayCarePackage(DayCarePackageForUpdateDomain dayCarePackageForUpdate)
        {
            var dayCarePackageEntity = await _dbContext.DayCarePackages
                .Where(dc => dc.DayCarePackageId.Equals(dayCarePackageForUpdate.DayCarePackageId))
                .SingleOrDefaultAsync().ConfigureAwait(false);
            if (dayCarePackageEntity == null)
            {
                throw new ResourceNotFoundException($"Unable to locate day care package {dayCarePackageForUpdate.DayCarePackageId.ToString()}");
            }
            // Map fields with auto mapper and save
            _mapper.Map(dayCarePackageForUpdate, dayCarePackageEntity);
            dayCarePackageEntity.DateUpdated = DateTimeOffset.Now;
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return dayCarePackageEntity.ToDomain();
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
                throw new ResourceNotFoundException($"Unable to locate day care package {dayCarePackageId.ToString()}");
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
