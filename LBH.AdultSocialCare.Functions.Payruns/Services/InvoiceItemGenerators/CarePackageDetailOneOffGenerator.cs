using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Data.Constants;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Functions.Payruns.Domain;
using LBH.AdultSocialCare.Functions.Payruns.Extensions;

namespace LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators
{
    public class CarePackageDetailOneOffGenerator : BaseInvoiceItemsGenerator
    {
        public override IEnumerable<InvoiceItem> CreateNormalItems(CarePackage package, IList<InvoiceDomain> packageInvoices, DateTimeOffset invoiceEndDate)
        {
            var oneOffs = package.Details.Where(d => d.CostPeriod == PaymentPeriod.OneOff);

            foreach (var detail in oneOffs)
            {
                // One-off invoice is created just once for entire period, in consequent invoices one-off is ignored
                var oneOffInvoiceItemExists = packageInvoices.Any(invoice =>
                    invoice.Status.In(InvoiceStatus.Accepted, InvoiceStatus.Held) &&
                    invoice.Items.Any(detail.IsReferenced));

                if (oneOffInvoiceItemExists) continue;

                var startDate = Dates.Max(detail.StartDate, PayrunConstants.DefaultStartDate);
                var endDate = detail.EndDate ?? startDate; // ongoing one-offs are infinite, so voluntarily limit end date to same day as start

                if (startDate.UtcDateTime > invoiceEndDate.UtcDateTime) continue;

                yield return new InvoiceItem
                {
                    Name = GetDetailItemName(detail),
                    Quantity = 1,
                    WeeklyCost = 0.0m,
                    TotalCost = detail.Cost,
                    FromDate = startDate,
                    ToDate = endDate,
                    CarePackageDetailId = detail.Id,
                    SourceVersion = detail.Version,
                    PriceEffect = PriceEffect.Add
                };
            }
        }

        public override IEnumerable<InvoiceItem> CreateRefundItems(CarePackage package, IList<InvoiceDomain> packageInvoices)
        {
            var oneOffs = package.Details.Where(d => d.CostPeriod == PaymentPeriod.OneOff);

            foreach (var detail in oneOffs)
            {
                var refunds = RefundCalculator.Calculate(
                    detail, packageInvoices,
                    (paymentRange, quantity) => CalculateCostForPeriod(detail, paymentRange));

                foreach (var refund in refunds)
                {
                    yield return new InvoiceItem
                    {
                        Name = $"{GetDetailItemName(detail)} (adjustment)",
                        Quantity = 1,
                        WeeklyCost = 0.0m,
                        TotalCost = refund.Amount,
                        FromDate = refund.StartDate,
                        ToDate = (detail.EndDate is null)
                            ? refund.StartDate // ongoing one-offs are infinite, so voluntarily limit end date to same day as start
                            : refund.EndDate,
                        CarePackageDetailId = detail.Id,
                        SourceVersion = detail.Version,
                        PriceEffect = refund.Amount > 0
                            ? PriceEffect.Add
                            : PriceEffect.Subtract
                    };
                }
            }
        }

        private static decimal CalculateCostForPeriod(CarePackageDetail detail, DateRange paymentRange)
        {
            // ignore end date of one-offs, payment is done single time at start date
            return ((detail.StartDate >= paymentRange.StartDate) && (detail.StartDate <= paymentRange.EndDate))
                ? detail.Cost
                : 0.0m;
        }
    }
}
