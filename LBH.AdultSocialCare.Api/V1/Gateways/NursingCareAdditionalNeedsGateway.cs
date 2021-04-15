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
    public class NursingCareAdditionalNeedsGateway : INursingCareAdditionalNeedsGateway
    {
        private readonly DatabaseContext _databaseContext;

        public NursingCareAdditionalNeedsGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<NursingCareAdditionalNeeds> UpsertAsync(NursingCareAdditionalNeeds nursingCareAdditionalNeeds)
        {
            NursingCareAdditionalNeeds nursingCareAdditionalNeedsToUpdate = await _databaseContext.NursingCareAdditionalNeeds
                .FirstOrDefaultAsync(item => item.Id == nursingCareAdditionalNeeds.Id).ConfigureAwait(false);
            if (nursingCareAdditionalNeedsToUpdate == null)
            {
                nursingCareAdditionalNeedsToUpdate = new NursingCareAdditionalNeeds();
                await _databaseContext.NursingCareAdditionalNeeds.AddAsync(nursingCareAdditionalNeedsToUpdate).ConfigureAwait(false);
            }
            nursingCareAdditionalNeedsToUpdate.NursingCarePackageId = nursingCareAdditionalNeeds.NursingCarePackageId;
            nursingCareAdditionalNeedsToUpdate.Weekly = nursingCareAdditionalNeeds.Weekly;
            nursingCareAdditionalNeedsToUpdate.OneOff = nursingCareAdditionalNeeds.OneOff;
            nursingCareAdditionalNeedsToUpdate.NeedToAddress = nursingCareAdditionalNeeds.NeedToAddress;
            nursingCareAdditionalNeedsToUpdate.CreatorId = nursingCareAdditionalNeeds.CreatorId;
            nursingCareAdditionalNeedsToUpdate.UpdatorId = nursingCareAdditionalNeeds.UpdatorId;
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;

            return isSuccess
                ? nursingCareAdditionalNeedsToUpdate
                : null;
        }

        public async Task<NursingCareAdditionalNeeds> GetAsync(Guid nursingCareAdditionalNeedsId)
        {
            var result = await _databaseContext.NursingCareAdditionalNeeds
                .FirstOrDefaultAsync(item => item.Id == nursingCareAdditionalNeedsId).ConfigureAwait(false);
            return result;
        }
    }
}
