using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IGetAllSupplierUseCase
    {
        public Task<PagedResponse<SupplierResponse>> GetAllAsync(RequestParameters parameters, string supplerName);

        public Task<SupplierResponse> GetSingleAsync(int supplierId);
    }
}
