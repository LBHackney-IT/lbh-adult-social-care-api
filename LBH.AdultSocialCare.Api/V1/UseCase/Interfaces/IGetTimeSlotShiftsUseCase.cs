using LBH.AdultSocialCare.Api.V1.Domain;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{

    public interface IGetTimeSlotShiftsUseCase
    {

        public Task<TimeSlotShiftsDomain> GetAsync(int timeSlotTypesId);

    }

}
