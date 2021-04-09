using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase
{
    public class DeleteTimeSlotShiftsUseCase : IDeleteTimeSlotShiftsUseCase
    {
        private readonly ITimeSlotShiftsGateway _gateway;
        public DeleteTimeSlotShiftsUseCase(ITimeSlotShiftsGateway timeSlotShiftsGateway)
        {
            _gateway = timeSlotShiftsGateway;
        }

        public async Task<bool> DeleteAsync(Guid timeSlotShiftsId)
        {
            return await _gateway.DeleteAsync(timeSlotShiftsId).ConfigureAwait(false);
        }
    }
}
