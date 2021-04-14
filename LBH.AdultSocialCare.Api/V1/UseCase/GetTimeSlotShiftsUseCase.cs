using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase
{
    public class GetTimeSlotShiftsUseCase : IGetTimeSlotShiftsUseCase
    {
        private readonly ITimeSlotShiftsGateway _gateway;
        public GetTimeSlotShiftsUseCase(ITimeSlotShiftsGateway timeSlotShiftsGateway)
        {
            _gateway = timeSlotShiftsGateway;
        }

        public async Task<TimeSlotShiftsDomain> GetAsync(int timeSlotShiftsId)
        {
            var timeSlotShiftsEntity = await _gateway.GetAsync(timeSlotShiftsId).ConfigureAwait(false);
            return TimeSlotShiftsFactory.ToDomain(timeSlotShiftsEntity);
        }
    }
}
