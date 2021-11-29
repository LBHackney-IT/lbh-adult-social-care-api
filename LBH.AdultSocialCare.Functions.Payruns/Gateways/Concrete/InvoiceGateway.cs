using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Functions.Payruns.Domain;
using LBH.AdultSocialCare.Functions.Payruns.Gateways.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Functions.Payruns.Gateways.Concrete
{
    // ReSharper disable once UnusedType.Global
    public class InvoiceGateway : BaseGateway, IInvoiceGateway
    {

        public InvoiceGateway(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<Dictionary<Guid, List<InvoiceDomain>>> GetInvoicesByPackageIds(IList<Guid> packageIds)
        {
            var invoices = await DbContext.PayrunInvoices
                .Include(payrunInvoice => payrunInvoice.Invoice)
                .ThenInclude(invoice => invoice.Items)
                .AsNoTracking()
                .Where(payrunInvoice => packageIds.Contains(payrunInvoice.Invoice.PackageId) &&
                                        (payrunInvoice.InvoiceStatus == InvoiceStatus.Accepted ||
                                         payrunInvoice.InvoiceStatus == InvoiceStatus.Held))
                .Select(payrunInvoice => new InvoiceDomain
                {
                    Id = payrunInvoice.Invoice.Id,
                    PackageId = payrunInvoice.Invoice.PackageId,
                    Status = payrunInvoice.InvoiceStatus,
                    PayrunStatus = payrunInvoice.Payrun.Status,
                    StartDate = payrunInvoice.Payrun.StartDate,
                    EndDate = payrunInvoice.Payrun.EndDate,
                    Items = payrunInvoice.Invoice.Items.ToList(),
                    PayrunInvoice = payrunInvoice // need this to reject invoice
                })
                .ToListAsync();

            return invoices
                .GroupBy(invoice => invoice.PackageId)
                .ToDictionary(group => group.Key, group => group.ToList());
        }

        // TODO: VK: Review invoice number generation and remove
        public async Task<long> GetInvoicesCountAsync()
        {
            // TODO: VK: Quick fix, replace with sequence
            return await DbContext.Invoices.AnyAsync()
                ? await DbContext.Invoices
                    .Select(invoice => Convert.ToInt64(invoice.Number.Replace("INV ", "")))
                    .MaxAsync()
                : 0;
        }

        public void RejectInvoices(IEnumerable<PayrunInvoice> payrunInvoices)
        {
            DbContext.AttachRange(payrunInvoices);

            foreach (var payrunInvoice in payrunInvoices)
            {
                payrunInvoice.InvoiceStatus = InvoiceStatus.Rejected;
            }
        }
    }
}
