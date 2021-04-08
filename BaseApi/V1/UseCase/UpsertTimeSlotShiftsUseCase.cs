using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.Infrastructure.Entities;
using BaseApi.V1.UseCase.Interfaces;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
{
    public class UpsertTimeSlotShiftsUseCase : IUpsertTimeSlotShiftsUseCase
    {
        private readonly ITimeSlotShiftsGateway _gateway;
        public UpsertTimeSlotShiftsUseCase(ITimeSlotShiftsGateway timeSlotShiftsGateway)
        {
            _gateway = timeSlotShiftsGateway;
        }

        public async Task<TimeSlotShiftsDomain> ExecuteAsync(TimeSlotShiftsDomain timeSlotShifts)
        {
            TimeSlotShifts timeSlotShiftsEntity = TimeSlotShiftsFactory.ToEntity(timeSlotShifts);
            timeSlotShiftsEntity = await _gateway.UpsertAsync(timeSlotShiftsEntity).ConfigureAwait(false);
            if (timeSlotShiftsEntity == null) return timeSlotShifts = null;
            else
            {
                timeSlotShifts = TimeSlotShiftsFactory.ToDomain(timeSlotShiftsEntity);
            }
            return timeSlotShifts;
        }
    }
}
