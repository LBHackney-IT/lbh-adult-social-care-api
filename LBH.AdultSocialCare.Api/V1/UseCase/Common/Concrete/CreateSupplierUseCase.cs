using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class CreateSupplierUseCase : ICreateSupplierUseCase
    {
        private readonly ISupplierGateway _supplierGateway;

        public CreateSupplierUseCase(ISupplierGateway supplierGateway)
        {
            _supplierGateway = supplierGateway;
        }

        public async Task<SupplierResponse> ExecuteAsync(SupplierCreationDomain supplierCreationDomain)
        {
            var supplierEntity = supplierCreationDomain.ToDb();
            var res = await _supplierGateway.CreateAsync(supplierEntity).ConfigureAwait(false);
            return res.ToResponse();
        }
    }
}
