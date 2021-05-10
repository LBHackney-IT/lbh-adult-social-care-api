using LBH.AdultSocialCare.Api.V1.Boundary.SupplierBoundary.Response.SupplierBoundary;
using LBH.AdultSocialCare.Api.V1.Domain.SupplierDomains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.SupplierUseCases.Interfaces
{
    public interface ICreateSupplierUseCase
    {
        Task<SupplierResponse> ExecuteAsync(SupplierCreationDomain supplierCreationDomain);

    }
}
