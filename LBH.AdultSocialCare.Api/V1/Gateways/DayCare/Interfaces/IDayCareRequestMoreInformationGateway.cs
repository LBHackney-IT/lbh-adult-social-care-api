using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCareBrokerage;

namespace LBH.AdultSocialCare.Api.V1.Gateways.DayCare.Interfaces
{
    public interface IDayCareRequestMoreInformationGateway
    {
        public Task<bool> CreateAsync(DayCareRequestMoreInformation dayCareRequestMoreInformationCreation);
    }
}
