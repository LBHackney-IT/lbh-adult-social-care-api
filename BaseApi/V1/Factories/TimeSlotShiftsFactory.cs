using BaseApi.V1.Boundary.Response;
using BaseApi.V1.Domain;
using BaseApi.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.Factories
{
    public static class TimeSlotShiftsFactory
    {
        public static TimeSlotShiftsDomain ToDomain(TimeSlotShifts timeSlotShiftsEntity)
        {
            return new TimeSlotShiftsDomain()
            {
                Id = timeSlotShiftsEntity.Id,
                TimeSlotShiftName = timeSlotShiftsEntity.TimeSlotShiftName,
                CreatorId = timeSlotShiftsEntity.CreatorId,
                DateCreated = timeSlotShiftsEntity.DateCreated,
                UpdatorId = timeSlotShiftsEntity.UpdatorId,
                DateUpdated = timeSlotShiftsEntity.DateUpdated,
                Success = timeSlotShiftsEntity.Success,
                Message = timeSlotShiftsEntity.Message
            };
        }

        public static TimeSlotShifts ToEntity(TimeSlotShiftsDomain timeSlotShiftsDomain)
        {
            return new TimeSlotShifts()
            {
                Id = timeSlotShiftsDomain.Id,
                TimeSlotShiftName = timeSlotShiftsDomain.TimeSlotShiftName,
                CreatorId = timeSlotShiftsDomain.CreatorId,
                DateCreated = timeSlotShiftsDomain.DateCreated,
                UpdatorId = timeSlotShiftsDomain.UpdatorId,
                DateUpdated = timeSlotShiftsDomain.DateUpdated,
                Success = timeSlotShiftsDomain.Success,
                Message = timeSlotShiftsDomain.Message
            };
        }

        public static TimeSlotShiftsResponse ToResponse(TimeSlotShiftsDomain timeSlotShiftsDomain)
        {
            return new TimeSlotShiftsResponse()
            {
                Id = timeSlotShiftsDomain.Id,
                TimeSlotShiftName = timeSlotShiftsDomain.TimeSlotShiftName,
                CreatorId = timeSlotShiftsDomain.CreatorId,
                DateCreated = timeSlotShiftsDomain.DateCreated,
                UpdatorId = timeSlotShiftsDomain.UpdatorId,
                DateUpdated = timeSlotShiftsDomain.DateUpdated,
                Success = timeSlotShiftsDomain.Success,
                Message = timeSlotShiftsDomain.Message
            };
        }

        public static TimeSlotShiftsDomain ToDomain(TimeSlotShiftsResponse timeSlotShiftsEntity)
        {
            return new TimeSlotShiftsDomain()
            {
                Id = timeSlotShiftsEntity.Id,
                TimeSlotShiftName = timeSlotShiftsEntity.TimeSlotShiftName,
                CreatorId = timeSlotShiftsEntity.CreatorId,
                DateCreated = timeSlotShiftsEntity.DateCreated,
                UpdatorId = timeSlotShiftsEntity.UpdatorId,
                DateUpdated = timeSlotShiftsEntity.DateUpdated,
                Success = timeSlotShiftsEntity.Success,
                Message = timeSlotShiftsEntity.Message
            };
        }
    }
}
