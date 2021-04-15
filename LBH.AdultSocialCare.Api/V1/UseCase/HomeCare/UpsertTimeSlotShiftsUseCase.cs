using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare
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
