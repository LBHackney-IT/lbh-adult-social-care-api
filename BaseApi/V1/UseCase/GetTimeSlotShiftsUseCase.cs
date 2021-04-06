using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
{
    public class GetTimeSlotShiftsUseCase : IGetTimeSlotShiftsUseCase
    {
        private readonly ITimeSlotShiftsGateway _gateway;
        public GetTimeSlotShiftsUseCase(ITimeSlotShiftsGateway timeSlotShiftsGateway)
        {
            _gateway = timeSlotShiftsGateway;
        }

        public async Task<TimeSlotShiftsDomain> GetAsync(Guid timeSlotShiftsId)
        {
            var timeSlotShiftsEntity = await _gateway.GetAsync(timeSlotShiftsId).ConfigureAwait(false);
            return TimeSlotShiftsFactory.ToDomain(timeSlotShiftsEntity);
        }
    }
}
