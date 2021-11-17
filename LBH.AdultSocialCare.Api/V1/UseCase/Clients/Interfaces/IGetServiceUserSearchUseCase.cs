using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces
{
    public interface IGetServiceUserSearchUseCase
    {
        Task<PagedResponse<ServiceUserResponse>> GetServiceUsers(ServiceUserQueryParameters parameters);
    }
}
