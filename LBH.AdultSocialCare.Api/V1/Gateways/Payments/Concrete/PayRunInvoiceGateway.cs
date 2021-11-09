using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Payments.Concrete
{
    public class PayRunInvoiceGateway : IPayRunInvoiceGateway
    {
        private readonly DatabaseContext _dbContext;

        public PayRunInvoiceGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PagedList<PayrunInvoice>> GetPayRunInvoicesAsync(Guid payRunId, PayRunDetailsQueryParameters parameters, PayRunInvoiceFields fields = PayRunInvoiceFields.None,
            bool trackChanges = false)
        {
            var query = _dbContext.PayrunInvoices.Where(p => p.PayrunId == payRunId)
                .FilterPayRunInvoices(parameters)
                .TrackChanges(trackChanges);

            var payRunInvoices = await BuildPayRunInvoiceQuery(query, fields)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            var invoiceCount = await query.CountAsync();
            return PagedList<PayrunInvoice>.ToPagedList(payRunInvoices, invoiceCount, parameters.PageNumber,
                parameters.PageSize);
        }

        public async Task<PagedList<PayRunInvoiceDomain>> GetPayRunInvoicesSummaryAsync(Guid payRunId,
            PayRunDetailsQueryParameters parameters)
        {
            var query = _dbContext.PayrunInvoices.Where(p => p.PayrunId == payRunId)
                .FilterPayRunInvoices(parameters)
                .TrackChanges(false);

            var payRunInvoices = await query.Select(payRunInvoice => new PayRunInvoiceDomain
            {
                InvoiceId = payRunInvoice.InvoiceId,
                CarePackageId = payRunInvoice.Invoice.PackageId,
                ServiceUserId = payRunInvoice.Invoice.ServiceUserId,
                ServiceUserName =
                    $"{payRunInvoice.Invoice.ServiceUser.FirstName} {payRunInvoice.Invoice.ServiceUser.MiddleName ?? string.Empty} {payRunInvoice.Invoice.ServiceUser.LastName}",
                SupplierId = payRunInvoice.Invoice.SupplierId,
                SupplierName = payRunInvoice.Invoice.Supplier.SupplierName,
                InvoiceNumber = payRunInvoice.Invoice.Number,
                PackageType = payRunInvoice.Invoice.Package.PackageType,
                InvoiceStatus = payRunInvoice.InvoiceStatus,
                AssignedBrokerName = payRunInvoice.Invoice.Package.Broker.Name,
                InvoiceItems = payRunInvoice.Invoice.Items.Select(ii => new PayRunInvoiceItemDomain
                {
                    Id = ii.Id,
                    Name = ii.Name,
                    FromDate = ii.FromDate,
                    ToDate = ii.ToDate,
                    Cost = ii.WeeklyCost,
                    Quantity = ii.Quantity,
                    TotalCost = ii.TotalCost,
                    IsReclaim = ii.IsReclaim ?? false,
                    ClaimCollector = ii.ClaimCollector,
                    PriceEffect = ii.PriceEffect
                })
            }).ToListAsync();

            var invoiceCount = await query.CountAsync();
            return PagedList<PayRunInvoiceDomain>.ToPagedList(payRunInvoices, invoiceCount, parameters.PageNumber,
                parameters.PageSize);
        }

        public async Task<PayrunInvoice> GetPayRunInvoiceAsync(Guid payRunInvoiceId, PayRunInvoiceFields fields = PayRunInvoiceFields.None,
            bool trackChanges = false)
        {
            var query = _dbContext.PayrunInvoices.Where(p => p.Id.Equals(payRunInvoiceId))
                .TrackChanges(trackChanges);

            return await BuildPayRunInvoiceQuery(query, fields).SingleOrDefaultAsync();
        }

        private static IQueryable<PayrunInvoice> BuildPayRunInvoiceQuery(IQueryable<PayrunInvoice> query, PayRunInvoiceFields fields)
        {
            if (fields.HasFlag(PayRunInvoiceFields.Creator)) query = query.Include(p => p.Creator);
            if (fields.HasFlag(PayRunInvoiceFields.Updater)) query = query.Include(p => p.Updater);
            if (fields.HasFlag(PayRunInvoiceFields.Invoice)) query = query.Include(p => p.Invoice).ThenInclude(i => i.Items);
            if (fields.HasFlag(PayRunInvoiceFields.Payrun)) query = query.Include(p => p.Payrun);

            return query;
        }
    }
}
