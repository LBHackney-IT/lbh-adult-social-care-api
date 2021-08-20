using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCareBrokerage;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces
{
    public interface IHomeCareRequestMoreInformationGateway
    {
        public Task<bool> CreateAsync(HomeCareRequestMoreInformation homeCareRequestMoreInformationCreation);
    }
}
