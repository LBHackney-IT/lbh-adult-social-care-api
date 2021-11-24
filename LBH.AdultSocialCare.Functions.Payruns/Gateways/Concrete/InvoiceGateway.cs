using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data;
using LBH.AdultSocialCare.Data.Constants.Enums;
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
                    Status = payrunInvoice.InvoiceStatus,
                    EndDate = payrunInvoice.Payrun.EndDate,
                    PackageId = payrunInvoice.Invoice.PackageId,
                    Items = payrunInvoice.Invoice.Items.ToList()
                })
                .ToListAsync();

            return invoices
                .GroupBy(invoice => invoice.PackageId)
                .ToDictionary(group => group.Key, group => group.ToList());
        }

        // TODO: VK: Review invoice number generation and remove
        public async Task<int> GetInvoicesCountAsync()
        {
            return await DbContext.Invoices.CountAsync();
        }
    }
}
