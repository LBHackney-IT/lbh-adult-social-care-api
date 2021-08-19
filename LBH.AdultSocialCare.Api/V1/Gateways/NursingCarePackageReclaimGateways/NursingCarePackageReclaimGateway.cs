using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCarePackageReclaims;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCarePackageReclaimGateways
{
    public class NursingCarePackageReclaimGateway : INursingCarePackageReclaimGateway
    {
        private readonly DatabaseContext _databaseContext;

        public NursingCarePackageReclaimGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<NursingCarePackageClaimDomain> CreateAsync(NursingCarePackageReclaim dayCarePackageReclaim)
        {
            var entry = await _databaseContext.NursingCarePackageReclaims.AddAsync(dayCarePackageReclaim).ConfigureAwait(false);
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
