using LBH.AdultSocialCare.Api.V1.Domain.SupplierDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.SupplierGateways
{
    public interface ISupplierGateway
    {
        public Task<SupplierDomain> CreateAsync(Supplier supplier);

        public Task<IEnumerable<SupplierDomain>> ListAsync();

        public Task<IEnumerable<SupplierMinimalDomain>> GetSupplierMinimalList();

        public Task<IEnumerable<SupplierMinimalDomain>> GetSupplierMinimalInList(List<long> supplierIds);
    }
}
