using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
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
    public class ChangePayRunInvoiceStatusUseCase : IChangePayRunInvoiceStatusUseCase
    {
        private readonly IDatabaseManager _dbManager;
        private readonly IPayRunGateway _payRunGateway;
        private readonly IPayRunInvoiceGateway _payRunInvoiceGateway;

        public ChangePayRunInvoiceStatusUseCase(IDatabaseManager dbManager, IPayRunGateway payRunGateway, IPayRunInvoiceGateway payRunInvoiceGateway)
        {
            _dbManager = dbManager;
            _payRunGateway = payRunGateway;
            _payRunInvoiceGateway = payRunInvoiceGateway;
        }

        public async Task<bool> ExecuteAsync(Guid payRunId, Guid payRunInvoiceId, InvoiceStatus newStatus)
        {
            var payRun = await _payRunGateway.GetPayRunAsync(payRunId)
                .EnsureExistsAsync($"Pay run with id {payRunId} not found");

            var validPayRunStatuses = new[]
            {
                PayrunStatus.ReadyForReview, PayrunStatus.WaitingForApproval
            };

            if (!validPayRunStatuses.Contains(payRun.Status))
            {
                throw new ApiException($"Pay run must be in review or waiting for approval to allow status change",
                    HttpStatusCode.BadRequest);
            }

            var payRunInvoice =
                await _payRunInvoiceGateway.GetPayRunInvoiceAsync(payRunInvoiceId, PayRunInvoiceFields.None, true)
                    .EnsureExistsAsync($"Pay run invoice with id {payRunInvoiceId} not found");

            var validStatuses = new[] { InvoiceStatus.Accepted, InvoiceStatus.Rejected, InvoiceStatus.Draft };

            if ((validStatuses.Contains(newStatus) && payRunInvoice.InvoiceStatus != InvoiceStatus.Held) ||
                (payRunInvoice.InvoiceStatus == InvoiceStatus.Held && newStatus == InvoiceStatus.Released))
            {
                payRunInvoice.InvoiceStatus = newStatus;
                await _dbManager.SaveAsync();
                return true;
            }

            throw new ApiException($"Status change for pay run invoice with id {payRunInvoiceId} not allowed",
                    HttpStatusCode.BadRequest);
        }
    }
}
