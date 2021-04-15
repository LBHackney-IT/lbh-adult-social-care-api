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
                            DayId = item.DayId
                        })
                    .ToList()
            };
        }

        // TODO change to auto mapper
        public static HomeCarePackageSlotListDomain ToDomain(
            HomeCarePackageSlotsRequestList homeCarePackageSlotsResponseList)
        {
            homeCarePackageSlotsResponseList = null;

            return new HomeCarePackageSlotListDomain
            {
                //Id = homeCarePackageSlotsResponseList.Id,
                //HomeCarePackageId = homeCarePackageSlotsResponseList.HomeCarePackageId,
                //ServiceId = homeCarePackageSlotsResponseList.ServiceId,
                //PrimaryCarer = homeCarePackageSlotsResponseList.PrimaryCarer,
                //SecondaryCarer = homeCarePackageSlotsResponseList.SecondaryCarer,
                //NeedToAddress = homeCarePackageSlotsResponseList.NeedToAddress,
                //WhatShouldBeDone = homeCarePackageSlotsResponseList.WhatShouldBeDone,
                //HomeCarePackageSlot = homeCarePackageSlotsResponseList.HomeCarePackageSlotRequest.Select(item
                //        => new HomeCarePackageSlotDomain
                //        {
                //            InMinutes = item.InMinutes, TimeSlotShiftId = item.TimeSlotShiftId,
                //        })
                //    .ToList()
            };
        }

    }

}
