using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.Infrastructure;
using BaseApi.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.Gateways
{
    public class TimeSlotShiftsGateway : ITimeSlotShiftsGateway
    {
        private readonly DatabaseContext _databaseContext;

        public TimeSlotShiftsGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> DeleteAsync(Guid timeSlotShiftsId)
        {
            var result = _databaseContext.TimeSlotShifts.Remove(new TimeSlotShifts() { Id = timeSlotShiftsId });
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return isSuccess;
        }

        public async Task<TimeSlotShifts> GetAsync(Guid timeSlotShiftsId)
        {
            return await _databaseContext.TimeSlotShifts.FirstOrDefaultAsync(item => item.Id == timeSlotShiftsId).ConfigureAwait(false);
        }

        public async Task<IList<TimeSlotShifts>> ListAsync()
        {
            return await _databaseContext.GetTimeSlotShiftsAsync().ConfigureAwait(false);
        }

        public async Task<TimeSlotShifts> UpsertAsync(TimeSlotShifts timeSlotShifts)
        {
            TimeSlotShifts timeSlotShiftsToUpdate = await _databaseContext.TimeSlotShifts.FirstOrDefaultAsync(item => item.TimeSlotShiftName == timeSlotShifts.TimeSlotShiftName).ConfigureAwait(false);
            if (timeSlotShiftsToUpdate == null)
            {
                timeSlotShiftsToUpdate = new TimeSlotShifts();
                await _databaseContext.TimeSlotShifts.AddAsync(timeSlotShiftsToUpdate).ConfigureAwait(false);
                timeSlotShiftsToUpdate.TimeSlotShiftName = timeSlotShifts.TimeSlotShiftName;
                timeSlotShiftsToUpdate.CreatorId = timeSlotShifts.CreatorId;
                timeSlotShiftsToUpdate.DateCreated = timeSlotShifts.DateCreated;
                timeSlotShiftsToUpdate.UpdatorId = timeSlotShifts.UpdatorId;
                timeSlotShiftsToUpdate.DateUpdated = timeSlotShifts.DateUpdated;
                timeSlotShiftsToUpdate.Success = true;
            }
            else
            {
                timeSlotShiftsToUpdate.Message = $"This record already exist Time Slot Shift Name: {timeSlotShifts.TimeSlotShiftName}";
                timeSlotShiftsToUpdate.Success = false;
            }
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return timeSlotShiftsToUpdate;
        }
    }
}
