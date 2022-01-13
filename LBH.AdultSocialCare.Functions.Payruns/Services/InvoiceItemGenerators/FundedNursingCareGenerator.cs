using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Common;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Functions.Payruns.Domain;

namespace LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators
{
    public class FundedNursingCareGenerator : BaseInvoiceItemsGenerator
    {
        private readonly IList<FundedNursingCarePrice> _fncPrices;

        public FundedNursingCareGenerator(IList<FundedNursingCarePrice> fncPrices)
        {
            _fncPrices = fncPrices;
        }

        public override IEnumerable<InvoiceItem> CreateNormalItems(CarePackage package, IList<InvoiceDomain> packageInvoices, DateTimeOffset invoiceEndDate)
        {
            var fncReclaims = package.Reclaims
                .Where(reclaim => reclaim.Type is ReclaimType.Fnc &&
                                  reclaim.Status != ReclaimStatus.Cancelled &&
                                  reclaim.StartDate <= invoiceEndDate)
                .ToList();

            foreach (var reclaim in fncReclaims)
            {
                if (reclaim.ClaimCollector is ClaimCollector.Hackney && reclaim.SubType is ReclaimSubType.FncReclaim) continue;

                var actualStartDate = GetActualStartDate(reclaim, packageInvoices);

                foreach (var price in _fncPrices)
                {
                    var paymentRange = new DateRange(
                        actualStartDate,
                        Dates.Min(price.ActiveTo, invoiceEndDate, reclaim.EndDate));

                    if (paymentRange.WeeksInclusive <= 0) continue;

                    var invoiceItem = new InvoiceItem
                    {
                        Name = $"Funded Nursing Care {FormatDescription(reclaim.Description)}",
                        Quantity = paymentRange.WeeksInclusive,
                        WeeklyCost = price.PricePerWeek,
                        TotalCost = (paymentRange.WeeksInclusive * price.PricePerWeek).Round(2),
                        FromDate = paymentRange.StartDate,
                        ToDate = paymentRange.EndDate,
                        CarePackageReclaimId = reclaim.Id,
                        ClaimCollector = reclaim.ClaimCollector,
                        SourceVersion = reclaim.Version,
                        PriceEffect = reclaim.ClaimCollector switch
                        {
                            ClaimCollector.Hackney => PriceEffect.None,
                            ClaimCollector.Supplier => PriceEffect.Subtract,
                            _ => throw new InvalidOperationException("Unknown claim collector")
                        }
                    };

                    if (reclaim.Cost < 0)
                    {
                        // for migrated items we may have 2 FNC reclaims with same value, one positive, one negative
                        // assuming that migrated reclaims have prices aligned with FNC prices table, use just sign of migrated data
                        invoiceItem.WeeklyCost *= -1;
                        invoiceItem.TotalCost *= -1;
                    }

                    yield return invoiceItem;

                    actualStartDate = paymentRange.EndDate.AddDays(1);
                }
            }
        }

        public override IEnumerable<InvoiceItem> CreateRefundItems(CarePackage package, IList<InvoiceDomain> packageInvoices)
        {
            var fundedNursingCare = package.Reclaims
                .Where(r => r.Type is ReclaimType.Fnc)
                .ToList();

            foreach (var reclaim in fundedNursingCare)
            {
                var refunds = RefundCalculator.Calculate(
                    reclaim, packageInvoices,
                    (paymentRange, quantity) => CalculateFncPriceForPeriod(paymentRange, reclaim));

                foreach (var refund in refunds)
                {
                    yield return new InvoiceItem
                    {
                        Name = $"Funded Nursing Care (adjustment) {FormatDescription(reclaim.Description)}",
                        Quantity = refund.Quantity,
                        WeeklyCost = GetPriceForDate(refund.StartDate),
                        TotalCost = refund.Amount,
                        FromDate = refund.StartDate,
                        ToDate = refund.EndDate,
                        CarePackageReclaimId = reclaim.Id,
                        SourceVersion = reclaim.Version,
                        PriceEffect = refund.Amount > 0
                            ? PriceEffect.Add
                            : PriceEffect.Subtract
                    };
                }
            }
        }

        private decimal CalculateFncPriceForPeriod(DateRange paymentRange, CarePackageReclaim fundedNursingCare)
        {
            var totalCost = 0.0m;
            var rangeStartDate = paymentRange.StartDate;

            foreach (var price in _fncPrices)
            {
                var costPeriodRange = new DateRange(
                    rangeStartDate,
                    Dates.Min(price.ActiveTo, paymentRange.EndDate, fundedNursingCare.EndDate));

                if (costPeriodRange.WeeksInclusive <= 0) continue;

                totalCost += (price.PricePerWeek * costPeriodRange.WeeksInclusive);
                rangeStartDate = costPeriodRange.EndDate.AddDays(1);
            }

            return totalCost;
        }

        private decimal GetPriceForDate(DateTimeOffset date)
        {
            return _fncPrices.FirstOrDefault(price =>
                price.ActiveFrom <= date && date <= price.ActiveTo)?.PricePerWeek ?? 0.0m;
        }
    }
}
