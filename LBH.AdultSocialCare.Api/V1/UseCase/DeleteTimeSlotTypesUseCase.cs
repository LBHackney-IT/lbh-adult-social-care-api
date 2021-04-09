using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase
{
    public class DeleteTimeSlotTypesUseCase : IDeleteTimeSlotTypesUseCase
    {
        private readonly ITimeSlotTypesGateway _gateway;
        public DeleteTimeSlotTypesUseCase(ITimeSlotTypesGateway timeSlotTypesGateway)
        {
            _gateway = timeSlotTypesGateway;
        }

        public async Task<bool> DeleteAsync(Guid timeSlotTypesId)
        {
            return await _gateway.DeleteAsync(timeSlotTypesId).ConfigureAwait(false);
        }
    }
}
