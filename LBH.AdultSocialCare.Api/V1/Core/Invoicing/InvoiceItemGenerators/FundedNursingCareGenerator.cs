using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HttpServices.Models.Requests;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.Common.Invoicing;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;

namespace LBH.AdultSocialCare.Api.V1.Core.Invoicing.InvoiceItemGenerators
{
    public class FundedNursingCareGenerator : BaseInvoiceItemsGenerator
    {
        private IEnumerable<FundedNursingCarePriceDomain> _fncPrices;
        private readonly IFundedNursingCareGateway _fundedNursingCareGateway;

        public FundedNursingCareGenerator(IFundedNursingCareGateway fundedNursingCareGateway)
        {
            _fundedNursingCareGateway = fundedNursingCareGateway;
        }

        public override IEnumerable<InvoiceItemForCreationRequest> Run(GenericPackage package, DateTimeOffset invoiceStartDate, DateTimeOffset invoiceEndDate)
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
                    var claimedBy = fundedNursingCare.FundedNursingCareCollector.ClaimedBy switch // TODO: VK: Introduce enums, why are we using strings?
                    {
                        PackageCostClaimersConstants.Hackney => "Hackney",
                        PackageCostClaimersConstants.Supplier => "Supplier",
                        _ => "Hackney"
                    };
                    var priceEffect = claimedBy switch
                    {
                        "Hackney" => PriceEffect.None,
                        "Supplier" => PriceEffect.Subtract,
                        _ => PriceEffect.Add
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

        public override async Task Initialize()
        {
            _fncPrices = await _fundedNursingCareGateway
                .GetFundedNursingCarePricesAsync()
                .ConfigureAwait(false);
        }
    }
}
