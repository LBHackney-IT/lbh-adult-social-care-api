using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;

namespace LBH.AdultSocialCare.Api.V1.Factories
{
    public static class TimeSlotShiftsFactory
    {
        public static TimeSlotShiftsDomain ToDomain(TimeSlotShifts timeSlotShiftsEntity)
        {
            return new TimeSlotShiftsDomain
            {
                Id = timeSlotShiftsEntity.Id,
                TimeSlotShiftName = timeSlotShiftsEntity.TimeSlotShiftName,
                CreatorId = timeSlotShiftsEntity.CreatorId,
                DateCreated = timeSlotShiftsEntity.DateCreated,
                UpdatorId = timeSlotShiftsEntity.UpdatorId,
                DateUpdated = timeSlotShiftsEntity.DateUpdated
            };
        }

        public static TimeSlotShifts ToEntity(TimeSlotShiftsDomain timeSlotShiftsDomain)
        {
            return new TimeSlotShifts
            {
                Id = timeSlotShiftsDomain.Id,
                TimeSlotShiftName = timeSlotShiftsDomain.TimeSlotShiftName,
                CreatorId = timeSlotShiftsDomain.CreatorId,
                UpdatorId = timeSlotShiftsDomain.UpdatorId
            };
        }

        public static TimeSlotShiftsResponse ToResponse(TimeSlotShiftsDomain timeSlotShiftsDomain)
        {
            return new TimeSlotShiftsResponse
            {
                Id = timeSlotShiftsDomain.Id,
                TimeSlotShiftName = timeSlotShiftsDomain.TimeSlotShiftName,
                CreatorId = timeSlotShiftsDomain.CreatorId,
                DateCreated = timeSlotShiftsDomain.DateCreated,
                UpdatorId = timeSlotShiftsDomain.UpdatorId,
                DateUpdated = timeSlotShiftsDomain.DateUpdated
            };
        }

        public static TimeSlotShiftsDomain ToDomain(TimeSlotShiftsRequest timeSlotShiftsEntity)
        {
            return new TimeSlotShiftsDomain
            {
                Id = timeSlotShiftsEntity.Id,
                TimeSlotShiftName = timeSlotShiftsEntity.TimeSlotShiftName,
                CreatorId = timeSlotShiftsEntity.CreatorId,
                DateCreated = timeSlotShiftsEntity.DateCreated,
                UpdatorId = timeSlotShiftsEntity.UpdatorId,
                DateUpdated = timeSlotShiftsEntity.DateUpdated
            };
        }
    }
}
