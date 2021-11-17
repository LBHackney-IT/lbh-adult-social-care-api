using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces
{
    public interface IGetServiceUsersUseCase
    {
        Task<PagedResponse<ServiceUserResponse>> GetAllAsync(RequestParameters parameters, string clientName);
    }
}
