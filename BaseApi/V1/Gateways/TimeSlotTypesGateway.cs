using BaseApi.V1.Exceptions;
using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.Infrastructure;
using BaseApi.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseApi.V1.Gateways
{
    public class TimeSlotTypesGateway : ITimeSlotTypesGateway
    {
        private readonly DatabaseContext _databaseContext;

        public TimeSlotTypesGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> DeleteAsync(Guid timeSlotTypesId)
        {
            var result = _databaseContext.TimeSlotType.Remove(new TimeSlotType() { Id = timeSlotTypesId });
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return isSuccess;
        }

        public async Task<TimeSlotType> GetAsync(Guid timeSlotTypesId)
        {
            return await _databaseContext.TimeSlotType.FirstOrDefaultAsync(item => item.Id == timeSlotTypesId).ConfigureAwait(false);
        }

        public async Task<IList<TimeSlotType>> ListAsync()
        {
            return await _databaseContext.GetTimeSlotTypesAsync().ConfigureAwait(false);
        }

        public async Task<TimeSlotType> UpsertAsync(TimeSlotType timeSlotTypes)
        {
            TimeSlotType timeSlotTypesToUpdate = await _databaseContext.TimeSlotType.FirstOrDefaultAsync(item => item.TimeSlotTypeName == timeSlotTypes.TimeSlotTypeName).ConfigureAwait(false);
            if (timeSlotTypesToUpdate == null)
            {
                timeSlotTypesToUpdate = new TimeSlotType();
                await _databaseContext.TimeSlotType.AddAsync(timeSlotTypesToUpdate).ConfigureAwait(false);
                timeSlotTypesToUpdate.TimeSlotTypeName = timeSlotTypes.TimeSlotTypeName;
                timeSlotTypesToUpdate.CreatorId = timeSlotTypes.CreatorId;
                timeSlotTypesToUpdate.DateCreated = timeSlotTypes.DateCreated;
                timeSlotTypesToUpdate.UpdatorId = timeSlotTypes.UpdatorId;
                timeSlotTypesToUpdate.DateUpdated = timeSlotTypes.DateUpdated;
            }
            else
            {
                throw new ErrorException($"This record already exist Time Slot Type Name: {timeSlotTypes.TimeSlotTypeName}");
            }
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return timeSlotTypesToUpdate;
        }
    }
}
