using BaseApi.V1.Boundary.Response;
using BaseApi.V1.Domain;
using BaseApi.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.Factories
{
    public static class HomeCarePackageSlotsFactory
    {
        public static HomeCarePackageSlotsDomain ToDomain(HomeCarePackageSlotsList homeCarePackageSlotsEntity)
        {
            return new HomeCarePackageSlotsDomain()
            {
                Id = homeCarePackageSlotsEntity.Id,
                HomeCarePackageId = homeCarePackageSlotsEntity.HomeCarePackageId,
                ServiceId = homeCarePackageSlotsEntity.ServiceId,
                Services = homeCarePackageSlotsEntity.Services,
                PrimaryCarer = homeCarePackageSlotsEntity.PrimaryCarer,
                SecondaryCarer = homeCarePackageSlotsEntity.SecondaryCarer,
                NeedToAddress = homeCarePackageSlotsEntity.NeedToAddress,
                WhatShouldBeDone = homeCarePackageSlotsEntity.WhatShouldBeDone,
                HomeCarePackageSlot = homeCarePackageSlotsEntity.HomeCarePackageSlot.Select(item => new HomeCarePackageSlotDomain
                {
                    InHours = item.InHours,
                    InMinutes = item.InMinutes,
                    Time = item.Time,
                    TimeSlotShiftId = item.TimeSlotShiftId,
                    TimeSlotShift = item.TimeSlotShift,
                    TimeSlotTypeId = item.TimeSlotTypeId,
                    TimeSlotTypes = item.TimeSlotTypes
                })
                .ToList()
            };
        }

        public static HomeCarePackageSlotsList ToEntity(HomeCarePackageSlotsDomain homeCarePackageSlotsDomain)
        {
            return new HomeCarePackageSlotsList()
            {
                Id = homeCarePackageSlotsDomain.Id,
                HomeCarePackageId = homeCarePackageSlotsDomain.HomeCarePackageId,
                ServiceId = homeCarePackageSlotsDomain.ServiceId,
                Services = homeCarePackageSlotsDomain.Services,
                PrimaryCarer = homeCarePackageSlotsDomain.PrimaryCarer,
                SecondaryCarer = homeCarePackageSlotsDomain.SecondaryCarer,
                NeedToAddress = homeCarePackageSlotsDomain.NeedToAddress,
                WhatShouldBeDone = homeCarePackageSlotsDomain.WhatShouldBeDone,
                HomeCarePackageSlot = homeCarePackageSlotsDomain.HomeCarePackageSlot.Select(item => new HomeCarePackageSlot
                {
                     InHours = item.InHours,
                     InMinutes = item.InMinutes,
                     Time = item.Time,
                     TimeSlotShiftId = item.TimeSlotShiftId,
                     TimeSlotShift = item.TimeSlotShift,
                     TimeSlotTypeId = item.TimeSlotTypeId,
                     TimeSlotTypes = item.TimeSlotTypes
                 })
                .ToList()
            };
        }

        public static HomeCarePackageSlotsResponseList ToResponse(HomeCarePackageSlotsDomain homeCarePackageSlotsDomain)
        {
            return new HomeCarePackageSlotsResponseList()
            {
                Id = homeCarePackageSlotsDomain.Id,
                HomeCarePackageId = homeCarePackageSlotsDomain.HomeCarePackageId,
                ServiceId = homeCarePackageSlotsDomain.ServiceId,
                Services = homeCarePackageSlotsDomain.Services,
                PrimaryCarer = homeCarePackageSlotsDomain.PrimaryCarer,
                SecondaryCarer = homeCarePackageSlotsDomain.SecondaryCarer,
                NeedToAddress = homeCarePackageSlotsDomain.NeedToAddress,
                WhatShouldBeDone = homeCarePackageSlotsDomain.WhatShouldBeDone,
                HomeCarePackageSlotResponse = homeCarePackageSlotsDomain.HomeCarePackageSlot.Select(item => new HomeCarePackageSlotResponse
                {
                    InHours = item.InHours,
                    InMinutes = item.InMinutes,
                    Time = item.Time,
                    TimeSlotShiftId = item.TimeSlotShiftId,
                    TimeSlotShift = item.TimeSlotShift,
                    TimeSlotTypeId = item.TimeSlotTypeId,
                    TimeSlotTypes = item.TimeSlotTypes,

                })
                .ToList()
            };
        }

        public static HomeCarePackageSlotsDomain ToDomain(HomeCarePackageSlotsResponseList homeCarePackageSlotsResponseList)
        {
            return new HomeCarePackageSlotsDomain()
            {
                Id = homeCarePackageSlotsResponseList.Id,
                HomeCarePackageId = homeCarePackageSlotsResponseList.HomeCarePackageId,
                ServiceId = homeCarePackageSlotsResponseList.ServiceId,
                Services = homeCarePackageSlotsResponseList.Services,
                PrimaryCarer = homeCarePackageSlotsResponseList.PrimaryCarer,
                SecondaryCarer = homeCarePackageSlotsResponseList.SecondaryCarer,
                NeedToAddress = homeCarePackageSlotsResponseList.NeedToAddress,
                WhatShouldBeDone = homeCarePackageSlotsResponseList.WhatShouldBeDone,
                HomeCarePackageSlot = homeCarePackageSlotsResponseList.HomeCarePackageSlotResponse.Select(item => new HomeCarePackageSlotDomain
                {
                    InHours = item.InHours,
                    InMinutes = item.InMinutes,
                    Time = item.Time,
                    TimeSlotShiftId = item.TimeSlotShiftId,
                    TimeSlotShift = item.TimeSlotShift,
                    TimeSlotTypeId = item.TimeSlotTypeId,
                    TimeSlotTypes = item.TimeSlotTypes,
                })
                .ToList()
            };
        }
    }
}
