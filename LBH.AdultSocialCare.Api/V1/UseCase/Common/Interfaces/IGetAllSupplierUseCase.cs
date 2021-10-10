using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IGetAllSupplierUseCase
    {
        public Task<PagedResponse<SupplierResponse>> GetAllAsync(RequestParameters parameters, string supplerName);

        public Task<SupplierResponse> GetSingleAsync(int supplierId);
    }
}
