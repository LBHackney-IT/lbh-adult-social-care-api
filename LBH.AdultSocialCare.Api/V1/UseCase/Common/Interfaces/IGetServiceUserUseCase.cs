using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IGetServiceUserUseCase
    {
        Task<ServiceUserResponse> GetServiceUserInformation(int hackneyId);
    }
}
