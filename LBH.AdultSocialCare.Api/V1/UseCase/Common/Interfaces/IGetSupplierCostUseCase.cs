using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IGetSupplierCostUseCase
    {
        public Task<IEnumerable<HomeCareSupplierCostResponse>> GetAsync(int supplierId);
    }
}
