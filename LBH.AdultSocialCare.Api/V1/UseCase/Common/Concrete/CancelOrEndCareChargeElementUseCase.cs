using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class CancelOrEndCareChargeElementUseCase : ICancelOrEndCareChargeElementUseCase
    {
        private readonly ICareChargesGateway _careChargesGateway;
        private readonly IInvoiceCreditNoteGateway _invoiceCreditNoteGateway;
        private readonly IPackageCareChargeGateway _packageCareChargeGateway;

        public CancelOrEndCareChargeElementUseCase(ICareChargesGateway careChargesGateway, IInvoiceCreditNoteGateway invoiceCreditNoteGateway, IPackageCareChargeGateway packageCareChargeGateway)
        {
            _careChargesGateway = careChargesGateway;
            _invoiceCreditNoteGateway = invoiceCreditNoteGateway;
            _packageCareChargeGateway = packageCareChargeGateway;
        }

        public async Task<bool> ExecuteCancelAsync(Guid packageCareChargeId, Guid careElementId)
        {
            // Check package and element exist
            var (packageCareCharge, careChargeElementFromDb) = await CheckCareElementExistsAsync(packageCareChargeId, careElementId)
                .ConfigureAwait(false);

            switch (careChargeElementFromDb.StatusId)
            {
                case (int) ReclaimStatus.Cancelled:
                    throw new ApiException($"Care element with id {careElementId} already cancelled",
                        StatusCodes.Status400BadRequest);
                case (int) ReclaimStatus.Ended:
                    throw new ApiException($"Ended care element with id {careElementId} cannot be cancelled. Only active elements can be cancelled",
                        StatusCodes.Status400BadRequest);
            }

            //Check if element has been invoiced. If true add invoice credit note for that period
            var paidUpTo = careChargeElementFromDb.PaidUpTo ?? careChargeElementFromDb.StartDate;
            var invoicedPeriodDays = (paidUpTo.Date - careChargeElementFromDb.StartDate.Date).Days;
            await CreateInvoiceCreditNoteIfInvoicedAsync(packageCareCharge, careChargeElementFromDb, invoicedPeriodDays)
                .ConfigureAwait(false);

            // Cancel care charge element
            var cancelResult = await _careChargesGateway
                .UpdateCareChargeElementStatusAsync(packageCareChargeId, careElementId,
                    (int) ReclaimStatus.Cancelled, careChargeElementFromDb.EndDate).ConfigureAwait(false);
            return cancelResult;
        }

        private async Task<(PackageCareChargePlainDomain, CareChargeElementPlainDomain)> CheckCareElementExistsAsync(Guid packageCareChargeId, Guid careElementId)
        {
            // Get package care charge if it exists
            var packageCareCharge = await _packageCareChargeGateway.CheckIfExistsAsync(packageCareChargeId)
                .ConfigureAwait(false);

            // Get brokerage information for this package. Interested in supplierId

            // Get care charge element if it exists
            var careChargeElementFromDb = await _careChargesGateway
                .CheckCareChargeElementExistsAsync(packageCareChargeId, careElementId).ConfigureAwait(false);

            return (packageCareCharge, careChargeElementFromDb);
        }

        private async Task CreateInvoiceCreditNoteIfInvoicedAsync(PackageCareChargePlainDomain packageCareCharge, CareChargeElementPlainDomain careChargeElementFromDb, int invoicedPeriodDays, string actionName = "Cancelled")
        {
            if (careChargeElementFromDb.PaidUpTo != null)
            {
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
                            $"{actionName} {careChargeElementFromDb.Name} paid from {careChargeElementFromDb.StartDate:dd MMM yyyy} to {careChargeElementFromDb.PaidUpTo:dd MMM yyyy}",
                        Amount = invoicedPrice,
                        PriceEffectId = (int) InvoiceItemPriceEffectEnum.Subtract,
                        CareChargeElementId = careChargeElementFromDb.Id,
                        ClaimCollectorId = careChargeElementFromDb.ClaimCollectorId
                    };

                    await _invoiceCreditNoteGateway.CreateInvoiceCreditNoteAsync(newInvoiceCreditNote)
                        .ConfigureAwait(false);
                }
            }
        }

        public async Task<bool> ExecuteEndAsync(Guid packageCareChargeId, Guid careElementId, DateTimeOffset newEndDate)
        {
            var today = DateTimeOffset.Now;

            // Check package and element exist
            var (packageCareCharge, careChargeElementFromDb) = await CheckCareElementExistsAsync(packageCareChargeId, careElementId)
                .ConfigureAwait(false);

            switch (careChargeElementFromDb.StatusId)
            {
                case (int) ReclaimStatus.Ended:
                    throw new ApiException($"Care element with id {careElementId} already ended",
                        StatusCodes.Status400BadRequest);
                case (int) ReclaimStatus.Cancelled:
                    throw new ApiException($"Canceled care element with id {careElementId} cannot be ended. Only active elements can be ended",
                        StatusCodes.Status400BadRequest);
            }

            //Check if element has been invoiced. If true add invoice credit note for that period
            var paidUpTo = careChargeElementFromDb.PaidUpTo ?? careChargeElementFromDb.StartDate;
            if (paidUpTo.Date > newEndDate.Date)
            {
                var invoicedPeriodDays = (paidUpTo.Date - newEndDate.Date).Days;
                await CreateInvoiceCreditNoteIfInvoicedAsync(packageCareCharge, careChargeElementFromDb, invoicedPeriodDays, "Ended")
                    .ConfigureAwait(false);
            }

            bool endResult;

            // Set new end date and return without changing status if date is greater than today
            if (newEndDate.Date > today.Date)
            {
                endResult = await _careChargesGateway
                    .UpdateCareChargeElementStatusAsync(packageCareChargeId, careElementId,
                        (int) ReclaimStatus.Active, newEndDate.Date).ConfigureAwait(false);
            }
            else
            {
                endResult = await _careChargesGateway
                    .UpdateCareChargeElementStatusAsync(packageCareChargeId, careElementId,
                        (int) ReclaimStatus.Ended, newEndDate.Date).ConfigureAwait(false);
            }

            return endResult;
        }
    }
}
