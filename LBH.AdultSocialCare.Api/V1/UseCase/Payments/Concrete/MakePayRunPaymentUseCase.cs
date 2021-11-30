using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Payments;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete
{
    public class MakePayRunPaymentUseCase : IMakePayRunPaymentUseCase
    {
        private readonly IPayRunGateway _payRunGateway;
        private readonly IDatabaseManager _dbManager;
        private readonly IPayRunInvoiceGateway _payRunInvoiceGateway;

        public MakePayRunPaymentUseCase(IPayRunGateway payRunGateway, IDatabaseManager dbManager, IPayRunInvoiceGateway payRunInvoiceGateway)
        {
            _payRunGateway = payRunGateway;
            _dbManager = dbManager;
            _payRunInvoiceGateway = payRunInvoiceGateway;
        }

        public async Task ExecuteAsync(Guid payRunId)
        {
            var payRun = await _payRunGateway
                .GetPayRunAsync(payRunId, PayRunFields.None, true)
                .EnsureExistsAsync($"Pay Run with id {payRunId} not found");

            var paidStatuses = new[] { PayrunStatus.Paid, PayrunStatus.PaidWithHold };

            if (paidStatuses.Contains(payRun.Status))
            {
                throw new ApiException($"Pay run with id {payRunId} already marked as paid", HttpStatusCode.BadRequest);
            }

            if (payRun.Status == PayrunStatus.Archived)
            {
                throw new ApiException($"Status change not allowed. Pay run with id {payRunId} is archived", HttpStatusCode.BadRequest);
            }

            if (payRun.Status != PayrunStatus.Approved)
            {
                throw new ApiException($"Pay run must be approved before marking as paid", HttpStatusCode.BadRequest);
            }

            // Change status of pay run
            var invoices = await _payRunInvoiceGateway.GetPayRunInsightsAsync(payRunId);

            payRun.Status = PayrunStatus.Paid;
            payRun.Paid = invoices.TotalInvoiceAmount;
            payRun.Held = invoices.TotalHeldAmount;

            if (invoices.HoldsCount > 0)
            {
                payRun.Status = PayrunStatus.PaidWithHold;
            }

            var history = new PayrunHistory
            {
                Status = payRun.Status,
                Notes = $"Pay run marked as paid"
            };

            payRun.Histories.Add(history);

            await _dbManager.SaveAsync("Failed to mark pay run as paid");
        }
    }
}
