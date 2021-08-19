using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;

namespace LBH.AdultSocialCare.Api.V1.UseCase.SupplierUseCases.Interfaces
{
    public interface IGetAllSupplierUseCase
    {
        public Task<PagedResponse<SupplierResponse>> GetAllAsync(RequestParameters parameters, string supplerName);
    }
}
