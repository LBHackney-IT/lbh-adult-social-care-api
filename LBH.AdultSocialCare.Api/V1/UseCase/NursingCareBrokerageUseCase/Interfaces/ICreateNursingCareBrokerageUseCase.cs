using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareBrokerageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareBrokerageDomains;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareBrokerageUseCase.Interfaces
{
    public interface ICreateNursingCareBrokerageUseCase
    {
        Task<NursingCareBrokerageInfoResponse> ExecuteAsync(NursingCareBrokerageInfoCreationDomain nursingCareBrokerageInfoCreationDomain);
    }
}
