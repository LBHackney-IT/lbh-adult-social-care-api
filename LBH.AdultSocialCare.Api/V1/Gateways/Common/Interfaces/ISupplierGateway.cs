using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface ISupplierGateway
    {
        public Task<SupplierDomain> GetAsync(int supplierId);

        public Task<SupplierDomain> CreateAsync(Supplier supplier);

        public Task<SupplierDomain> UpdateAsync(SupplierDomain supplier);

        public Task<PagedList<SupplierDomain>> ListAsync(RequestParameters parameters, string supplierName);

        public Task<IEnumerable<SupplierMinimalDomain>> GetSupplierMinimalList();

        public Task<IEnumerable<SupplierMinimalDomain>> GetSupplierMinimalInList(List<long> supplierIds);
    }
}
