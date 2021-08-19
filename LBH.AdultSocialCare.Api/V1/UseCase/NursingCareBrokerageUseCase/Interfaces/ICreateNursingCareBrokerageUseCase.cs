using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareBrokerageUseCase.Interfaces
{
    public interface ICreateNursingCareBrokerageUseCase
    {
        Task<NursingCareBrokerageInfoResponse> ExecuteAsync(NursingCareBrokerageInfoCreationDomain nursingCareBrokerageInfoCreationDomain);
    }
}
