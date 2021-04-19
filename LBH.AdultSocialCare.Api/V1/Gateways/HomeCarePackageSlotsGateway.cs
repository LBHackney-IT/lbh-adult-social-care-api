using LBH.AdultSocialCare.Api.V1.Domain;
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

        public async Task<HomeCarePackageSlotListDomain> UpsertAsync(HomeCarePackageSlotListDomain homeCarePackageSlotListList)
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
                .HomeCarePackageSlot)
            {
                HomeCarePackageSlots homeCarePackageSlotsToUpdate = new HomeCarePackageSlots
                {
                    HomeCarePackageId = homeCarePackageSlotListList.HomeCarePackageId,
                    ServiceId = homeCarePackageSlotListList.ServiceId,
                    PrimaryCarer = homeCarePackageSlotListList.PrimaryCarer,
                    SecondaryCarer = homeCarePackageSlotListList.SecondaryCarer,
                    NeedToAddress = homeCarePackageSlotListList.NeedToAddress,
                    WhatShouldBeDone = homeCarePackageSlotListList.WhatShouldBeDone,
                    TimeSlotShiftId = homeCarePackageSlotInputItem.TimeSlotShiftId,
                    InMinutes = homeCarePackageSlotInputItem.InMinutes,
                };

                homeCarePackageSlotList.Services = await _databaseContext.HomeCareServiceTypes
                    .FirstOrDefaultAsync(item => item.Id == homeCarePackageSlotListList.ServiceId)
                    .ConfigureAwait(false);

                homeCarePackageSlotInputItem.TimeSlotShift = await _databaseContext.TimeSlotShifts
                    .FirstOrDefaultAsync(item => item.Id == homeCarePackageSlotInputItem.TimeSlotShiftId)
                    .ConfigureAwait(false);

                //homeCarePackageSlotInputItem.TimeSlotTypes = await _databaseContext.TimeSlotType
                //    .FirstOrDefaultAsync(item => item.Id == homeCarePackageSlotInputItem.TimeSlotTypeId)
                //    .ConfigureAwait(false);

                await _databaseContext.HomeCarePackageSlots.AddAsync(homeCarePackageSlotsToUpdate).ConfigureAwait(false);
                homeCarePackageSlotList.HomeCarePackageSlot.Add(homeCarePackageSlotInputItem);
            }

            success = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) > 0;

            return success
                ? homeCarePackageSlotList
                : null;
        }

    }

}
