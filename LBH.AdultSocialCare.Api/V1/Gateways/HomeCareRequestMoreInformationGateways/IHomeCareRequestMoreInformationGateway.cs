using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCareBrokerage;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCareRequestMoreInformationGateways
{
    public interface IHomeCareRequestMoreInformationGateway
    {
        public Task<bool> CreateAsync(HomeCareRequestMoreInformation homeCareRequestMoreInformationCreation);
    }
}
