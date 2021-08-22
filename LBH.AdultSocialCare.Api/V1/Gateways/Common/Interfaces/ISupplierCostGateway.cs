using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface ISupplierCostGateway
    {
        public Task<bool> CreateAsync(List<HomeCareSupplierCost> homeCareSupplierCostCreationDomain);

        public Task<IEnumerable<HomeCareSupplierCostDomain>> GetListAsync(int supplierId);
    }
}
