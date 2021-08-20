using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.SupplierCostGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.SupplierGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.SupplierCostUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.SupplierCostUseCase.Concrete
{
    public class CreateSupplierCostUseCase : ICreateSupplierCostUseCase
    {
        private readonly ISupplierCostGateway _supplierCostGateway;

        public CreateSupplierCostUseCase(ISupplierCostGateway supplierCostGateway)
        {
            _supplierCostGateway = supplierCostGateway;
        }

        public async Task<bool> ExecuteAsync(IEnumerable<HomeCareSupplierCostCreationDomain> homeCareSupplierCostDomains)
        {
            var supplierEntity = homeCareSupplierCostDomains.ToDb();
            var res = await _supplierCostGateway.CreateAsync(supplierEntity).ConfigureAwait(false);
            return res;
        }
    }
}
