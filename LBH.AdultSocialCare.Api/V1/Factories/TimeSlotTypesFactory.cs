using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.Factories
{
    public static class TimeSlotTypesFactory
    {
        public static TimeSlotTypesDomain ToDomain(TimeSlotType timeSlotTypesEntity)
        {
            return new TimeSlotTypesDomain
            {
                Id = timeSlotTypesEntity.Id,
                TimeSlotTypeName = timeSlotTypesEntity.TimeSlotTypeName,
                CreatorId = timeSlotTypesEntity.CreatorId,
                DateCreated = timeSlotTypesEntity.DateCreated,
                UpdatorId = timeSlotTypesEntity.UpdatorId,
                DateUpdated = timeSlotTypesEntity.DateUpdated
            };
        }

        public static TimeSlotType ToEntity(TimeSlotTypesDomain timeSlotTypesDomain)
        {
            return new TimeSlotType
            {
                Id = timeSlotTypesDomain.Id,
                TimeSlotTypeName = timeSlotTypesDomain.TimeSlotTypeName,
                CreatorId = timeSlotTypesDomain.CreatorId,
                UpdatorId = timeSlotTypesDomain.UpdatorId
            };
        }

        public static TimeSlotTypesResponse ToResponse(TimeSlotTypesDomain timeSlotTypesDomain)
        {
            return new TimeSlotTypesResponse
            {
                Id = timeSlotTypesDomain.Id,
                TimeSlotTypeName = timeSlotTypesDomain.TimeSlotTypeName,
                CreatorId = timeSlotTypesDomain.CreatorId,
                DateCreated = timeSlotTypesDomain.DateCreated,
                UpdatorId = timeSlotTypesDomain.UpdatorId,
                DateUpdated = timeSlotTypesDomain.DateUpdated
            };
        }

        public static TimeSlotTypesDomain ToDomain(TimeSlotTypeRequest timeSlotTypesEntity)
        {
            return new TimeSlotTypesDomain
            {
                Id = timeSlotTypesEntity.Id,
                TimeSlotTypeName = timeSlotTypesEntity.TimeSlotTypeName,
                CreatorId = timeSlotTypesEntity.CreatorId,
                DateCreated = timeSlotTypesEntity.DateCreated,
                UpdatorId = timeSlotTypesEntity.UpdatorId,
                DateUpdated = timeSlotTypesEntity.DateUpdated
            };
        }
    }
}
