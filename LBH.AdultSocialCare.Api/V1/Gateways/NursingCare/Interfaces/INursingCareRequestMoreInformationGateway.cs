using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces
{
    public interface INursingCareRequestMoreInformationGateway
    {
        public Task<bool> CreateAsync(NursingCareRequestMoreInformation nursingCareRequestMoreInformationCreation);
    }
}
