using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase
{
    public class GetTimeSlotTypesUseCase : IGetTimeSlotTypesUseCase
    {
        private readonly ITimeSlotTypesGateway _gateway;
        public GetTimeSlotTypesUseCase(ITimeSlotTypesGateway timeSlotTypesGateway)
        {
            _gateway = timeSlotTypesGateway;
        }

        public async Task<TimeSlotTypesDomain> GetAsync(Guid timeSlotTypesId)
        {
            var timeSlotTypesEntity = await _gateway.GetAsync(timeSlotTypesId).ConfigureAwait(false);
            return TimeSlotTypesFactory.ToDomain(timeSlotTypesEntity);
        }
    }
}