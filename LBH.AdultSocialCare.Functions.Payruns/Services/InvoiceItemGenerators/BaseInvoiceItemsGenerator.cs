using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Interfaces;
using LBH.AdultSocialCare.Data.Entities.Payments;

namespace LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators
{
    public abstract class BaseInvoiceItemsGenerator
    {
        /// <summary>
        /// This method is called for each package in invoicing period, so generator can produce invoice items for single package
        /// </summary>
        public virtual IEnumerable<InvoiceItem> Run(CarePackage package, IList<Invoice> packageInvoices, DateTimeOffset invoiceEndDate)
        {
            return new List<InvoiceItem>();
        }

        /// <summary>
        /// This method is called right before invoice generation process is started, so generator can initialize its internal state
        /// </summary>
        public virtual Task Initialize()
        {
            return Task.CompletedTask;
        }

        protected static DateRange GetInvoiceItemDateRange(IPackageItem packageItem, IList<Invoice> packageInvoices, DateTimeOffset invoiceEndDate)
        {
            var startDate = GetActualStartDate(packageItem, packageInvoices, invoiceEndDate);
            var endDate = Dates.Min(packageItem.EndDate, invoiceEndDate);

            return new DateRange(startDate, endDate);
        }

        protected static DateTimeOffset GetActualStartDate(IPackageItem packageItem, IList<Invoice> packageInvoices, DateTimeOffset invoiceEndDate)
        {
            var latestInvoiceItem = GetLatestInvoiceItem(packageItem, packageInvoices);

            return latestInvoiceItem != null ?
                Dates.Min(packageItem.EndDate, latestInvoiceItem.ToDate.AddDays(1)) :
                Dates.Min(packageItem.StartDate, invoiceEndDate);
        }

        private static InvoiceItem GetLatestInvoiceItem(IPackageItem packageItem, IEnumerable<Invoice> invoices)
        {
            if (invoices is null) return null;

            Func<InvoiceItem, Guid?> getPackageItemId = packageItem switch
            {
                CarePackageDetail _ => (item => item.CarePackageDetailId),
                CarePackageReclaim _ => (item => item.CarePackageReclaimId),
                _ => throw new InvalidOperationException($"Unsupported package item type {packageItem.GetType()}")
            };

            return invoices
                .SelectMany(invoice => invoice.Items)
                .Where(item => getPackageItemId(item) == packageItem.Id)
                .OrderByDescending(item => item.ToDate)
                .FirstOrDefault();
        }
    }
}
