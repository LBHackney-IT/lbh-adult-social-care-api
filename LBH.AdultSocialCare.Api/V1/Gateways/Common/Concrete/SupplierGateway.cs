using AutoMapper;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Data;
using LBH.AdultSocialCare.Data.Entities.Common;
using LBH.AdultSocialCare.Data.Extensions;
using LBH.AdultSocialCare.Data.RequestFeatures.Parameters;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete
{
    public class SupplierGateway : ISupplierGateway
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public SupplierGateway(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task<SupplierDomain> GetAsync(int supplierId)
        {
            var supplier = await GetSupplierEntityAsync(supplierId).ConfigureAwait(false);

            return supplier?.ToDomain();
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

        public async Task<SupplierDomain> UpdateAsync(SupplierDomain supplier)
        {
            var existingSupplier = await GetSupplierEntityAsync(supplier.Id).ConfigureAwait(false);

            if (existingSupplier is null)
            {
                throw new EntityNotFoundException($@"Unable to find supplier {supplier.Id} to update");
            }

            _mapper.Map(supplier, existingSupplier);

            try
            {
                await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
                return existingSupplier.ToDomain();
            }
            catch (Exception)
            {
                throw new DbSaveFailedException("Could not save supplier to database");
            }
        }

        public async Task<PagedList<SupplierDomain>> ListAsync(RequestParameters parameters, string supplierName)
        {
            var supplierList = await _databaseContext.Suppliers
                .FilterByName(supplierName)
                .GroupBy(h => new { h.CedarId, h.CedarName })
                .Select(g => new SupplierDomain()
                {
                    CedarId = g.Key.CedarId,
                    CedarName = g.Key.CedarName,
                    SupplierName =_databaseContext.Suppliers.Where(s => s.CedarId == g.Key.CedarId).Select(x => x.SupplierName).SingleOrDefault(),
                    Address = _databaseContext.Suppliers.Where(s => s.CedarId == g.Key.CedarId).Select(x => x.Address).SingleOrDefault(),
                    Id = _databaseContext.Suppliers.Where(s => s.CedarId == g.Key.CedarId).Select(x => x.Id).SingleOrDefault(),
                    Postcode = _databaseContext.Suppliers.Where(s => s.CedarId == g.Key.CedarId).Select(x => x.Postcode).SingleOrDefault(),
                    CedarReferenceNumber = _databaseContext.Suppliers.Where(s => s.CedarId == g.Key.CedarId).Select(x => x.CedarReferenceNumber).SingleOrDefault(),
                }).ToListAsync();

            foreach (var supplier in supplierList)
            {
                supplier.SubSuppliers = await _databaseContext.Suppliers.Where(s => s.CedarId == supplier.CedarId && Convert.ToInt32(s.CedarReferenceNumber) != 0)
                    .Select(x => new SubSupplierDomain(){
                        Id = x.Id,
                        SupplierName = x.SupplierName,
                        Address = x.Address,
                        Postcode = x.Postcode,
                        CedarId = x.CedarId,
                        CedarName = x.CedarName,
                        CedarReferenceNumber = x.CedarReferenceNumber})
                    .ToListAsync();
            }

            var suppliersPage = supplierList
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize);

            return PagedList<SupplierDomain>
                .ToPagedList(suppliersPage, supplierList.Count, parameters.PageNumber, parameters.PageSize);
        }

        private async Task<Supplier> GetSupplierEntityAsync(int supplierId)
        {
            return await _databaseContext.Suppliers
                .FirstOrDefaultAsync(s => s.Id == supplierId)
                .ConfigureAwait(false);
        }
    }
}
