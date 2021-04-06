using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
{
    public class DeleteTimeSlotShiftsUseCase : IDeleteTimeSlotShiftsUseCase
    {
        private readonly ITimeSlotShiftsGateway _gateway;
        public DeleteTimeSlotShiftsUseCase(ITimeSlotShiftsGateway timeSlotShiftsGateway)
        {
            _gateway = timeSlotShiftsGateway;
        }

        public async Task<bool> DeleteAsync(Guid timeSlotShiftsId)
        {
            return await _gateway.DeleteAsync(timeSlotShiftsId).ConfigureAwait(false);
        }
    }
}
