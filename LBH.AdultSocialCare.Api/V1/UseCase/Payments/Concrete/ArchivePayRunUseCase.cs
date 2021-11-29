using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Payments;

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

            var validPayRunStatuses = new[]
            {
                PayrunStatus.Approved, PayrunStatus.Paid, PayrunStatus.PaidWithHold
            };

            if (validPayRunStatuses.Contains(payRun.Status))
            {
                throw new ApiException($"Can not archive pay run with {payRun.Status.GetDisplayName()}",
                    HttpStatusCode.BadRequest);
            }

            payRun.Status = PayrunStatus.Archived;

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
            var validPayRunStatuses = new[]
            {
                PayrunStatus.Draft, PayrunStatus.WaitingForApproval, PayrunStatus.WaitingForReview
            };
            if (!validPayRunStatuses.Contains(payRun.Status))
            {
                throw new ApiException("Not allowed. Pay run status should be draft, waiting for approval, or waiting for review to delete",
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
