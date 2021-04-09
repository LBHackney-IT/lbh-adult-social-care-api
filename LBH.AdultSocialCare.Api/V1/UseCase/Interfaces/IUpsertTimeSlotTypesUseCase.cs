using LBH.AdultSocialCare.Api.V1.Domain;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface IUpsertTimeSlotTypesUseCase
    {
        public Task<TimeSlotTypesDomain> ExecuteAsync(TimeSlotTypesDomain timeSlotTypes);
    }
}
