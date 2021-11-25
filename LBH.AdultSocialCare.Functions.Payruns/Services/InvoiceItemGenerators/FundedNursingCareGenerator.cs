using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Common;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Functions.Payruns.Domain;
using LBH.AdultSocialCare.Functions.Payruns.Gateways.Interfaces;

namespace LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators
{
    public class FundedNursingCareGenerator : BaseInvoiceItemsGenerator
    {
        private List<FundedNursingCarePrice> _fncPrices;
        private readonly IFundedNursingCareGateway _fundedNursingCareGateway;

        public FundedNursingCareGenerator(IFundedNursingCareGateway fundedNursingCareGateway)
        {
            _fundedNursingCareGateway = fundedNursingCareGateway;
        }

        public override IEnumerable<InvoiceItem> CreateNormalItem(CarePackage package, IList<InvoiceDomain> packageInvoices, DateTimeOffset invoiceEndDate)
        {
            var fundedNursingCare = package.Reclaims
                .FirstOrDefault(r => r.Type is ReclaimType.Fnc &&
                                     r.Status is ReclaimStatus.Active);

            if (fundedNursingCare is null) yield break;

            var actualStartDate = GetActualStartDate(fundedNursingCare, packageInvoices, invoiceEndDate);

            foreach (var price in _fncPrices)
            {
                var actualEndDate = Dates.Min(price.ActiveTo, invoiceEndDate, fundedNursingCare.EndDate);
                var actualWeeks = Dates.WeeksBetween(actualStartDate, actualEndDate);

                if (actualWeeks <= 0) continue;

                yield return new InvoiceItem
                {
                    Name = "Funded Nursing Care",
                    Quantity = actualWeeks,
                    WeeklyCost = price.PricePerWeek,
                    TotalCost = actualWeeks * price.PricePerWeek,
                    FromDate = actualStartDate,
                    ToDate = actualEndDate,
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

                actualStartDate = actualEndDate.AddDays(1);
            }
        }

        public override IEnumerable<InvoiceItem> CreateRefundItem(CarePackage package, IList<InvoiceDomain> packageInvoices)
        {
            var fundedNursingCare = package.Reclaims
                .FirstOrDefault(r => r.Type is ReclaimType.Fnc &&
                                     r.Status is ReclaimStatus.Active);

            if (fundedNursingCare is null) yield break;

            var refund = RefundCalculator.Calculate(
                fundedNursingCare, packageInvoices,
                (start, end, quantity) => CalculateFncPriceForPeriod(start, end, fundedNursingCare));

            if (refund.RefundAmount == 0.0m) yield break;

            yield return new InvoiceItem
            {
                Name = "Funded Nursing Care (refund)",
                Quantity = refund.Quantity,
                WeeklyCost = 0.0m,              // generate refund per FNC period if we'll need real weekly FNC cost here
                TotalCost = refund.RefundAmount,
                FromDate = refund.StartDate,
                ToDate = refund.EndDate,
                CarePackageReclaimId = fundedNursingCare.Id,
                SourceVersion = fundedNursingCare.Version,
                NetCostsCompensated = refund.NetCostsCompensated,
                PriceEffect = refund.RefundAmount > 0
                    ? PriceEffect.Add
                    : PriceEffect.Subtract
            };
        }

        private decimal CalculateFncPriceForPeriod(DateTimeOffset start, DateTimeOffset end, CarePackageReclaim fundedNursingCare)
        {
            var totalCost = 0.0m;
            var rangeStartDate = start;

            foreach (var price in _fncPrices)
            {
                var rangeEndDate = Dates.Min(price.ActiveTo, end, fundedNursingCare.EndDate);
                var weeks = Dates.WeeksBetween(rangeStartDate, rangeEndDate);

                if (weeks <= 0) continue;

                totalCost += (price.PricePerWeek * weeks);
                rangeStartDate = rangeEndDate.AddDays(1);
            }

            return totalCost;
        }

        public override async Task Initialize()
        {
            _fncPrices = (await _fundedNursingCareGateway.GetFundedNursingCarePricesAsync()).ToList();
        }
    }
}
