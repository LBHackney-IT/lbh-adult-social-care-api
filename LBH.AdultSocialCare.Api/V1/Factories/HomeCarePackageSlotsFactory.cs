using LBH.AdultSocialCare.Api.V1.Boundary.Request.HomeCare;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using System.Linq;

namespace LBH.AdultSocialCare.Api.V1.Factories
{

    public static class HomeCarePackageSlotsFactory
    {

        public static HomeCarePackageSlotsResponseList ToResponse(
            HomeCarePackageSlotListDomain homeCarePackageSlotListDomain)
        {
            return new HomeCarePackageSlotsResponseList
            {
                Id = homeCarePackageSlotListDomain.Id,
                HomeCarePackageId = homeCarePackageSlotListDomain.HomeCarePackageId,
                ServiceId = homeCarePackageSlotListDomain.ServiceId,
                Services = homeCarePackageSlotListDomain.Services,
                PrimaryCarer = homeCarePackageSlotListDomain.PrimaryCarer,
                SecondaryCarer = homeCarePackageSlotListDomain.SecondaryCarer,
                NeedToAddress = homeCarePackageSlotListDomain.NeedToAddress,
                WhatShouldBeDone = homeCarePackageSlotListDomain.WhatShouldBeDone,
                HomeCarePackageSlotResponse = homeCarePackageSlotListDomain.HomeCarePackageSlot.Select(item
                        => new HomeCarePackageSlotResponse
                        {
                            InMinutes = item.InMinutes,
                            TimeSlotShiftId = item.TimeSlotShiftId,
                            TimeSlotShift = item.TimeSlotShift
                        })
                    .ToList()
            };
        }

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
