using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase
{
    public class UpsertTimeSlotTypesUseCase : IUpsertTimeSlotTypesUseCase
    {
        private readonly ITimeSlotTypesGateway _gateway;
        public UpsertTimeSlotTypesUseCase(ITimeSlotTypesGateway timeSlotTypesGateway)
        {
            _gateway = timeSlotTypesGateway;
        }

        public async Task<TimeSlotTypesDomain> ExecuteAsync(TimeSlotTypesDomain timeSlotTypes)
        {
            TimeSlotType timeSlotTypeEntity = TimeSlotTypesFactory.ToEntity(timeSlotTypes);
            timeSlotTypeEntity = await _gateway.UpsertAsync(timeSlotTypeEntity).ConfigureAwait(false);
            if (timeSlotTypeEntity == null) return timeSlotTypes = null;
            else
            {
                timeSlotTypes = TimeSlotTypesFactory.ToDomain(timeSlotTypeEntity);
            }
            return timeSlotTypes;
        }
    }
}
