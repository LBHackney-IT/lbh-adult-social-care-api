using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.Infrastructure.Entities;
using BaseApi.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
{
    public class GetAllTimeSlotTypesUseCase : IGetAllTimeSlotTypesUseCase
    {
        private readonly ITimeSlotTypesGateway _gateway;
        public GetAllTimeSlotTypesUseCase(ITimeSlotTypesGateway timeSlotTypesGateway)
        {
            _gateway = timeSlotTypesGateway;
        }
        public async Task<IList<TimeSlotType>> GetAllAsync()
        {
            return await _gateway.ListAsync().ConfigureAwait(false);
        }
    }
}
