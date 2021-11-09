using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete
{
    public class SubmitPayRunUseCase : ISubmitPayRunUseCase
    {
        private readonly IPayRunGateway _payRunGateway;
        private readonly IDatabaseManager _dbManager;

        public SubmitPayRunUseCase(IPayRunGateway payRunGateway, IDatabaseManager dbManager)
        {
            _payRunGateway = payRunGateway;
            _dbManager = dbManager;
        }

        public async Task ExecuteAsync(Guid payRunId, string notes)
        {
            var payRun = await _payRunGateway
                .GetPayRunAsync(payRunId, PayRunFields.None, true)
                .EnsureExistsAsync($"Pay Run {payRunId} not found");

            if (payRun.Status != PayrunStatus.WaitingForReview)
            {
                throw new ApiException("Pay run status should be in progress for send to approval",
                    HttpStatusCode.BadRequest);
            }

            payRun.Status = PayrunStatus.WaitingForApproval;

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
