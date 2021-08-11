using LBH.AdultSocialCare.Api.V1.Domain.SupplierDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;

namespace LBH.AdultSocialCare.Api.V1.Gateways.SupplierGateways
{
    public interface ISupplierGateway
    {
        public Task<SupplierDomain> CreateAsync(Supplier supplier);

        public Task<PagedList<SupplierDomain>> ListAsync(RequestParameters parameters);

        public Task<IEnumerable<SupplierMinimalDomain>> GetSupplierMinimalList();

        public Task<IEnumerable<SupplierMinimalDomain>> GetSupplierMinimalInList(List<long> supplierIds);
    }
}
