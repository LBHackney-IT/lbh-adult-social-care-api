using LBH.AdultSocialCare.Api.V1.Boundary.SupplierBoundary.Response.SupplierBoundary;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.SupplierGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.SupplierUseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.SupplierUseCases.Concrete
{
    public class GetAllSupplierUseCase : IGetAllSupplierUseCase
    {
        private readonly ISupplierGateway _supplierGateway;

        public GetAllSupplierUseCase(ISupplierGateway supplierGateway)
        {
            _supplierGateway = supplierGateway;
        }

        public async Task<IEnumerable<SupplierResponse>> GetAllAsync()
        {
            var result = await _supplierGateway.ListAsync().ConfigureAwait(false);
            return result.ToResponse();
        }
    }
}
