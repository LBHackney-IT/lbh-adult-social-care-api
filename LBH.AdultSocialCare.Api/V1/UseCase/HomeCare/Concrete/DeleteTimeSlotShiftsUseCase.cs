using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Concrete
{

    public class DeleteTimeSlotShiftsUseCase : IDeleteTimeSlotShiftsUseCase
    {

        private readonly ITimeSlotShiftsGateway _gateway;

        public DeleteTimeSlotShiftsUseCase(ITimeSlotShiftsGateway timeSlotShiftsGateway)
        {
            _gateway = timeSlotShiftsGateway;
        }

        public async Task<bool> DeleteAsync(int timeSlotShiftsId)
        {
            return await _gateway.DeleteAsync(timeSlotShiftsId).ConfigureAwait(false);
        }

    }

}
