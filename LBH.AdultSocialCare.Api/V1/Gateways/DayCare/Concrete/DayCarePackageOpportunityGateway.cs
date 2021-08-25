using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.DayCare.Concrete
{
    public class DayCarePackageOpportunityGateway : IDayCarePackageOpportunityGateway
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public DayCarePackageOpportunityGateway(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Guid> CreateDayCarePackageOpportunity(DayCarePackageOpportunity dayCarePackageOpportunity)
        {
            var entry = await _dbContext.DayCarePackageOpportunities.AddAsync(dayCarePackageOpportunity).ConfigureAwait(false);
            try
            {
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);

                return entry.Entity.DayCarePackageOpportunityId;
            }
            catch (Exception)
            {
                throw new DbSaveFailedException("Could not save day care package opportunity to database");
            }
        }

        public async Task<DayCarePackageOpportunityDomain> UpdateDayCarePackageOpportunity(DayCarePackageOpportunityForUpdateDomain dayCarePackageOpportunityForUpdate)
        {
            var dayCarePackageEntity = await _dbContext.DayCarePackages
                .Where(dc => dc.DayCarePackageId.Equals(dayCarePackageOpportunityForUpdate.DayCarePackageId))
                .SingleOrDefaultAsync().ConfigureAwait(false);
            if (dayCarePackageEntity == null)
            {
                throw new EntityNotFoundException($"Unable to locate day care package {dayCarePackageOpportunityForUpdate.DayCarePackageId.ToString()}");
            }

            var dayCarePackageOpportunityEntity = await _dbContext.DayCarePackageOpportunities
                .Where(dc => dc.DayCarePackageOpportunityId.Equals(dayCarePackageOpportunityForUpdate.DayCarePackageOpportunityId))
                .SingleOrDefaultAsync().ConfigureAwait(false);
            if (dayCarePackageOpportunityEntity == null)
            {
                throw new EntityNotFoundException($"Unable to locate day care package opportunity {dayCarePackageOpportunityForUpdate.DayCarePackageOpportunityId.ToString()}");
            }

            // Map fields with auto mapper and save
            _mapper.Map(dayCarePackageOpportunityForUpdate, dayCarePackageOpportunityEntity);
            try
            {
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                return dayCarePackageOpportunityEntity.ToDomain();
            }
            catch (Exception)
            {
                throw new DbSaveFailedException($"Update for day care package opportunity {dayCarePackageOpportunityForUpdate.DayCarePackageId.ToString()} failed");
            }
        }

        public async Task<DayCarePackageOpportunityDomain> GetDayCarePackageOpportunity(Guid dayCarePackageId, Guid dayCarePackageOpportunityId)
        {
            var dayCarePackageEntity = await _dbContext.DayCarePackages
                .Where(dc => dc.DayCarePackageId.Equals(dayCarePackageId))
                .SingleOrDefaultAsync().ConfigureAwait(false);
            if (dayCarePackageEntity == null)
            {
                throw new EntityNotFoundException($"Unable to locate day care package {dayCarePackageId.ToString()}");
            }

            var dayCarePackageOpportunity = await _dbContext.DayCarePackageOpportunities
                .Where(dc => dc.DayCarePackageOpportunityId.Equals(dayCarePackageOpportunityId))
                .Include(dco => dco.OpportunityLengthOption)
                .Include(dco => dco.OpportunityTimesPerMonthOption)
                .AsNoTracking()
                .SingleOrDefaultAsync().ConfigureAwait(false);

            if (dayCarePackageOpportunity == null)
            {
                throw new EntityNotFoundException($"Unable to locate day care package opportunity {dayCarePackageOpportunityId.ToString()}");
            }

            return dayCarePackageOpportunity.ToDomain();
        }

        public async Task<IEnumerable<DayCarePackageOpportunityDomain>> GetDayCarePackageOpportunityList(Guid dayCarePackageId)
        {
            var dayCarePackageOpportunities = await _dbContext.DayCarePackageOpportunities
                .Where(dc => dc.DayCarePackageId.Equals(dayCarePackageId))
                .Include(dco => dco.OpportunityLengthOption)
                .Include(dco => dco.OpportunityTimesPerMonthOption)
                .AsNoTracking()
                .ToListAsync().ConfigureAwait(false);
            return dayCarePackageOpportunities?.ToDomain();
        }
    }
}