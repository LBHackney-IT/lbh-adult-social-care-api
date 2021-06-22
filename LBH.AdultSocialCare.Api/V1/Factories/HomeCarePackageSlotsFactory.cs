using System;
using LBH.AdultSocialCare.Api.V1.Boundary.Request.HomeCare;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using System.Linq;

namespace LBH.AdultSocialCare.Api.V1.Factories
{

    public static class HomeCarePackageSlotsFactory
    {

        // TODO change to auto mapper
        public static HomeCarePackageSlotsResponseList ToResponse(
            HomeCarePackageSlotListDomain homeCarePackageSlotListDomain)
        {
            return new HomeCarePackageSlotsResponseList
            {
                Id = homeCarePackageSlotListDomain.Id,
                HomeCarePackageId = homeCarePackageSlotListDomain.HomeCarePackageId,
                HomeCarePackageSlots = homeCarePackageSlotListDomain.HomeCarePackageSlots.Select(item
                        => new HomeCarePackageSlotResponse
                        {
                            ServiceId = item.ServiceId,
                            NeedToAddress = item.NeedToAddress,
                            WhatShouldBeDone = item.WhatShouldBeDone,
                            PrimaryInMinutes = item.PrimaryInMinutes,
                            SecondaryInMinutes = item.SecondaryInMinutes,
                            TimeSlotShiftId = item.TimeSlotShiftId,
                            TimeSlotShift = item.TimeSlotShift,
                            DayId = item.DayId,
                            Service = item.Service,
                            Day = ((DayOfWeek) item.DayId).ToString()
                        })
                    .ToList()
            };
        }

        // TODO change to auto mapper
        public static HomeCarePackageSlotListDomain ToDomain(
            HomeCarePackageSlotsRequestList homeCarePackageSlotsResponseList)
        {
            return new HomeCarePackageSlotListDomain
            {
                HomeCarePackageId = homeCarePackageSlotsResponseList.HomeCarePackageId,
                HomeCarePackageSlots = homeCarePackageSlotsResponseList.HomeCarePackageSlots.Select(item
                        => new HomeCarePackageSlotDomain
                        {
                            DayId = item.DayId,
                            NeedToAddress = item.NeedToAddress,
                            WhatShouldBeDone = item.WhatShouldBeDone,
                            PrimaryInMinutes = item.PrimaryInMinutes,
                            SecondaryInMinutes = item.SecondaryInMinutes,
                            ServiceId = item.ServiceId,
                            TimeSlotShiftId = item.TimeSlotShiftId
                        })
                    .ToList()
            };
        }

    }

}
