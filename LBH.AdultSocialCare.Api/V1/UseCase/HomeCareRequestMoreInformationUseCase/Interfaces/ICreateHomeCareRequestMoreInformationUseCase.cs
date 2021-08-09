using LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerageDomains;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCareRequestMoreInformationUseCase.Interfaces
{
    public interface ICreateHomeCareRequestMoreInformationUseCase
    {
        public Task<bool> Execute(HomeCareRequestMoreInformationDomain homeCareRequestMoreInformation);
    }
}
