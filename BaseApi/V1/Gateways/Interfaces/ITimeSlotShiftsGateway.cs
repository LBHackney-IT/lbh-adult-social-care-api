using BaseApi.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseApi.V1.Gateways.Interfaces
{
    public interface ITimeSlotShiftsGateway
    {
        public Task<TimeSlotShifts> UpsertAsync(TimeSlotShifts timeSlotShifts);

        public Task<TimeSlotShifts> GetAsync(Guid timeSlotShiftsId);

        public Task<IList<TimeSlotShifts>> ListAsync();

        public Task<bool> DeleteAsync(Guid timeSlotShiftsId);
    }
}
