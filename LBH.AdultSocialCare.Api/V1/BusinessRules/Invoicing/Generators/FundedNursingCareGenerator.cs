using System;
using System.Collections.Generic;
using HttpServices.Models.Requests;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;

namespace LBH.AdultSocialCare.Api.V1.BusinessRules.Invoicing.Generators
{
    public class FundedNursingCareGenerator : IInvoiceItemsGenerator
    {
        private readonly List<FundedNursingCarePriceDomain> _fncPrices;

        public FundedNursingCareGenerator(List<FundedNursingCarePriceDomain> fncPrices)
        {
            _fncPrices = fncPrices;
        }

        public IEnumerable<InvoiceItemForCreationRequest> Run(GenericPackage package, DateTimeOffset invoiceStartDate, DateTimeOffset invoiceEndDate)
        {
            var invoiceItems = new List<InvoiceItemForCreationRequest>();
            var fundedNursingCare = (package.OriginalPackage as NursingCarePackage)?.FundedNursingCare; // TODO: VK: Review

            if (fundedNursingCare is null) return invoiceItems;

            foreach (var price in _fncPrices)
            {
                var itemStartDate = Dates.Max(price.ActiveFrom, invoiceStartDate);
                var itemEndDate = Dates.Min(price.ActiveTo, invoiceEndDate);
                var itemWeeks = ((itemEndDate.Date - itemStartDate.Date).Days) / 7M;

                if (itemWeeks > 0)
                {
                    var itemName = fundedNursingCare.FundedNursingCareCollector.OptionInvoiceName;
                    var claimedBy = fundedNursingCare.FundedNursingCareCollector.ClaimedBy switch // TODO: VK: Introduce enums
                    {
                        PackageCostClaimersConstants.Hackney => "Hackney",
                        PackageCostClaimersConstants.Supplier => "Supplier",
                        _ => "Hackney"
                    };
                    var priceEffect = claimedBy switch
                    {
                        "Hackney" => "None",
                        "Supplier" => "Subtract",
                        _ => "Add"
                    };

                    invoiceItems.Add(new InvoiceItemForCreationRequest
                    {
                        ItemName = itemName,
                        PricePerUnit = price.PricePerWeek,
                        Quantity = itemWeeks,
                        PriceEffect = priceEffect,
                        ClaimedBy = claimedBy,
                        ReclaimedFrom = fundedNursingCare.ReclaimFrom.ReclaimFromName
                    });
                }
            }

            return invoiceItems;
        }
    }
}
