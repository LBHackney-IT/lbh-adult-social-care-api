using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCareRequestMoreInformationUseCase.Interfaces
{
    public interface ICreateHomeCareRequestMoreInformationUseCase
    {
        public Task<bool> Execute(HomeCareRequestMoreInformationDomain homeCareRequestMoreInformation);
    }
}
