using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete
{
    public class HoldInvoiceUseCase : IHoldInvoiceUseCase
    {
        private readonly IDatabaseManager _dbManager;
        private readonly IHeldInvoiceGateway _heldInvoiceGateway;
        private readonly IPayRunInvoiceGateway _payRunInvoiceGateway;
        private readonly IPayRunGateway _payRunGateway;

        public HoldInvoiceUseCase(IDatabaseManager dbManager, IHeldInvoiceGateway heldInvoiceGateway, IPayRunInvoiceGateway payRunInvoiceGateway, IPayRunGateway payRunGateway)
        {
            _dbManager = dbManager;
            _heldInvoiceGateway = heldInvoiceGateway;
            _payRunInvoiceGateway = payRunInvoiceGateway;
            _payRunGateway = payRunGateway;
        }

        public async Task<HeldInvoiceFlatResponse> ExecuteAsync(Guid payRunId, Guid invoiceId, HeldInvoiceCreationDomain heldInvoiceCreationDomain)
        {
            heldInvoiceCreationDomain.PayRunInvoiceId = invoiceId;

            var payRun = await _payRunGateway.GetPayRunAsync(payRunId)
                .EnsureExistsAsync($"Pay run with id {payRunId} not found");

            var validPayRunStatuses = new[] { PayrunStatus.ReadyForReview, PayrunStatus.WaitingForApproval };

            if (!validPayRunStatuses.Contains(payRun.Status))
            {
                throw new ApiException($"Pay run must be in review or waiting for approval to allow status change",
                    HttpStatusCode.BadRequest);
            }

            var payRunInvoice =
                await _payRunInvoiceGateway.GetPayRunInvoiceAsync(heldInvoiceCreationDomain.PayRunInvoiceId,
                    PayRunInvoiceFields.None, true).EnsureExistsAsync($"Pay run invoice with id {heldInvoiceCreationDomain.PayRunInvoiceId} not found");

            // Update pay run invoice status
            payRunInvoice.InvoiceStatus = InvoiceStatus.Held;

            // Create held invoice record
            var heldInvoice = heldInvoiceCreationDomain.ToEntity();
            _heldInvoiceGateway.AddHeldInvoice(heldInvoice);

            await _dbManager.SaveAsync();
            return heldInvoice.ToFlatDomain().ToResponse();
        }
    }
}
