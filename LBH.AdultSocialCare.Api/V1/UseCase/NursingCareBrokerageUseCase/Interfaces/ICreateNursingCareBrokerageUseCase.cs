using LBH.AdultSocialCare.Api.V1.Domain.NursingCareBrokerageDomains;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareBrokerageUseCase.Interfaces
{
    public interface ICreateNursingCareBrokerageUseCase
    {
        Task<NursingCareBrokerageInfoResponse> ExecuteAsync(NursingCareBrokerageInfoCreationDomain nursingCareBrokerageInfoCreationDomain);
    }
}
