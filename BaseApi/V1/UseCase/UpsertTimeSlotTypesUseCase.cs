using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.Infrastructure.Entities;
using BaseApi.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
{
    public class UpsertTimeSlotTypesUseCase : IUpsertTimeSlotTypesUseCase
    {
        private readonly ITimeSlotTypesGateway _gateway;
        public UpsertTimeSlotTypesUseCase(ITimeSlotTypesGateway timeSlotTypesGateway)
        {
            _gateway = timeSlotTypesGateway;
        }

        public async Task<TimeSlotTypesDomain> ExecuteAsync(TimeSlotTypesDomain timeSlotTypes)
        {
            TimeSlotType timeSlotTypeEntity = TimeSlotTypesFactory.ToEntity(timeSlotTypes);
            timeSlotTypeEntity = await _gateway.UpsertAsync(timeSlotTypeEntity).ConfigureAwait(false);
            if (timeSlotTypeEntity == null) return timeSlotTypes = null;
            else
            {
                timeSlotTypes = TimeSlotTypesFactory.ToDomain(timeSlotTypeEntity);
            }
            return timeSlotTypes;
        }
    }
}
