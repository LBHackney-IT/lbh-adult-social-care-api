using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces
{
    public interface IUpsertTimeSlotShiftsUseCase
    {
        public Task<TimeSlotShiftsDomain> ExecuteAsync(TimeSlotShiftsDomain timeSlotShifts);
    }
}
