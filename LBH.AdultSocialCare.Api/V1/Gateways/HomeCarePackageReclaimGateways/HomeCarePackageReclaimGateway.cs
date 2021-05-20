using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCarePackageReclaimDomains;
using LBH.AdultSocialCare.Api.V1.Exceptions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCarePackageReclaims;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCarePackageReclaimGateways
{
    public class HomeCarePackageReclaimGateway : IHomeCarePackageReclaimGateway
    {
        private readonly DatabaseContext _databaseContext;

        public HomeCarePackageReclaimGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<HomeCarePackageClaimDomain> CreateAsync(HomeCarePackageReclaim homeCarePackageReclaim)
        {
            var entry = await _databaseContext.HomeCarePackageReclaims.AddAsync(homeCarePackageReclaim).ConfigureAwait(false);
            try
            {
                await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
                return entry.Entity.ToDomain();
            }
            catch (Exception)
            {
                throw new DbSaveFailedException("Could not save supplier to database");
            }
        }

        public async Task<IEnumerable<HomeCarePackageReclaimAmountOptionDomain>> GetListOfAmountOptionAsync()
        {
            var res = await _databaseContext.HomeCarePackageReclaimAmountOptions
                .ToListAsync().ConfigureAwait(false);
            return res?.ToDomain();
        }

        public async Task<IEnumerable<HomeCarePackageReclaimCategoryDomain>> GetListOfPackageReclaimCategoryOptionAsync()
        {
            var res = await _databaseContext.HomeCarePackageReclaimCategories
                .ToListAsync().ConfigureAwait(false);
            return res?.ToDomain();
        }

        public async Task<IEnumerable<HomeCarePackageReclaimFromDomain>> GetListOfPackageReclaimFromOptionAsync()
        {
            var res = await _databaseContext.HomeCarePackageReclaimFroms
                .ToListAsync().ConfigureAwait(false);
            return res?.ToDomain();
        }
    }
}
