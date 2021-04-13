using LBH.AdultSocialCare.Api.V1.Exceptions;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways
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
            var result = _databaseContext.TimeSlotShifts.Remove(new TimeSlotShifts
                { Id = timeSlotShiftsId });
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return isSuccess;
        }

        public async Task<TimeSlotShifts> GetAsync(Guid timeSlotShiftsId)
        {
            return await _databaseContext.TimeSlotShifts.FirstOrDefaultAsync(item => item.Id == timeSlotShiftsId).ConfigureAwait(false);
        }

        public async Task<IList<TimeSlotShifts>> ListAsync()
        {
            return await _databaseContext.TimeSlotShifts.ToListAsync().ConfigureAwait(false);
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
                timeSlotShiftsToUpdate.UpdatorId = timeSlotShifts.UpdatorId;
                timeSlotShiftsToUpdate.DateUpdated = timeSlotShifts.DateUpdated;
            }
            else
            {
                throw new ErrorException($"This record already exist Time Slot Shift Name: {timeSlotShifts.TimeSlotShiftName}");
            }
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return timeSlotShiftsToUpdate;
        }
    }
}
