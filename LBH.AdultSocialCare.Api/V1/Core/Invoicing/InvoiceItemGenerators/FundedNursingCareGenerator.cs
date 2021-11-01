using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using HttpServices.Models.Requests;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Core.Invoicing.InvoiceItemGenerators
{
    public class FundedNursingCareGenerator : BaseInvoiceItemsGenerator
    {
        private List<FundedNursingCarePriceDomain> _fncPrices;
        private readonly IFundedNursingCareGateway _fundedNursingCareGateway;

        public FundedNursingCareGenerator(IFundedNursingCareGateway fundedNursingCareGateway)
        {
            _fundedNursingCareGateway = fundedNursingCareGateway;
        }

        public override IEnumerable<InvoiceItemForCreationRequest> Run(CarePackage package, DateTimeOffset invoiceStartDate, DateTimeOffset invoiceEndDate)
        {
            var invoiceItems = new List<InvoiceItemForCreationRequest>();
            var fundedNursingCare = package.Reclaims
                .FirstOrDefault(r => r.Type is ReclaimType.Fnc);

            if (fundedNursingCare is null) return invoiceItems;

            foreach (var price in _fncPrices)
            {
                var itemStartDate = Dates.Max(price.ActiveFrom, invoiceStartDate);
                var itemEndDate = Dates.Min(price.ActiveTo, invoiceEndDate);
                var itemWeeks = ((itemEndDate.Date - itemStartDate.Date).Days) / 7M;

                if (itemWeeks > 0)
                {
                    var priceEffect = fundedNursingCare.ClaimCollector switch
                    {
                        ClaimCollector.Hackney => PriceEffect.None,
                        ClaimCollector.Supplier => PriceEffect.Subtract,
                        _ => PriceEffect.Add
                    };

                    invoiceItems.Add(new InvoiceItemForCreationRequest
                    {
                        // ItemName = fundedNursingCare.FundedNursingCareCollector.OptionInvoiceName, // TODO: VK: Clarify
                        PricePerUnit = price.PricePerWeek,
                        Quantity = itemWeeks,
                        PriceEffect = priceEffect,
                        ClaimedBy = fundedNursingCare.ClaimCollector.GetDisplayName(),
                        // ReclaimedFrom = fundedNursingCare.ReclaimFrom.ReclaimFromName // TODO: VK: Clarify
                    });
                }
            }

            return invoiceItems;
        }

        public override async Task Initialize()
        {
            _fncPrices = (await _fundedNursingCareGateway.GetFundedNursingCarePricesAsync()).ToList();
        }
    }
}
