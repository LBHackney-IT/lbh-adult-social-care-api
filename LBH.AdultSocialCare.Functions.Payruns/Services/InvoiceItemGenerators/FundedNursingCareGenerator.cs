using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Functions.Payruns.Enums;
using LBH.AdultSocialCare.Functions.Payruns.Gateways.Interfaces;
using LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.Common;
using LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.Payments;

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

        public override IEnumerable<InvoiceItem> Run(CarePackage package, DateTimeOffset invoiceStartDate, DateTimeOffset invoiceEndDate)
        {
            var invoiceItems = new List<InvoiceItem>();
            var fundedNursingCare = package.Reclaims
                .FirstOrDefault(r => r.Type is ReclaimType.Fnc);

            if (fundedNursingCare is null) return invoiceItems;

            foreach (var price in _fncPrices)
            {
                var actualStartDate = Dates.Max(price.ActiveFrom, invoiceStartDate);
                var actualEndDate = Dates.Min(price.ActiveTo, invoiceEndDate);
                var actualWeeks = ((actualEndDate.Date - actualStartDate.Date).Days) / 7M;

                if (actualWeeks <= 0) continue;

                invoiceItems.Add(new InvoiceItem
                {
                    Name = "Funded Nursing Care",
                    Quantity = actualWeeks,
                    WeeklyCost = price.PricePerWeek,
                    TotalCost = actualWeeks * price.PricePerWeek,
                    FromDate = actualStartDate,
                    ToDate = actualEndDate,
                    ClaimCollector = fundedNursingCare.ClaimCollector,
                    PriceEffect = fundedNursingCare.ClaimCollector switch
                    {
                        ClaimCollector.Hackney => PriceEffect.None,
                        ClaimCollector.Supplier => PriceEffect.Subtract,
                        _ => throw new InvalidOperationException("Unknown claim collector")
                    }
                });
            }

            return invoiceItems;
        }

        public override async Task Initialize()
        {
            _fncPrices = (await _fundedNursingCareGateway.GetFundedNursingCarePricesAsync()).ToList();
        }
    }
}
