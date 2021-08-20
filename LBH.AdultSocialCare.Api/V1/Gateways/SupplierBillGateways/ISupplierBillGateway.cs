using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.Gateways.SupplierBillGateways
{
    public interface ISupplierBillGateway
    {
        Task<SupplierBillDomain> GetSupplierBill(Guid packageId);
    }
}
