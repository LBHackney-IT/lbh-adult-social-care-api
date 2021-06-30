using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.SupplierDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.SupplierCostGateways
{
    public class SupplierCostGateway : ISupplierCostGateway
    {
        private readonly DatabaseContext _databaseContext;

        public SupplierCostGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> CreateAsync(List<HomeCareSupplierCost> homeCareSupplierCosts)
        {
            foreach (var homeCareSupplierCostInput in homeCareSupplierCosts)
            {
                await _databaseContext.HomeCareSupplierCosts.AddAsync(homeCareSupplierCostInput).ConfigureAwait(false);
            }
            try
            {
                bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
                return isSuccess;
            }
            catch (Exception)
            {
                throw new DbSaveFailedException("Could not save supplier cost to database");
            }
        }

        public async Task<IEnumerable<HomeCareSupplierCostDomain>> GetListAsync(int supplierId)
        {
            var supplierCost = await _databaseContext.HomeCareSupplierCosts
                .Where(item => item.SupplierId == supplierId)
                .ToListAsync()
                .ConfigureAwait(false);

            if (supplierCost == null)
                throw new ApiException($"Could not find the Home Care Supplier Cost {supplierId}");

            return supplierCost.ToDomain();
        }
    }
}
