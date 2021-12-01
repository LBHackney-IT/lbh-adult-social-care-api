using HttpServices.Models.Requests;
using HttpServices.Models.Responses;
using System.Threading.Tasks;

namespace HttpServices.Services.Contracts
{
    public interface IResidentsService
    {
        Task<ServiceUserInformationResponse> GetServiceUserInformationAsync(int hackneyId);
        Task<ServiceUserInformationResponse> SearchServiceUserInformationAsync(ServiceUserQueryRequest request);
    }
}
