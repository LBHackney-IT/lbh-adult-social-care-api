using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IGetAllTimeSlotTypesUseCase
    {
        public Task<IList<TimeSlotType>> GetAllAsync();
    }
}
