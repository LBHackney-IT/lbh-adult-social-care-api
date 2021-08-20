using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare
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
