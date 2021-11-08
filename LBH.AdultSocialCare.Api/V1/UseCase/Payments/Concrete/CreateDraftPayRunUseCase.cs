using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Payments.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete
{
    public class CreateDraftPayRunUseCase : ICreateDraftPayRunUseCase
    {
        private readonly IPayRunGateway _payRunGateway;

        public CreateDraftPayRunUseCase(IPayRunGateway payRunGateway)
        {
            _payRunGateway = payRunGateway;
        }

        public async Task CreateDraftPayRun(DraftPayRunCreationDomain draftPayRunCreationDomain)
        {
            var draftPayRunCount = await _payRunGateway.GetDraftPayRunCount(draftPayRunCreationDomain.Type);
            if (draftPayRunCount > 0)
                throw new ApiException($"A Pay Run with draft status for {draftPayRunCreationDomain.Type.ToDescription()} already exists!");

            ValidateDraftPayRun(draftPayRunCreationDomain);

            draftPayRunCreationDomain.Status = PayrunStatus.Draft;
            draftPayRunCreationDomain.StartDate = await _payRunGateway.GetDateOfLastPayRun(draftPayRunCreationDomain.Type);

            await _payRunGateway.CreateDraftPayRun(draftPayRunCreationDomain.ToEntity());
        }

        private static void ValidateDraftPayRun(DraftPayRunCreationDomain draftPayRunCreationDomain)
        {
            if (draftPayRunCreationDomain.PaidUpToDate > DateTimeOffset.Now)
            {
                throw new ApiException(
                    $"Pay run date is invalid. Pay run date should be equal or earlier than today",
                    HttpStatusCode.BadRequest);
            }
        }
    }
}
