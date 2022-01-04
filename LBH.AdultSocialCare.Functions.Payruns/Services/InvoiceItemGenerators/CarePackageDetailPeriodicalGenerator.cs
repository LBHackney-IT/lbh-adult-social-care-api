using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Functions.Payruns.Domain;

namespace LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators
{
    public class CarePackageDetailPeriodicalGenerator : BaseInvoiceItemsGenerator
    {
        public override IEnumerable<InvoiceItem> CreateNormalItems(CarePackage package, IList<InvoiceDomain> packageInvoices, DateTimeOffset invoiceEndDate)
        {
            var weeklyDetails = package.Details.Where(d => d.CostPeriod == PaymentPeriod.Weekly);

            foreach (var detail in weeklyDetails)
            {
                var itemRange = GetInvoiceItemDateRange(detail, packageInvoices, invoiceEndDate);
                if (itemRange.WeeksInclusive <= 0) continue;

                yield return new InvoiceItem
                {
                    Name = GetDetailItemName(detail),
                    Quantity = itemRange.WeeksInclusive,
                    WeeklyCost = detail.Cost,
                    TotalCost = (detail.Cost * itemRange.WeeksInclusive).Round(2),
                    FromDate = itemRange.StartDate,
                    ToDate = itemRange.EndDate,
                    CarePackageDetailId = detail.Id,
                    SourceVersion = detail.Version,
                    PriceEffect = PriceEffect.Add
                };
            }
        }

        public override IEnumerable<InvoiceItem> CreateRefundItems(CarePackage package, IList<InvoiceDomain> packageInvoices)
        {
            var weeklyDetails = package.Details.Where(d => d.CostPeriod == PaymentPeriod.Weekly);

            foreach (var detail in weeklyDetails)
            {
                var refunds = RefundCalculator.Calculate(
                    detail, packageInvoices,
                    (paymentRange, quantity) => detail.Cost * quantity);

                foreach (var refund in refunds)
                {
                    yield return new InvoiceItem
                    {
                        Name = $"{GetDetailItemName(detail)} (adjustment)",
                        Quantity = refund.Quantity,
                        WeeklyCost = detail.Cost,
                        TotalCost = refund.Amount,
                        FromDate = refund.StartDate,
                        ToDate = refund.EndDate,
                        CarePackageDetailId = detail.Id,
                        SourceVersion = detail.Version,
                        PriceEffect = refund.Amount > 0
                            ? PriceEffect.Add
                            : PriceEffect.Subtract
                    };
                }
            }
        }
    }
}
