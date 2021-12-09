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
                    PayrunStatus = payrunInvoice.Payrun.Status,
                    Items = payrunInvoice.Invoice.Items.ToList(),
                    PayrunInvoice = payrunInvoice // need this to reject invoice
                })
                .ToListAsync();

            return invoices
                .GroupBy(invoice => invoice.PackageId)
                .ToDictionary(group => group.Key, group => group.ToList());
        }

        public async Task<long> GetInvoicesCountAsync()
        {
            var currentDate = DateTimeOffset.UtcNow.Date;

            // TODO: VK: Customers in different timezones may create repeating numbers and fail
            // Move to DB side (calculated field / sequence)
            return
                await DbContext.Invoices.AnyAsync()
                    ? await DbContext.Invoices
                        .Where(invoice =>
                            invoice.Number.Length == 15 &&
                            DbContext.CompareDates(invoice.DateCreated, currentDate) == 0)
                        .Select(invoice => Convert.ToInt32(invoice.Number.Substring(11, 4)))
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
