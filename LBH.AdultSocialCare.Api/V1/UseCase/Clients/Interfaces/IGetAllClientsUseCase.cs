using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces
{
    public interface IGetAllClientsUseCase
    {
        Task<PagedResponse<ClientsResponse>> GetAllAsync(RequestParameters parameters, string clientName);
    }
}
