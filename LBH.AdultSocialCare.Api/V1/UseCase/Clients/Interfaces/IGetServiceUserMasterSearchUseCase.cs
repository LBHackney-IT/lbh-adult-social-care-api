using HttpServices.Models.Requests;
using HttpServices.Models.Responses;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces
{
    public interface IGetServiceUserMasterSearchUseCase
    {
        Task<ServiceUserSearchResponse> GetServiceUsers(ServiceUserQueryRequest request);
    }
}
