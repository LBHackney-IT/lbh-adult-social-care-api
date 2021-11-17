using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class GetAllSupplierUseCase : IGetAllSupplierUseCase
    {
        private readonly ISupplierGateway _supplierGateway;

        public GetAllSupplierUseCase(ISupplierGateway supplierGateway)
        {
            _supplierGateway = supplierGateway;
        }

        public async Task<PagedResponse<SupplierResponse>> GetAllAsync(RequestParameters parameters, string supplerName)
        {
            var result = await _supplierGateway.ListAsync(parameters, supplerName).ConfigureAwait(false);

            return new PagedResponse<SupplierResponse>
            {
                PagingMetaData = result.PagingMetaData,
                Data = result.ToResponse()
            };
        }

        public async Task<SupplierResponse> GetSingleAsync(int supplierId)
        {
            var supplier = await _supplierGateway.GetAsync(supplierId)
                .EnsureExistsAsync($"Supplier with id {supplierId} not found");

            return supplier.ToResponse();
        }
    }
}
