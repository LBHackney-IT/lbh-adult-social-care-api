using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Payments;
using System;
using System.Net;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete
{
    public class ArchivePayRunUseCase : IArchivePayRunUseCase
    {
        private readonly IPayRunGateway _payRunGateway;
        private readonly IDatabaseManager _dbManager;

        public ArchivePayRunUseCase(IPayRunGateway payRunGateway, IDatabaseManager dbManager)
        {
            _payRunGateway = payRunGateway;
            _dbManager = dbManager;
        }

        public async Task RejectAsync(Guid payRunId, string notes)
        {
            var payRun = await _payRunGateway
                .GetPayRunAsync(payRunId, PayRunFields.None, true)
                .EnsureExistsAsync($"Pay Run {payRunId} not found");

            if (payRun.Status == PayrunStatus.Archived)
            {
                throw new ApiException($"Pay run with id {payRunId} already archived", HttpStatusCode.BadRequest);
            }

            if (payRun.Status.In(PayrunStatus.Paid, PayrunStatus.PaidWithHold))
            {
                throw new ApiException($"Can not archive pay run in status {payRun.Status.GetDisplayName()}",
                    HttpStatusCode.BadRequest);
            }

            payRun.Status = payRun.Status == PayrunStatus.Approved ? PayrunStatus.WaitingForApproval : PayrunStatus.Archived;

            var history = new PayrunHistory
            {
                Status = payRun.Status,
                Notes = $"Pay run declined with note: {notes}"
            };

            // payRun.Histories = histories;
            payRun.Histories.Add(history);

            await _dbManager.SaveAsync();
        }

        public async Task DeleteAsync(Guid payRunId, string notes)
        {
            var payRun = await _payRunGateway
                .GetPayRunAsync(payRunId, PayRunFields.None, true)
                .EnsureExistsAsync($"Pay Run {payRunId} not found");

            if (payRun.Status == PayrunStatus.Archived)
            {
                throw new ApiException($"Pay run with id {payRunId} already archived", HttpStatusCode.BadRequest);
            }

            if (payRun.Status.NotIn(PayrunStatus.Draft, PayrunStatus.InProgress, PayrunStatus.WaitingForApproval, PayrunStatus.WaitingForReview, PayrunStatus.Approved))
            {
                throw new ApiException("Not allowed. Pay run status should be draft, waiting for approval, waiting for review or approved to delete",
                    HttpStatusCode.BadRequest);
            }

            payRun.Status = PayrunStatus.Archived;

            var history = new PayrunHistory { Status = payRun.Status, Notes = $"Pay run deleted with note: {notes}" };

            payRun.Histories.Add(history);

            // TODO: RESET paidUpToDate on cost elements that were in this pay run, Delete pay run invoices if not released holds and pay run items

            await _dbManager.SaveAsync();
        }
    }
}
