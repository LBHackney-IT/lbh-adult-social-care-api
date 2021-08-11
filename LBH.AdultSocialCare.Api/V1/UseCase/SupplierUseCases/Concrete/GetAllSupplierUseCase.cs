using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.SupplierGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.SupplierUseCases.Interfaces;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.SupplierBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;

namespace LBH.AdultSocialCare.Api.V1.UseCase.SupplierUseCases.Concrete
{
    public class GetAllSupplierUseCase : IGetAllSupplierUseCase
    {
        private readonly ISupplierGateway _supplierGateway;

        public GetAllSupplierUseCase(ISupplierGateway supplierGateway)
        {
            _supplierGateway = supplierGateway;
        }

        public async Task<PagedResponse<SupplierResponse>> GetAllAsync(RequestParameters parameters)
        {
            var result = await _supplierGateway.ListAsync(parameters).ConfigureAwait(false);

            return new PagedResponse<SupplierResponse>
            {
                PagingMetaData = result.PagingMetaData,
                Data = result.ToResponse()
            };
        }
    }
}
