using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class CancelInvoiceElementUseCase : ICancelInvoiceElementUseCase
    {
        private readonly ICareChargesGateway _careChargesGateway;
        private readonly IInvoiceCreditNoteGateway _invoiceCreditNoteGateway;
        private readonly IPackageCareChargeGateway _packageCareChargeGateway;

        public CancelInvoiceElementUseCase(ICareChargesGateway careChargesGateway, IInvoiceCreditNoteGateway invoiceCreditNoteGateway, IPackageCareChargeGateway packageCareChargeGateway)
        {
            _careChargesGateway = careChargesGateway;
            _invoiceCreditNoteGateway = invoiceCreditNoteGateway;
            _packageCareChargeGateway = packageCareChargeGateway;
        }

        public async Task<bool> ExecuteAsync(Guid packageCareChargeId, Guid careElementId)
        {
            // Get package care charge if it exists
            var packageCareCharge = await _packageCareChargeGateway.CheckIfExistsAsync(packageCareChargeId)
                .ConfigureAwait(false);

            // Get brokerage information for this package. Interested in supplierId

            // Get care charge element if it exists
            var careChargeElementFromDb = await _careChargesGateway
                .CheckCareChargeElementExistsAsync(packageCareChargeId, careElementId).ConfigureAwait(false);

            //Check if element has been invoiced. If true add invoice credit note for that period
            if (careChargeElementFromDb.PaidUpTo != null)
            {
                var paidUpTo = careChargeElementFromDb.PaidUpTo ?? careChargeElementFromDb.StartDate;
                var invoicedPeriodDays = (paidUpTo.Date - careChargeElementFromDb.StartDate.Date).Days;
                if (invoicedPeriodDays > 0)
                {
                    var weeks = invoicedPeriodDays / 7M;

                    var invoicedPrice = careChargeElementFromDb.Amount * weeks;

                    var newInvoiceCreditNote = new InvoiceCreditNote
                    {
                        SupplierId = packageCareCharge.SupplierId,
                        ServiceUserId = packageCareCharge.ServiceUserId,
                        SentOrInvoiced = false,
                        HasBeenAddedToUserInvoice = false,
                        PackageTypeId = packageCareCharge.PackageTypeId,
                        PackageId = packageCareCharge.PackageId,
                        ChargeTypeId = (int) InvoiceNoteChargeTypeEnum.OverCharge,
                        Description =
                            $"Cancelled {careChargeElementFromDb.Name} paid from {careChargeElementFromDb.StartDate:dd MMM yyyy} to {careChargeElementFromDb.PaidUpTo:dd MMM yyyy}",
                        Amount = invoicedPrice,
                        PriceEffectId = (int) InvoiceItemPriceEffectEnum.Subtract,
                        CareChargeElementId = careChargeElementFromDb.Id,
                        ClaimCollectorId = careChargeElementFromDb.ClaimCollectorId
                    };

                    await _invoiceCreditNoteGateway.CreateInvoiceCreditNoteAsync(newInvoiceCreditNote)
                        .ConfigureAwait(false);
                }
            }

            // Cancel care charge element
            var cancelResult = await _careChargesGateway
                .UpdateCareChargeElementStatusAsync(packageCareChargeId, careElementId,
                    (int) CareChargeElementStatusEnum.Cancelled).ConfigureAwait(false);
            return cancelResult;
        }
    }
}
