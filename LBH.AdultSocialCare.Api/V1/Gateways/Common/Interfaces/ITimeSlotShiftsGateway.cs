using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{

    public interface ITimeSlotShiftsGateway
    {

        public Task<TimeSlotShifts> UpsertAsync(TimeSlotShifts timeSlotShifts);

        public Task<TimeSlotShifts> GetAsync(int timeSlotShiftsId);

        public Task<IList<TimeSlotShifts>> ListAsync();

        public Task<bool> DeleteAsync(int timeSlotShiftsId);

    }

}
