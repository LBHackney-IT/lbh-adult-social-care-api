using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways
{
    public class ResidentialCareAdditionalNeedsGateway : IResidentialCareAdditionalNeedsGateway
    {
        private readonly DatabaseContext _databaseContext;

        public ResidentialCareAdditionalNeedsGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<ResidentialCareAdditionalNeed> GetAsync(Guid residentialCareAdditionalNeedsId)
        {
            var result = await _databaseContext.ResidentialCareAdditionalNeeds
                .FirstOrDefaultAsync(item => item.Id == residentialCareAdditionalNeedsId).ConfigureAwait(false);
            return result;
        }

        public async Task<ResidentialCareAdditionalNeed> UpsertAsync(ResidentialCareAdditionalNeed residentialCareAdditionalNeed)
        {
            ResidentialCareAdditionalNeed residentialAdditionalNeedToUpdate = await _databaseContext.ResidentialCareAdditionalNeeds
                .FirstOrDefaultAsync(item => item.Id == residentialCareAdditionalNeed.Id).ConfigureAwait(false);
            if (residentialAdditionalNeedToUpdate == null)
            {
                residentialAdditionalNeedToUpdate = new ResidentialCareAdditionalNeed();
                await _databaseContext.ResidentialCareAdditionalNeeds.AddAsync(residentialAdditionalNeedToUpdate).ConfigureAwait(false);
            }
            residentialAdditionalNeedToUpdate.ResidentialCarePackageId = residentialCareAdditionalNeed.ResidentialCarePackageId;
            residentialAdditionalNeedToUpdate.Weekly = residentialCareAdditionalNeed.Weekly;
            residentialAdditionalNeedToUpdate.OneOff = residentialCareAdditionalNeed.OneOff;
            residentialAdditionalNeedToUpdate.NeedToAddress = residentialCareAdditionalNeed.NeedToAddress;
            residentialAdditionalNeedToUpdate.CreatorId = residentialCareAdditionalNeed.CreatorId;
            residentialAdditionalNeedToUpdate.UpdatorId = residentialCareAdditionalNeed.UpdatorId;
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;

            return isSuccess
                ? residentialAdditionalNeedToUpdate
                : null;
        }

        public async Task<bool> DeleteAsync(Guid residentialCareAdditionalNeedsId)
        {
            _databaseContext.ResidentialCareAdditionalNeeds.Remove(new ResidentialCareAdditionalNeed
            {
                Id = residentialCareAdditionalNeedsId
            });

            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;

            return isSuccess;
        }
    }
}
