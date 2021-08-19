using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.SupplierCostGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.SupplierCostUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.SupplierCostUseCase.Concrete
{
    public class GetSupplierCostUseCase : IGetSupplierCostUseCase
    {
        private readonly ISupplierCostGateway _supplierCostGateway;

        public GetSupplierCostUseCase(ISupplierCostGateway supplierCostGateway)
        {
            _supplierCostGateway = supplierCostGateway;
        }

        public async Task<IEnumerable<HomeCareSupplierCostResponse>> GetAsync(int supplierId)
        {
            var homeCareSupplierCost = await _supplierCostGateway.GetListAsync(supplierId).ConfigureAwait(false);
            return homeCareSupplierCost.ToResponse();
        }
    }
}
