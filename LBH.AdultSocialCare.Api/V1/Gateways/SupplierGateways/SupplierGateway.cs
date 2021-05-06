using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain.SupplierDomains;
using LBH.AdultSocialCare.Api.V1.Exceptions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.SupplierGateways
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

        public async Task<IEnumerable<SupplierDomain>> ListAsync()
        {
            var res = await _databaseContext.Suppliers
                .ToListAsync().ConfigureAwait(false);
            return res?.ToDomain();
        }
    }
}
