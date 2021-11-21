using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Common;
using LBH.AdultSocialCare.Data.Entities.Payments;
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

        public override IEnumerable<InvoiceItem> Run(CarePackage package, IList<Invoice> packageInvoices, DateTimeOffset invoiceEndDate)
        {
            var invoiceItems = new List<InvoiceItem>();
            var fundedNursingCare = package.Reclaims
                .FirstOrDefault(r => r.Type is ReclaimType.Fnc);

            if (fundedNursingCare is null) return invoiceItems;

            var actualStartDate = GetActualStartDate(fundedNursingCare, packageInvoices, invoiceEndDate);

            foreach (var price in _fncPrices)
            {
                var actualEndDate = Dates.Min(price.ActiveTo, invoiceEndDate);
                var actualWeeks = Dates.WeeksBetween(actualEndDate, actualStartDate);

                if (actualWeeks <= 0) continue;

                invoiceItems.Add(new InvoiceItem
                {
                    Name = "Funded Nursing Care",
                    Quantity = actualWeeks,
                    WeeklyCost = price.PricePerWeek,
                    TotalCost = actualWeeks * price.PricePerWeek,
                    FromDate = actualStartDate,
                    ToDate = actualEndDate,
                    CarePackageReclaimId = fundedNursingCare.Id,
                    ClaimCollector = fundedNursingCare.ClaimCollector,
                    PriceEffect = fundedNursingCare.ClaimCollector switch
                    {
                        ClaimCollector.Hackney => PriceEffect.None,
                        ClaimCollector.Supplier => PriceEffect.Subtract,
                        _ => throw new InvalidOperationException("Unknown claim collector")
                    }
                });

                actualStartDate = actualEndDate.AddDays(1);
            }

            return invoiceItems;
        }

        public override async Task Initialize()
        {
            _fncPrices = (await _fundedNursingCareGateway.GetFundedNursingCarePricesAsync()).ToList();
        }
    }
}
