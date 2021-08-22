using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;

namespace LBH.AdultSocialCare.Api.V1.Gateways.DayCare.Interfaces
{
    public interface IDayCareCollegeGateway
    {
        Task<int> CreateDayCareCollege(DayCareCollege dayCareCollege);

        Task<DayCareCollegeDomain> GetDayCareCollege(int dayCareCollegeId);

        Task<IEnumerable<DayCareCollegeDomain>> GetDayCareCollegeList();
    }
}
