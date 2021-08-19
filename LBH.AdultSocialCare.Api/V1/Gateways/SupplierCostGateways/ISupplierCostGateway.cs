using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;

namespace LBH.AdultSocialCare.Api.V1.Gateways.SupplierCostGateways
{
    public interface ISupplierCostGateway
    {
        public Task<bool> CreateAsync(List<HomeCareSupplierCost> homeCareSupplierCostCreationDomain);

        public Task<IEnumerable<HomeCareSupplierCostDomain>> GetListAsync(int supplierId);
    }
}
