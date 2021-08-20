using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces
{

    public interface IGetTimeSlotShiftsUseCase
    {

        public Task<TimeSlotShiftsDomain> GetAsync(int timeSlotTypesId);

    }

}
