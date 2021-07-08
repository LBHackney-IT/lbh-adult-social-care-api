using Common.AppConstants.Enums;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using HttpServices.Models.Features.RequestFeatures;
using HttpServices.Models.Responses;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.UseCase.TransactionsUseCases.PayRunUseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.TransactionsUseCases.PayRunUseCases.Concrete
{
    public class PayRunUseCase : IPayRunUseCase
    {
        private readonly ITransactionsService _transactionsService;

        public PayRunUseCase(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        public async Task<Guid?> CreateNewPayRunUseCase(string payRunType)
        {
            if (!PayRunTypeEnum.ResidentialRecurring.EnumIsDefined(payRunType) && !PayRunSubTypeEnum.DirectPaymentsReleaseHolds.EnumIsDefined(payRunType))
            {
                throw new EntityNotFoundException("The pay run type is not valid. Please check and try again");
            }

            return payRunType switch
            {
                nameof(PayRunTypeEnum.ResidentialRecurring) => await _transactionsService.CreateResidentialRecurringPayRun()
                    .ConfigureAwait(false),
                nameof(PayRunTypeEnum.DirectPayments) => await _transactionsService.CreateDirectPaymentsPayRun()
                    .ConfigureAwait(false),
                nameof(PayRunTypeEnum.HomeCare) => await _transactionsService.CreateHomeCarePayRun()
                    .ConfigureAwait(false),
                nameof(PayRunSubTypeEnum.ResidentialReleaseHolds) => await _transactionsService.CreateResidentialReleaseHoldsPayRun()
                    .ConfigureAwait(false),
                nameof(PayRunSubTypeEnum.DirectPaymentsReleaseHolds) => await
                    _transactionsService.CreateDirectPaymentsReleaseHoldsPayRun()
                        .ConfigureAwait(false),
                _ => throw new EntityNotFoundException("The pay run type is not valid. Please check and try again")
            };
        }

        public async Task<PagedPayRunSummaryResponse> GetPayRunSummaryListUseCase(PayRunSummaryListParameters parameters)
        {
            return await _transactionsService.GetPayRunSummaryList(parameters).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ReleasedHoldsByTypeResponse>> GetReleasedHoldsCountUseCase(DateTimeOffset? fromDate = null, DateTimeOffset? toDate = null)
        {
            return await _transactionsService.GetReleasedHoldsCount(fromDate, toDate).ConfigureAwait(false);
        }
    }
}
