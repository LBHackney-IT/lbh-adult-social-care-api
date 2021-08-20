using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces
{
    public interface ICreateNursingCareRequestMoreInformationUseCase
    {
        public Task<bool> Execute(NursingCareRequestMoreInformationDomain nursingCareRequestMoreInformation);
    }
}
