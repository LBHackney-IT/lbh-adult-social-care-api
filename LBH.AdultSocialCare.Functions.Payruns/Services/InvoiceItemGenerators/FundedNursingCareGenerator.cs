using System;
using System.Collections.Generic;
using System.Linq;
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
            var fundedNursingCare = package.Reclaims
                .FirstOrDefault(reclaim => reclaim.Type is ReclaimType.Fnc &&
                                           reclaim.Status != ReclaimStatus.Cancelled &&
                                           reclaim.StartDate <= invoiceEndDate);

            if (fundedNursingCare is null) yield break;

            var actualStartDate = GetActualStartDate(fundedNursingCare, packageInvoices);

            foreach (var price in _fncPrices)
            {
                var paymentRange = new DateRange(
                    actualStartDate,
                    Dates.Min(price.ActiveTo, invoiceEndDate, fundedNursingCare.EndDate));

                if (paymentRange.WeeksInclusive <= 0) continue;

                yield return new InvoiceItem
                {
                    Name = "Funded Nursing Care",
                    Quantity = paymentRange.WeeksInclusive,
                    WeeklyCost = price.PricePerWeek,
                    TotalCost = Math.Round(paymentRange.WeeksInclusive * price.PricePerWeek, 2),
                    FromDate = paymentRange.StartDate,
                    ToDate = paymentRange.EndDate,
                    CarePackageReclaimId = fundedNursingCare.Id,
                    ClaimCollector = fundedNursingCare.ClaimCollector,
                    SourceVersion = fundedNursingCare.Version,
                    PriceEffect = fundedNursingCare.ClaimCollector switch
                    {
                        ClaimCollector.Hackney => PriceEffect.None,
                        ClaimCollector.Supplier => PriceEffect.Subtract,
                        _ => throw new InvalidOperationException("Unknown claim collector")
                    }
                };

                actualStartDate = paymentRange.EndDate.AddDays(1);
            }
        }

        public override IEnumerable<InvoiceItem> CreateRefundItems(CarePackage package, IList<InvoiceDomain> packageInvoices)
        {
            var fundedNursingCare = package.Reclaims
                .FirstOrDefault(r => r.Type is ReclaimType.Fnc);

            if (fundedNursingCare is null) yield break;

            var refunds = RefundCalculator.Calculate(
                fundedNursingCare, packageInvoices,
                (paymentRange, quantity) => CalculateFncPriceForPeriod(paymentRange, fundedNursingCare));

            foreach (var refund in refunds)
            {
                yield return new InvoiceItem
                {
                    Name = "Funded Nursing Care (refund)",
                    Quantity = refund.Quantity,
                    WeeklyCost = GetPriceForDate(refund.StartDate),
                    TotalCost = refund.Amount,
                    FromDate = refund.StartDate,
                    ToDate = refund.EndDate,
                    CarePackageReclaimId = fundedNursingCare.Id,
                    SourceVersion = fundedNursingCare.Version,
                    PriceEffect = refund.Amount > 0
                        ? PriceEffect.Add
                        : PriceEffect.Subtract
                };
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
