using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces
{
    public interface IGetServiceUsersUseCase
    {
        Task<PagedResponse<ServiceUserResponse>> GetAllAsync(RequestParameters parameters, string clientName);
    }
}