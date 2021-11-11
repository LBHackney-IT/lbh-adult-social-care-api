using Common.AppConstants.Enums;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.Services.Queuing;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete
{
    public class CreateDraftPayRunUseCase : ICreateDraftPayRunUseCase
    {
        private readonly IPayRunGateway _payRunGateway;
        private readonly IQueueService _payrunsQueue;

        public CreateDraftPayRunUseCase(IPayRunGateway payRunGateway, IQueueService payrunsQueue)
        {
            _payRunGateway = payRunGateway;
            _payrunsQueue = payrunsQueue;
        }

        public async Task CreateDraftPayRun(DraftPayRunCreationDomain draftPayRunCreationDomain)
        {
            var recurringPayRunTypes = new[] { PayrunType.DirectPayments, PayrunType.ResidentialRecurring };
            ValidateDraftPayRun(draftPayRunCreationDomain);

            var unApprovedPayRunExists = await _payRunGateway.CheckExistsUnApprovedPayRunAsync(draftPayRunCreationDomain.Type);
            if (unApprovedPayRunExists)
                throw new ApiException($"Operation not allowed. There exists a pay run of the same type that is not approved", HttpStatusCode.PreconditionFailed);

            draftPayRunCreationDomain.Status = PayrunStatus.Draft;

            if (recurringPayRunTypes.Contains(draftPayRunCreationDomain.Type))
            {
                var endOfLastPayRun = await _payRunGateway.GetEndDateOfLastPayRun(draftPayRunCreationDomain.Type);
                draftPayRunCreationDomain.StartDate = endOfLastPayRun.Date.AddDays(1);
            }
            else
            {
                draftPayRunCreationDomain.StartDate = draftPayRunCreationDomain.PaidFromDate.GetValueOrDefault();
            }

            var payrun = draftPayRunCreationDomain.ToEntity();

            await _payRunGateway.CreateDraftPayRun(payrun);
            await _payrunsQueue.Send(payrun.Id);
        }

        private static void ValidateDraftPayRun(DraftPayRunCreationDomain creationDomain)
        {
            if (creationDomain.PaidUpToDate.Date > DateTimeOffset.Now.Date)
            {
                throw new ApiException(
                    $"Pay run date is invalid. Pay run date should be equal or earlier than today",
                    HttpStatusCode.BadRequest);
            }

            // If released holds pay run, paid from date should be provided
            var releaseHoldPayRunTypes =
                new[] { PayrunType.DirectPaymentsReleasedHolds, PayrunType.ResidentialReleasedHolds };
            if (releaseHoldPayRunTypes.Contains(creationDomain.Type) && creationDomain.PaidFromDate == null)
            {
                throw new ApiException(
                    $"For a released holds pay run, date from must be provided",
                    HttpStatusCode.UnprocessableEntity);
            }
        }
    }
}
