using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare
{
    public class GetAllTimeSlotTypesUseCase : IGetAllTimeSlotTypesUseCase
    {
        private readonly ITimeSlotTypesGateway _gateway;
        public GetAllTimeSlotTypesUseCase(ITimeSlotTypesGateway timeSlotTypesGateway)
        {
            _gateway = timeSlotTypesGateway;
        }
        public async Task<IList<TimeSlotType>> GetAllAsync()
        {
            return await _gateway.ListAsync().ConfigureAwait(false);
        }
    }
}
