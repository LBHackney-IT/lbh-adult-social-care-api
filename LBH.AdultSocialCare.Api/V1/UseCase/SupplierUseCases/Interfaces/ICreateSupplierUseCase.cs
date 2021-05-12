using LBH.AdultSocialCare.Api.V1.Domain.SupplierDomains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.SupplierBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.SupplierUseCases.Interfaces
{
    public interface ICreateSupplierUseCase
    {
        Task<SupplierResponse> ExecuteAsync(SupplierCreationDomain supplierCreationDomain);
    }
}
