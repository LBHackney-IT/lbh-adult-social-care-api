using LBH.AdultSocialCare.Api.V1.Boundary.SupplierBoundary.Response.SupplierBoundary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.SupplierUseCases.Interfaces
{
    public interface IGetAllSupplierUseCase
    {
        public Task<IEnumerable<SupplierResponse>> GetAllAsync();
    }
}
