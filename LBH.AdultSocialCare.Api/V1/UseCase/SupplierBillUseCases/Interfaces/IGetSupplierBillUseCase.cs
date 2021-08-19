using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.SupplierBillUseCases.Interfaces
{
    public interface IGetSupplierBillUseCase
    {
        Task<SupplierBillResponse> GetSupplierBill(Guid packageId);
    }
}
