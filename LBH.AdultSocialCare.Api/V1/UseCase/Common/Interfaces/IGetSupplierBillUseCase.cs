using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IGetSupplierBillUseCase
    {
        Task<SupplierBillResponse> GetSupplierBill(Guid packageId);
    }
}
