using BaseApi.V1.Boundary.Response;
using BaseApi.V1.Domain;
using BaseApi.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.Factories
{
    public static class TimeSlotTypesFactory
    {
        public static TimeSlotTypesDomain ToDomain(TimeSlotType timeSlotTypesEntity)
        {
            return new TimeSlotTypesDomain()
            {
                Id = timeSlotTypesEntity.Id,
                TimeSlotTypeName = timeSlotTypesEntity.TimeSlotTypeName,
                CreatorId = timeSlotTypesEntity.CreatorId,
                DateCreated = timeSlotTypesEntity.DateCreated,
                UpdatorId = timeSlotTypesEntity.UpdatorId,
                DateUpdated = timeSlotTypesEntity.DateUpdated,
                Success = timeSlotTypesEntity.Success,
                Message = timeSlotTypesEntity.Message
            };
        }

        public static TimeSlotType ToEntity(TimeSlotTypesDomain timeSlotTypesDomain)
        {
            return new TimeSlotType()
            {
                Id = timeSlotTypesDomain.Id,
                TimeSlotTypeName = timeSlotTypesDomain.TimeSlotTypeName,
                CreatorId = timeSlotTypesDomain.CreatorId,
                DateCreated = timeSlotTypesDomain.DateCreated,
                UpdatorId = timeSlotTypesDomain.UpdatorId,
                DateUpdated = timeSlotTypesDomain.DateUpdated,
                Success = timeSlotTypesDomain.Success,
                Message = timeSlotTypesDomain.Message
            };
        }

        public static TimeSlotTypesResponse ToResponse(TimeSlotTypesDomain timeSlotTypesDomain)
        {
            return new TimeSlotTypesResponse()
            {
                Id = timeSlotTypesDomain.Id,
                TimeSlotTypeName = timeSlotTypesDomain.TimeSlotTypeName,
                CreatorId = timeSlotTypesDomain.CreatorId,
                DateCreated = timeSlotTypesDomain.DateCreated,
                UpdatorId = timeSlotTypesDomain.UpdatorId,
                DateUpdated = timeSlotTypesDomain.DateUpdated,
                Success = timeSlotTypesDomain.Success,
                Message = timeSlotTypesDomain.Message
            };
        }

        public static TimeSlotTypesDomain ToDomain(TimeSlotTypesResponse timeSlotTypesEntity)
        {
            return new TimeSlotTypesDomain()
            {
                Id = timeSlotTypesEntity.Id,
                TimeSlotTypeName = timeSlotTypesEntity.TimeSlotTypeName,
                CreatorId = timeSlotTypesEntity.CreatorId,
                DateCreated = timeSlotTypesEntity.DateCreated,
                UpdatorId = timeSlotTypesEntity.UpdatorId,
                DateUpdated = timeSlotTypesEntity.DateUpdated,
                Success = timeSlotTypesEntity.Success,
                Message = timeSlotTypesEntity.Message
            };
        }
    }
}
