using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.Services.Queuing;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
using LBH.AdultSocialCare.Data.Constants.Enums;
using System;
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
            var allowedPayRunTypes = new[] { PayrunType.ResidentialRecurring, PayrunType.ResidentialReleasedHolds };

            if (draftPayRunCreationDomain.Type.NotIn(allowedPayRunTypes))
            {
                throw new ApiException("The selected pay run type is not valid. Pick a valid type and try again",
                    HttpStatusCode.BadRequest);
            }

            var unApprovedPayRunExists = await _payRunGateway.CheckExistsUnApprovedPayRunAsync();
            if (unApprovedPayRunExists)
                throw new ApiException($"Operation not allowed. There exists a pay run that is not approved", HttpStatusCode.PreconditionFailed);

            var endOfLastPayRun = await _payRunGateway.GetEndDateOfLastPayRun(draftPayRunCreationDomain.Type);
            draftPayRunCreationDomain.StartDate = endOfLastPayRun.Date.AddDays(1);

            ValidatePayRunDates(draftPayRunCreationDomain.StartDate, draftPayRunCreationDomain.EndDate);

            draftPayRunCreationDomain.Status = PayrunStatus.Draft;

            var payrun = draftPayRunCreationDomain.ToEntity();

            await _payRunGateway.CreateDraftPayRun(payrun);
            await _payrunsQueue.Send(payrun.Id);
        }

        private static void ValidatePayRunDates(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            if (startDate > endDate)
            {
                throw new ApiException(
                    $"Pay run dates invalid. Start date {startDate:yyyy-MM-dd} is greater that end date {endDate:yyyy-MM-dd}",
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
