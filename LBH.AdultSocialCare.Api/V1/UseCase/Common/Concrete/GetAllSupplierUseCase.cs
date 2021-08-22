using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

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
    }
}
