using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways
{

    public class HomeCarePackageSlotsGateway : IHomeCarePackageSlotsGateway
    {

        private readonly DatabaseContext _databaseContext;

        public HomeCarePackageSlotsGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> DeleteAsync(Guid homeCarePackageId)
        {
            _databaseContext.HomeCarePackageSlots.Remove(new HomeCarePackageSlots
            {
                HomeCarePackageId = homeCarePackageId
            });
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;

            return isSuccess;
        }

        public async Task<HomeCarePackageSlotListDomain> UpsertAsync(
            HomeCarePackageSlotListDomain homeCarePackageSlotListList)
        {
            bool success;

            IList<HomeCarePackageSlots> itemsToDelete = await _databaseContext.HomeCarePackageSlots
                .Where(item => item.HomeCarePackageId == homeCarePackageSlotListList.HomeCarePackageId)
                .ToListAsync()
                .ConfigureAwait(false);

            if (itemsToDelete.Count > 0)
            {
                foreach (var item in itemsToDelete)
                {
                    _databaseContext.HomeCarePackageSlots.Remove(item);
                }

                success = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;

                if (!success)
                {
                    throw new Exception("Failed to delete existing time slot shift entries for home care package");
                }
            }

            HomeCarePackageSlotListDomain homeCarePackageSlotList = new HomeCarePackageSlotListDomain
            {
                HomeCarePackageId = homeCarePackageSlotListList.HomeCarePackageId
            };

            foreach (HomeCarePackageSlotDomain homeCarePackageSlotInputItem in homeCarePackageSlotListList
                .HomeCarePackageSlots)
            {
                HomeCarePackageSlots homeCarePackageSlotsToUpdate = new HomeCarePackageSlots
                {
                    HomeCarePackageId = homeCarePackageSlotListList.HomeCarePackageId,
                    ServiceId = homeCarePackageSlotInputItem.ServiceId,
                    PrimaryInMinutes = homeCarePackageSlotInputItem.PrimaryInMinutes,
                    SecondaryInMinutes = homeCarePackageSlotInputItem.SecondaryInMinutes,
                    NeedToAddress = homeCarePackageSlotInputItem.NeedToAddress,
                    WhatShouldBeDone = homeCarePackageSlotInputItem.WhatShouldBeDone,
                    TimeSlotShiftId = homeCarePackageSlotInputItem.TimeSlotShiftId,
                    DayId = homeCarePackageSlotInputItem.DayId
                };

                homeCarePackageSlotInputItem.TimeSlotShift = await _databaseContext.TimeSlotShifts
                    .FirstOrDefaultAsync(item => item.Id == homeCarePackageSlotInputItem.TimeSlotShiftId)
                    .ConfigureAwait(false);

                //homeCarePackageSlotInputItem.TimeSlotTypes = await _databaseContext.TimeSlotType
                //    .FirstOrDefaultAsync(item => item.Id == homeCarePackageSlotInputItem.TimeSlotTypeId)
                //    .ConfigureAwait(false);

                await _databaseContext.HomeCarePackageSlots.AddAsync(homeCarePackageSlotsToUpdate).ConfigureAwait(false);
                homeCarePackageSlotList.HomeCarePackageSlots.Add(homeCarePackageSlotInputItem);
            }

            success = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) > 0;

            return success
                ? homeCarePackageSlotList
                : null;
        }

    }

}
