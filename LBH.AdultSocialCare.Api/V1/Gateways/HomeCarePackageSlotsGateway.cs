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

        public async Task<HomeCarePackageSlotsList> UpsertAsync(HomeCarePackageSlotsList homeCarePackageSlotsList)
        {
            List<HomeCarePackageSlots> deleteids = await _databaseContext.HomeCarePackageSlots
                .Where(item => item.HomeCarePackageId == homeCarePackageSlotsList.HomeCarePackageId)
                .ToListAsync()
                .ConfigureAwait(false);

            if (deleteids.Count > 0)
            {
                foreach (var item in deleteids)
                {
                    _databaseContext.HomeCarePackageSlots.Remove(item);
                    bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
                }
            }

            HomeCarePackageSlotsList homeCarePackageSlots = new HomeCarePackageSlotsList
            {
                HomeCarePackageId = homeCarePackageSlotsList.HomeCarePackageId
            };

            foreach (var items in homeCarePackageSlotsList.HomeCarePackageSlot)
            {
                HomeCarePackageSlots homeCarePackageSlotsToUpdate = new HomeCarePackageSlots();
                await _databaseContext.HomeCarePackageSlots.AddAsync(homeCarePackageSlotsToUpdate).ConfigureAwait(false);
                homeCarePackageSlotsToUpdate.HomeCarePackageId = homeCarePackageSlotsList.HomeCarePackageId;
                homeCarePackageSlotsToUpdate.ServiceId = homeCarePackageSlotsList.ServiceId;

                homeCarePackageSlots.Services = await _databaseContext.HomeCareServiceTypes
                    .FirstOrDefaultAsync(item => item.Id == homeCarePackageSlotsList.ServiceId)
                    .ConfigureAwait(false);
                homeCarePackageSlotsToUpdate.PrimaryCarer = homeCarePackageSlotsList.PrimaryCarer;
                homeCarePackageSlotsToUpdate.SecondaryCarer = homeCarePackageSlotsList.SecondaryCarer;
                homeCarePackageSlotsToUpdate.NeedToAddress = homeCarePackageSlotsList.NeedToAddress;
                homeCarePackageSlotsToUpdate.WhatShouldBeDone = homeCarePackageSlotsList.WhatShouldBeDone;
                homeCarePackageSlotsToUpdate.TimeSlotShiftId = items.TimeSlotShiftId;

                items.TimeSlotShift = await _databaseContext.TimeSlotShifts
                    .FirstOrDefaultAsync(item => item.Id == items.TimeSlotShiftId)
                    .ConfigureAwait(false);
                homeCarePackageSlotsToUpdate.TimeSlotTypeId = items.TimeSlotTypeId;

                items.TimeSlotTypes = await _databaseContext.TimeSlotType
                    .FirstOrDefaultAsync(item => item.Id == items.TimeSlotTypeId)
                    .ConfigureAwait(false);
                homeCarePackageSlotsToUpdate.InHours = items.InHours;
                homeCarePackageSlotsToUpdate.InMinutes = items.InMinutes;
                homeCarePackageSlotsToUpdate.Time = items.Time;
                homeCarePackageSlots.HomeCarePackageSlot.Add(items);
            }

            await _databaseContext.SaveChangesAsync().ConfigureAwait(false);

            return homeCarePackageSlots;
        }

    }

}
