using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;

namespace LBH.AdultSocialCare.Api.V1.Gateways.SupplierGateways
{
    public class SupplierGateway : ISupplierGateway
    {
        private readonly DatabaseContext _databaseContext;

        public SupplierGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<SupplierDomain> CreateAsync(Supplier supplier)
        {
            var entry = await _databaseContext.Suppliers.AddAsync(supplier).ConfigureAwait(false);
            try
            {
                await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
                return entry.Entity.ToDomain();
            }
            catch (Exception)
            {
                throw new DbSaveFailedException("Could not save supplier to database");
            }
        }

        public async Task<PagedList<SupplierDomain>> ListAsync(RequestParameters parameters, string supplierName)
        {
            var suppliersCount = await _databaseContext.Suppliers
                .FilterByName(supplierName)
                .CountAsync().ConfigureAwait(false);

            var suppliersPage = await _databaseContext.Suppliers
                .FilterByName(supplierName)
                .GetPage(parameters.PageNumber, parameters.PageSize)
                .ToListAsync().ConfigureAwait(false);

            return PagedList<SupplierDomain>
                .ToPagedList(suppliersPage?.ToDomain(), suppliersCount, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<IEnumerable<SupplierMinimalDomain>> GetSupplierMinimalList()
        {
            return await _databaseContext.Suppliers
                .Select(s => new SupplierMinimalDomain { Id = s.Id, SupplierName = s.SupplierName }).ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<SupplierMinimalDomain>> GetSupplierMinimalInList(List<long> supplierIds)
        {
            return await _databaseContext.Suppliers.Where(s => supplierIds.Contains(s.Id))
                .Select(s => new SupplierMinimalDomain { Id = s.Id, SupplierName = s.SupplierName }).ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
