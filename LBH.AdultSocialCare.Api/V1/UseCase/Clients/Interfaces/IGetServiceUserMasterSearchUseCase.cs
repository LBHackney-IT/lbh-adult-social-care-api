using HttpServices.Models.Requests;
using HttpServices.Models.Responses;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces
{
    public interface IGetServiceUserMasterSearchUseCase
    {
        Task<ServiceUserInformationResponse> GetServiceUsers(ServiceUserQueryRequest request);
        Task<ServiceUserInformationResponse> GetServiceUsersNew(ServiceUserQueryRequest request);
    }
}
