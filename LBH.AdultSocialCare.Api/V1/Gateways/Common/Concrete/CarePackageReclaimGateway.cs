using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete
{
    public class CarePackageReclaimGateway : ICarePackageReclaimGateway
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public CarePackageReclaimGateway(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CarePackageReclaimDomain> CreateCarePackageReclaim(CarePackageReclaim carePackageReclaim)
        {
            var carePackage = await _dbContext.CarePackages
                .FirstOrDefaultAsync(item => item.Id == carePackageReclaim.CarePackageId).ConfigureAwait(false);

            if (carePackage == null)
            {
                throw new EntityNotFoundException($"Unable to locate care package for {carePackageReclaim.CarePackageId}");
            }

            var entry = await _dbContext.CarePackageReclaims.AddAsync(carePackageReclaim);
            try
            {
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                return entry.Entity.ToDomain();
            }
            catch (Exception ex)
            {
                throw new DbSaveFailedException("Could not save care package reclaim to database" + ex.Message);
            }
        }

        public async Task<bool> UpdateCarePackageReclaim(CarePackageReclaimForUpdateDomain carePackageReclaimForUpdateDomain)
        {
            var carePackageReclaim = await _dbContext.CarePackageReclaims
                .FirstOrDefaultAsync(item => item.Id == carePackageReclaimForUpdateDomain.Id).ConfigureAwait(false);

            if (carePackageReclaim == null)
            {
                throw new EntityNotFoundException($"Unable to locate care package reclaim {carePackageReclaimForUpdateDomain.Id}");
            }

            _mapper.Map(carePackageReclaimForUpdateDomain, carePackageReclaim);
            try
            {
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                throw new DbSaveFailedException($"Update for care package reclaim for {carePackageReclaimForUpdateDomain.Id} failed {ex.Message}");
            }
        }

        public async Task<CarePackageReclaimDomain> GetCarePackageReclaim(Guid carePackageId, ReclaimType reclaimType)
        {
            var carePackageReclaim = await _dbContext.CarePackageReclaims
                .Where(a => a.CarePackageId.Equals(carePackageId) &&
                            a.Type.Equals(reclaimType))
                .SingleOrDefaultAsync();

            return carePackageReclaim?.ToDomain();
        }
    }
}
