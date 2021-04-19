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

        public async Task<ResidentialCareAdditionalNeeds> GetAsync(Guid residentialCareAdditionalNeedsId)
        {
            var result = await _databaseContext.ResidentialCareAdditionalNeeds
                .FirstOrDefaultAsync(item => item.Id == residentialCareAdditionalNeedsId).ConfigureAwait(false);
            return result;
        }

        public async Task<ResidentialCareAdditionalNeeds> UpsertAsync(ResidentialCareAdditionalNeeds residentialCareAdditionalNeeds)
        {
            ResidentialCareAdditionalNeeds residentialAdditionalNeedsToUpdate = await _databaseContext.ResidentialCareAdditionalNeeds
                .FirstOrDefaultAsync(item => item.Id == residentialCareAdditionalNeeds.Id).ConfigureAwait(false);
            if (residentialAdditionalNeedsToUpdate == null)
            {
                residentialAdditionalNeedsToUpdate = new ResidentialCareAdditionalNeeds();
                await _databaseContext.ResidentialCareAdditionalNeeds.AddAsync(residentialAdditionalNeedsToUpdate).ConfigureAwait(false);
            }
            residentialAdditionalNeedsToUpdate.ResidentialCarePackageId = residentialCareAdditionalNeeds.ResidentialCarePackageId;
            residentialAdditionalNeedsToUpdate.Weekly = residentialCareAdditionalNeeds.Weekly;
            residentialAdditionalNeedsToUpdate.OneOff = residentialCareAdditionalNeeds.OneOff;
            residentialAdditionalNeedsToUpdate.NeedToAddress = residentialCareAdditionalNeeds.NeedToAddress;
            residentialAdditionalNeedsToUpdate.CreatorId = residentialCareAdditionalNeeds.CreatorId;
            residentialAdditionalNeedsToUpdate.UpdatorId = residentialCareAdditionalNeeds.UpdatorId;
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;

            return isSuccess
                ? residentialAdditionalNeedsToUpdate
                : null;
        }

        public async Task<bool> DeleteAsync(Guid residentialCareAdditionalNeedsId)
        {
            _databaseContext.ResidentialCareAdditionalNeeds.Remove(new ResidentialCareAdditionalNeeds
            {
                Id = residentialCareAdditionalNeedsId
            });

            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;

            return isSuccess;
        }
    }
}
