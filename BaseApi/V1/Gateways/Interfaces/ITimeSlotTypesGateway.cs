using BaseApi.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseApi.V1.Gateways.Interfaces
{
    public interface ITimeSlotTypesGateway
    {
        public Task<TimeSlotType> UpsertAsync(TimeSlotType timeSlotTypes);

        public Task<TimeSlotType> GetAsync(Guid timeSlotTypesId);

        public Task<IList<TimeSlotType>> ListAsync();

        public Task<bool> DeleteAsync(Guid timeSlotTypesId);
    }
}
