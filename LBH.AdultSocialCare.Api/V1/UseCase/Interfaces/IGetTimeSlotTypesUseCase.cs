using LBH.AdultSocialCare.Api.V1.Domain;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IGetTimeSlotTypesUseCase
    {
        public Task<TimeSlotTypesDomain> GetAsync(Guid timeSlotTypesId);
    }
}
