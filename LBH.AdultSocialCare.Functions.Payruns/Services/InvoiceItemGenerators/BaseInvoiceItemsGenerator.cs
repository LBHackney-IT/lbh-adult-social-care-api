using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using Common.Models;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Interfaces;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Functions.Payruns.Domain;
using LBH.AdultSocialCare.Functions.Payruns.Extensions;

namespace LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators
{
    public abstract class BaseInvoiceItemsGenerator
    {
        /// <summary>
        /// This method is called for each package in invoicing period, so generator can produce invoice items for single package
        /// </summary>
        public abstract IEnumerable<InvoiceItem> CreateNormalItem(CarePackage package, IList<InvoiceDomain> packageInvoices, DateTimeOffset invoiceEndDate);

        public abstract IEnumerable<InvoiceItem> CreateRefundItem(CarePackage package, IList<InvoiceDomain> packageInvoices);

        /// <summary>
        /// This method is called right before invoice generation process is started, so generator can initialize its internal state
        /// </summary>
        public virtual Task Initialize()
        {
            return Task.CompletedTask;
        }

        protected static DateRange GetInvoiceItemDateRange(IPackageItem packageItem, IList<InvoiceDomain> packageInvoices, DateTimeOffset invoiceEndDate)
        {
            var startDate = GetActualStartDate(packageItem, packageInvoices, invoiceEndDate);
            var endDate = Dates.Min(packageItem.EndDate, invoiceEndDate);

            return new DateRange(startDate, endDate);
        }

        protected static DateTimeOffset GetActualStartDate(IPackageItem packageItem, IList<InvoiceDomain> packageInvoices, DateTimeOffset invoiceEndDate)
        {
            var latestInvoiceItem = GetLatestInvoiceItem(packageItem, packageInvoices);

            return latestInvoiceItem != null ?
                Dates.Min(packageItem.EndDate, latestInvoiceItem.ToDate.AddDays(1)) :
                Dates.Min(packageItem.StartDate, invoiceEndDate);
        }

        private static InvoiceItem GetLatestInvoiceItem(IPackageItem packageItem, IEnumerable<InvoiceDomain> invoices)
        {
            return invoices?
                .Where(invoice => invoice.Status.In(InvoiceStatus.Accepted, InvoiceStatus.Held)) // TODO: VK: Review
                .SelectMany(invoice => invoice.Items)
                .Where(packageItem.IsReferenced)
                .OrderByDescending(item => item.ToDate)
                .FirstOrDefault();
        }
    }
}
