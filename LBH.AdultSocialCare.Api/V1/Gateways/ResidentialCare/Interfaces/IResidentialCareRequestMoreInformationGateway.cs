using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces
{
    public interface IResidentialCareRequestMoreInformationGateway
    {
        public Task<bool> CreateAsync(ResidentialCareRequestMoreInformation residentialCareRequestMoreInformationCreation);
    }
}
