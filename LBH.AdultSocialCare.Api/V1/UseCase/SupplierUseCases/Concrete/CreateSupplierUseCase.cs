using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.SupplierUseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.SupplierUseCases.Concrete
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
