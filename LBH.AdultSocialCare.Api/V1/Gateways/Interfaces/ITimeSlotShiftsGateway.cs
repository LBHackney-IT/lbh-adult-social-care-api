using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Interfaces
{

    public interface ITimeSlotShiftsGateway
    {

        public Task<TimeSlotShifts> UpsertAsync(TimeSlotShifts timeSlotShifts);

        public Task<TimeSlotShifts> GetAsync(int timeSlotShiftsId);

        public Task<IList<TimeSlotShifts>> ListAsync();

        public Task<bool> DeleteAsync(int timeSlotShiftsId);

    }

}
