using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCarePackageReclaims;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Concrete
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

        public async Task<IEnumerable<ReclaimAmountOptionDomain>> GetListOfAmountOptionAsync()
        {
            var res = await _databaseContext.ReclaimAmountOptions
                .ToListAsync().ConfigureAwait(false);
            return res?.ToDomain();
        }

        public async Task<IEnumerable<ReclaimCategoryDomain>> GetListOfPackageReclaimCategoryOptionAsync()
        {
            var res = await _databaseContext.ReclaimCategories
                .ToListAsync().ConfigureAwait(false);
            return res?.ToDomain();
        }

        public async Task<IEnumerable<ReclaimFromDomain>> GetListOfPackageReclaimFromOptionAsync()
        {
            var res = await _databaseContext.ReclaimFroms
                .ToListAsync().ConfigureAwait(false);
            return res?.ToDomain();
        }
    }
}
