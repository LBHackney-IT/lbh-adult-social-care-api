using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces
{
    public interface IGetAllTimeSlotShiftsUseCase
    {
        public Task<IList<TimeSlotShifts>> GetAllAsync();
    }
}
