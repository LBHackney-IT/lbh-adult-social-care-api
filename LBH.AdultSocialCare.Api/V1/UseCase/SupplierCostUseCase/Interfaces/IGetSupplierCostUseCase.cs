using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.SupplierBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.SupplierCostUseCase.Interfaces
{
    public interface IGetSupplierCostUseCase
    {
        public Task<IEnumerable<HomeCareSupplierCostResponse>> GetAsync(int supplierId);
    }
}
