using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Concrete
{
    public class NursingCareAdditionalNeedsGateway : INursingCareAdditionalNeedsGateway
    {
        private readonly DatabaseContext _databaseContext;

        public NursingCareAdditionalNeedsGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<NursingCareAdditionalNeed> UpsertAsync(NursingCareAdditionalNeed nursingCareAdditionalNeed)
        {
            NursingCareAdditionalNeed nursingCareAdditionalNeedToUpdate = await _databaseContext.NursingCareAdditionalNeeds
                .FirstOrDefaultAsync(item => item.Id == nursingCareAdditionalNeed.Id).ConfigureAwait(false);
            if (nursingCareAdditionalNeedToUpdate == null)
            {
                nursingCareAdditionalNeedToUpdate = new NursingCareAdditionalNeed();
                await _databaseContext.NursingCareAdditionalNeeds.AddAsync(nursingCareAdditionalNeedToUpdate).ConfigureAwait(false);
            }
            nursingCareAdditionalNeedToUpdate.NursingCarePackageId = nursingCareAdditionalNeed.NursingCarePackageId;
            nursingCareAdditionalNeedToUpdate.AdditionalNeedsPaymentTypeId =
                nursingCareAdditionalNeed.AdditionalNeedsPaymentTypeId;
            nursingCareAdditionalNeedToUpdate.NeedToAddress = nursingCareAdditionalNeed.NeedToAddress;
            nursingCareAdditionalNeedToUpdate.CreatorId = nursingCareAdditionalNeed.CreatorId;
            nursingCareAdditionalNeedToUpdate.UpdaterId = nursingCareAdditionalNeed.UpdaterId;
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;

            return isSuccess
                ? nursingCareAdditionalNeedToUpdate
                : null;
        }

        public async Task<NursingCareAdditionalNeed> GetAsync(Guid nursingCareAdditionalNeedsId)
        {
            var result = await _databaseContext.NursingCareAdditionalNeeds
                .FirstOrDefaultAsync(item => item.Id == nursingCareAdditionalNeedsId).ConfigureAwait(false);
            return result;
        }

        public async Task<bool> DeleteAsync(Guid nursingCareAdditionalNeedsId)
        {
            _databaseContext.NursingCareAdditionalNeeds.Remove(new NursingCareAdditionalNeed
            {
                Id = nursingCareAdditionalNeedsId
            });

            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;

            return isSuccess;
        }
        public async Task<IEnumerable<AdditionalNeedsPaymentTypeDomain>> GetListOfTypeOfPaymentOptionList()
        {
            var res = await _databaseContext.AdditionalNeedsPaymentTypes
                .ToListAsync().ConfigureAwait(false);
            return res?.ToDomain();
        }
    }
}
