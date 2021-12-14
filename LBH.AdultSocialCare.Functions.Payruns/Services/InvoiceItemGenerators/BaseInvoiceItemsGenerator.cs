using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Data.Constants;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Interfaces;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Functions.Payruns.Domain;
using LBH.AdultSocialCare.Functions.Payruns.Extensions;
using DateRange = LBH.AdultSocialCare.Functions.Payruns.Domain.DateRange;

namespace LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators
{
    public abstract class BaseInvoiceItemsGenerator
    {
        public abstract IEnumerable<InvoiceItem> CreateNormalItems(CarePackage package, IList<InvoiceDomain> packageInvoices, DateTimeOffset invoiceEndDate);

        public abstract IEnumerable<InvoiceItem> CreateRefundItems(CarePackage package, IList<InvoiceDomain> packageInvoices);

        protected static DateRange GetInvoiceItemDateRange(IPackageItem packageItem, IList<InvoiceDomain> packageInvoices, DateTimeOffset invoiceEndDate)
        {
            var startDate = GetActualStartDate(packageItem, packageInvoices);
            var endDate = Dates.Min(packageItem.EndDate, invoiceEndDate);

            return new DateRange(startDate, endDate);
        }

        protected static DateTimeOffset GetActualStartDate(IPackageItem packageItem, IList<InvoiceDomain> packageInvoices)
        {
            var latestInvoiceItem = GetLatestInvoiceItem(packageItem, packageInvoices);

            return latestInvoiceItem != null
                ? Dates.Min(packageItem.EndDate, latestInvoiceItem.ToDate.AddDays(1))
                : Dates.Max(packageItem.StartDate, PayrunConstants.DefaultStartDate);
        }

        protected static string GetDetailItemName(CarePackageDetail detail)
        {
            switch (detail.Type)
            {
                case PackageDetailType.CoreCost:
                    return detail.Package.PackageType switch
                    {
                        PackageType.NursingCare => "Nursing Care Core",
                        PackageType.ResidentialCare => "Residential Care Core",
                        _ => throw new ArgumentException($"Unsupported {detail.Type}")
                    };

                case PackageDetailType.AdditionalNeed:
                    return $"Additional {detail.CostPeriod.GetDisplayName()} Cost";

                default:
                    throw new ArgumentException($"Unsupported {detail.Type}");
            }
        }

        protected static string FormatDescription(string description)
        {
            if (String.IsNullOrEmpty(description)) return description;

            return description.Length > 27
                ? $"({description[..27]}...)"
                : $"({description})";
        }

        private static InvoiceItem GetLatestInvoiceItem(IPackageItem packageItem, IEnumerable<InvoiceDomain> invoices)
        {
            return invoices?
                .Where(invoice => invoice.Status.In(InvoiceStatus.Accepted, InvoiceStatus.Held))
                .SelectMany(invoice => invoice.Items)
                .Where(packageItem.IsReferenced)
                .OrderByDescending(item => item.ToDate)
                .FirstOrDefault();
        }
    }
}
