using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces
{
    public interface IGetServiceUserSearchUseCase
    {
        Task<PagedResponse<ServiceUserResponse>> GetServiceUsers(ServiceUserQueryParameters parameters);
    }
}
