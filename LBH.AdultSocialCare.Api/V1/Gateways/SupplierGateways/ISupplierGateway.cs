using LBH.AdultSocialCare.Api.V1.Domain.SupplierDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.SupplierGateways
{
    public interface ISupplierGateway
    {

        public Task<SupplierDomain> CreateAsync(Supplier supplier);

        public Task<IEnumerable<SupplierDomain>> ListAsync();
    }
}
