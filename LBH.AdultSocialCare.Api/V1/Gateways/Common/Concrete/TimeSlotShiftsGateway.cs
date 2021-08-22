using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete
{
    public class TimeSlotShiftsGateway : ITimeSlotShiftsGateway
    {
        private readonly DatabaseContext _databaseContext;

        public TimeSlotShiftsGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> DeleteAsync(int timeSlotShiftsId)
        {
            var result = _databaseContext.TimeSlotShifts.Remove(new TimeSlotShifts
            {
                Id = timeSlotShiftsId
            });
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;

            return isSuccess;
        }

        public async Task<TimeSlotShifts> GetAsync(int timeSlotShiftsId)
        {
            return await _databaseContext.TimeSlotShifts.FirstOrDefaultAsync(item => item.Id == timeSlotShiftsId)
                .ConfigureAwait(false);
        }

        public async Task<IList<TimeSlotShifts>> ListAsync()
        {
            return await _databaseContext.TimeSlotShifts.ToListAsync().ConfigureAwait(false);
        }

        public async Task<TimeSlotShifts> UpsertAsync(TimeSlotShifts timeSlotShifts)
        {
            TimeSlotShifts timeSlotShiftsToUpdate = await _databaseContext.TimeSlotShifts
                .FirstOrDefaultAsync(item => item.TimeSlotShiftName == timeSlotShifts.TimeSlotShiftName)
                .ConfigureAwait(false);

            if (timeSlotShiftsToUpdate == null)
            {
                timeSlotShiftsToUpdate = new TimeSlotShifts();
                await _databaseContext.TimeSlotShifts.AddAsync(timeSlotShiftsToUpdate).ConfigureAwait(false);
                timeSlotShiftsToUpdate.TimeSlotShiftName = timeSlotShifts.TimeSlotShiftName;
                timeSlotShiftsToUpdate.CreatorId = timeSlotShifts.CreatorId;
                timeSlotShiftsToUpdate.UpdaterId = timeSlotShifts.UpdaterId;
                timeSlotShiftsToUpdate.DateUpdated = timeSlotShifts.DateUpdated;
            }
            else
            {
                throw new ApiException(
                    $"This record already exist Time Slot Shift Name: {timeSlotShifts.TimeSlotShiftName}");
            }

            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;

            return timeSlotShiftsToUpdate;
        }
    }
}
