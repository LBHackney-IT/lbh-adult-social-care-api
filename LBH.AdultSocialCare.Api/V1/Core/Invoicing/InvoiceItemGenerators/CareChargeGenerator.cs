using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HttpServices.Models.Requests;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Common.Invoicing;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;

namespace LBH.AdultSocialCare.Api.V1.Core.Invoicing.InvoiceItemGenerators
{
    public class CareChargeGenerator : BaseInvoiceItemsGenerator
    {
        private readonly ICareChargesGateway _careChargesGateway;
        private readonly List<CareChargeElement> _affectedElements = new List<CareChargeElement>();

        public CareChargeGenerator(ICareChargesGateway careChargesGateway)
        {
            _careChargesGateway = careChargesGateway;
        }

        public override IEnumerable<InvoiceItemForCreationRequest> Run(GenericPackage package, DateTimeOffset invoiceStartDate, DateTimeOffset invoiceEndDate)
        {
            var invoiceItems = new List<InvoiceItemForCreationRequest>();

            if (package.CareCharge is null) return invoiceItems;

            foreach (var element in package.CareCharge.CareChargeElements)
            {
                if (element.StatusId != (int) CareChargeElementStatusEnum.Active) continue;

                var actualStartDate = Dates.Max(element.StartDate, invoiceStartDate);
                var actualEndDate = Dates.Min(element.EndDate, invoiceEndDate);
                var actualWeeks = (actualEndDate.Date - actualStartDate.Date).Days / 7M;

                if (actualWeeks <= 0) continue;

                invoiceItems.Add(new InvoiceItemForCreationRequest
                {
                    ItemName = element.Name ?? element.CareChargeType.OptionName,
                    PricePerUnit = element.Amount,
                    Quantity = actualWeeks,
                    PriceEffect = element.ClaimCollector.Id switch
                    {
                        PackageCostClaimersConstants.Hackney => PriceEffect.Add,
                        PackageCostClaimersConstants.Supplier => PriceEffect.Subtract,
                        _ => throw new InvalidOperationException("Unknown claim collector Id")
                    },
                    ClaimedBy = element.ClaimCollector.Name
                });

                _affectedElements.Add(element);
            }

            return invoiceItems;
        }

        public override async Task OnInvoiceBatchGenerated(DateTimeOffset invoiceEndDate)
        {
            await _careChargesGateway
                .RefreshCareChargeElementsPaidUpToDate(_affectedElements, invoiceEndDate)
                .ConfigureAwait(false);
        }
    }
}
