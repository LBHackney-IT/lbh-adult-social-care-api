using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Concrete
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

            return timeSlotShiftsEntity?.ToDomain();
        }
    }
}
