using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageReclaimDomains;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCarePackageReclaimDomains;
using LBH.AdultSocialCare.Api.V1.Exceptions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCarePackageReclaims;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCarePackageReclaims;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageReclaimGateways
{
    public class DayCarePackageReclaimGateway : IDayCarePackageReclaimGateway
    {
        private readonly DatabaseContext _databaseContext;

        public DayCarePackageReclaimGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<DayCarePackageClaimDomain> CreateAsync(DayCarePackageReclaim dayCarePackageReclaim)
        {
            var entry = await _databaseContext.DayCarePackageReclaims.AddAsync(dayCarePackageReclaim).ConfigureAwait(false);
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
