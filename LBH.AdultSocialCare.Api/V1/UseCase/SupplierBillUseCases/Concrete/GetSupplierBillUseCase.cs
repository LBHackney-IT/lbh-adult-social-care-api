using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.SupplierBillUseCases.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.SupplierBillUseCases.Concrete
{
    public class GetSupplierBillUseCase : IGetSupplierBillUseCase
    {
        private readonly ISupplierBillGateway _supplierBillGateway;

        public GetSupplierBillUseCase(ISupplierBillGateway supplierBillGateway)
        {
            _supplierBillGateway = supplierBillGateway;
        }

        public async Task<SupplierBillResponse> GetSupplierBill(Guid packageId)
        {
            var homeCareSupplierCost = await _supplierBillGateway.GetSupplierBill(packageId).ConfigureAwait(false);
            return homeCareSupplierCost.ToResponse();
        }
    }
}
