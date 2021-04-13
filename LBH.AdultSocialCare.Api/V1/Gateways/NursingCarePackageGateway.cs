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
    public class NursingCarePackageGateway : INursingCarePackageGateway
    {
        private readonly DatabaseContext _databaseContext;

        public NursingCarePackageGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<NursingCarePackage> GetAsync(Guid nursingCarePackageId)
        {
            var result = await _databaseContext.NursingCarePackage
                .Include(item => item.Clients)
                .Include(item => item.Status)
                .FirstOrDefaultAsync(item => item.Id == nursingCarePackageId).ConfigureAwait(false);
            return result;
        }

        public async Task<NursingCarePackage> UpsertAsync(NursingCarePackage nursingCarePackage)
        {
            NursingCarePackage nursingCarePackageToUpdate = await _databaseContext.NursingCarePackage
                .Include(item => item.Clients)
                .Include(item => item.Status)
                .FirstOrDefaultAsync(item => item.Id == nursingCarePackage.Id).ConfigureAwait(false);
            if (nursingCarePackageToUpdate == null)
            {
                nursingCarePackageToUpdate = new NursingCarePackage();
                await _databaseContext.NursingCarePackage.AddAsync(nursingCarePackageToUpdate).ConfigureAwait(false);
            }
            nursingCarePackageToUpdate.ClientId = nursingCarePackage.ClientId;
            nursingCarePackageToUpdate.StartDate = nursingCarePackage.StartDate;
            nursingCarePackageToUpdate.EndDate = nursingCarePackage.EndDate;
            nursingCarePackageToUpdate.IsInterim = nursingCarePackage.IsInterim;
            nursingCarePackageToUpdate.IsUnder8Weeks = nursingCarePackage.IsUnder8Weeks;
            nursingCarePackageToUpdate.IsUnder52Weeks = nursingCarePackage.IsUnder52Weeks;
            nursingCarePackageToUpdate.IsLongStay = nursingCarePackage.IsLongStay;
            nursingCarePackageToUpdate.NeedToAddress = nursingCarePackage.NeedToAddress;
            nursingCarePackageToUpdate.TypeOfNursingHome = nursingCarePackage.TypeOfNursingHome;
            nursingCarePackageToUpdate.Weekly = nursingCarePackage.Weekly;
            nursingCarePackageToUpdate.OneOff = nursingCarePackage.OneOff;
            nursingCarePackageToUpdate.AdditionalNeedToAddress = nursingCarePackage.AdditionalNeedToAddress;
            nursingCarePackageToUpdate.CreatorId = nursingCarePackage.CreatorId;
            nursingCarePackageToUpdate.UpdatorId = nursingCarePackage.UpdatorId;
            nursingCarePackageToUpdate.DateUpdated = nursingCarePackage.DateUpdated;
            nursingCarePackageToUpdate.StatusId = nursingCarePackage.StatusId;
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return isSuccess ? nursingCarePackageToUpdate : null;
        }
    }
}
