using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Concrete
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
            TimeSlotShifts timeSlotShiftsEntity = timeSlotShifts.ToEntity();
            timeSlotShiftsEntity = await _gateway.UpsertAsync(timeSlotShiftsEntity).ConfigureAwait(false);
            return timeSlotShiftsEntity?.ToDomain();
        }
    }
}
