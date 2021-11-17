using System;
using System.Collections.Generic;
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
    public class ApprovePayRunUseCase : IApprovePayRunUseCase
    {
        private readonly IPayRunGateway _payRunGateway;
        private readonly IDatabaseManager _dbManager;

        public ApprovePayRunUseCase(IPayRunGateway payRunGateway, IDatabaseManager dbManager)
        {
            _payRunGateway = payRunGateway;
            _dbManager = dbManager;
        }

        public async Task ExecuteAsync(Guid payRunId, string notes)
        {
            var payRun = await _payRunGateway
                .GetPayRunAsync(payRunId, PayRunFields.None, true)
                .EnsureExistsAsync($"Pay Run {payRunId} not found");

            var validPayRunStatuses = new[] { PayrunStatus.WaitingForReview, PayrunStatus.WaitingForApproval };

            if (!validPayRunStatuses.Contains(payRun.Status))
            {
                throw new ApiException($"Pay run status should be in review or waiting for approval to approve",
                    HttpStatusCode.BadRequest);
            }

            payRun.Status = PayrunStatus.Approved;

            var histories = new List<PayrunHistory>
            {
                new PayrunHistory
                {
                    Status = payRun.Status,
                    Notes = notes
                }
            };

            payRun.Histories = histories;

            await _dbManager.SaveAsync();
        }
    }
}
