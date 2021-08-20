using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces
{

    public interface IDeleteTimeSlotShiftsUseCase
    {

        public Task<bool> DeleteAsync(int timeSlotShiftsId);

    }

}
