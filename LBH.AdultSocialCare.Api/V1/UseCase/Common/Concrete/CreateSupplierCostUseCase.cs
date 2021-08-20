using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
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
