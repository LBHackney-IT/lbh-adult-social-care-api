using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using Common.Models;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.Services.Queuing;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;

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
            var unApprovedPayRunStatuses = new[] { PayrunStatus.Draft, PayrunStatus.InProgress, PayrunStatus.WaitingForReview, PayrunStatus.WaitingForApproval, PayrunStatus.Approved };
            var releaseHoldPayRunTypes =
                new[] { PayrunType.DirectPaymentsReleasedHolds, PayrunType.ResidentialReleasedHolds };
            ValidateDraftPayRun(draftPayRunCreationDomain, releaseHoldPayRunTypes);

            if (!recurringPayRunTypes.Contains(draftPayRunCreationDomain.Type) && !releaseHoldPayRunTypes.Contains(draftPayRunCreationDomain.Type))
            {
                throw new ApiException("The selected pay run type is not valid. Pick a valid type and try again",
                    HttpStatusCode.BadRequest);
            }

            if (recurringPayRunTypes.Contains(draftPayRunCreationDomain.Type))
            {
                var endOfLastPayRun = await _payRunGateway.GetEndDateOfLastPayRun(draftPayRunCreationDomain.Type);
                draftPayRunCreationDomain.StartDate = endOfLastPayRun.Date.AddDays(1);
            }
            else
            {
                draftPayRunCreationDomain.StartDate = draftPayRunCreationDomain.PaidFromDate.GetValueOrDefault();
            }

            if (recurringPayRunTypes.Contains(draftPayRunCreationDomain.Type))
            {
                var unApprovedPayRunExists = await _payRunGateway.CheckExistsUnApprovedPayRunAsync(draftPayRunCreationDomain.Type);
                if (unApprovedPayRunExists)
                    throw new ApiException($"Operation not allowed. There exists a pay run of the same type that is not approved", HttpStatusCode.PreconditionFailed);
            }

            if (releaseHoldPayRunTypes.Contains(draftPayRunCreationDomain.Type))
            {
                var adHocDraftPayRuns =
                    await _payRunGateway.GetPayRunsByTypeAndStatusAsync(releaseHoldPayRunTypes, unApprovedPayRunStatuses);

                foreach (var payRun in adHocDraftPayRuns)
                {
                    var firstPeriod = new DateRange(payRun.StartDate.Date, payRun.EndDate.Date);
                    var secondPeriod = new DateRange(draftPayRunCreationDomain.StartDate.Date, draftPayRunCreationDomain.EndDate.Date);
                    if (firstPeriod.OverlapsWithInclusive(secondPeriod))
                    {
                        throw new ApiException(
                            "Create operation failed. Not allowed to create adHoc pay run with date overlap if another is still not approved", HttpStatusCode.PreconditionFailed);
                    }
                }
            }

            draftPayRunCreationDomain.Status = PayrunStatus.Draft;

            ValidatePayRunDates(draftPayRunCreationDomain.StartDate, draftPayRunCreationDomain.EndDate);

            var payrun = draftPayRunCreationDomain.ToEntity();

            await _payRunGateway.CreateDraftPayRun(payrun);
            await _payrunsQueue.Send(payrun.Id);
        }

        private static void ValidateDraftPayRun(DraftPayRunCreationDomain creationDomain, PayrunType[] releaseHoldPayRunTypes)
        {
            // If released holds pay run, paid from date should be provided
            if (releaseHoldPayRunTypes.Contains(creationDomain.Type) && creationDomain.PaidFromDate == null)
            {
                throw new ApiException(
                    $"For a released holds pay run, date from must be provided",
                    HttpStatusCode.UnprocessableEntity);
            }
        }

        private static void ValidatePayRunDates(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            if (startDate > endDate)
            {
                throw new ApiException(
                    $"Pay run dates invalid. Start date cannot be greater that end date",
                    HttpStatusCode.UnprocessableEntity);
            }

            if (startDate == endDate)
            {
                throw new ApiException(
                    $"Pay run dates invalid. Pay run cannot start and end on the same day",
                    HttpStatusCode.UnprocessableEntity);
            }
        }
    }
}
