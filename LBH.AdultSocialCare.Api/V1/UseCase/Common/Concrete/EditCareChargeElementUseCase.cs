using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class EditCareChargeElementUseCase : IEditCareChargeElementUseCase
    {
        private readonly ICancelOrEndCareChargeElementUseCase _cancelOrEndCareChargeElementUseCase;
        private readonly ITransactionManager _transactionManager;
        private readonly ICareChargesGateway _careChargesGateway;

        public EditCareChargeElementUseCase(ICancelOrEndCareChargeElementUseCase cancelOrEndCareChargeElementUseCase, ITransactionManager transactionManager, ICareChargesGateway careChargesGateway)
        {
            _cancelOrEndCareChargeElementUseCase = cancelOrEndCareChargeElementUseCase;
            _transactionManager = transactionManager;
            _careChargesGateway = careChargesGateway;
        }

        public async Task<bool> ExecuteAsync(Guid packageCareChargeId, IEnumerable<CareChargeElementForUpdateDomain> careChargeElementsForUpdate)
        {
            await using var transaction = await _transactionManager.BeginTransactionAsync().ConfigureAwait(false);
            try
            {
                foreach (var careChargeElement in careChargeElementsForUpdate)
                {
                    // Cancel care charge element
                    await _cancelOrEndCareChargeElementUseCase
                        .ExecuteCancelAsync(packageCareChargeId, careChargeElement.CareElementId).ConfigureAwait(false);

                    // Create new care charge element
                    var newCareChargeElement = new CareChargeElement
                    {
                        CareChargeId = packageCareChargeId,
                        StatusId = (int) ReclaimStatus.Active,
                        TypeId = careChargeElement.TypeId,
                        ClaimCollectorId = careChargeElement.CollectorId,
                        ClaimReasons = null,
                        Name = careChargeElement.ElementName,
                        Amount = careChargeElement.Amount,
                        StartDate = careChargeElement.StartDate,
                        EndDate = careChargeElement.EndDate,
                        PaidUpTo = null,
                        PreviousPaidUpTo = null
                    };

                    await _careChargesGateway.CreateCareChargeElementAsync(newCareChargeElement).ConfigureAwait(false);
                }

                await transaction.CommitAsync().ConfigureAwait(false);

                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync().ConfigureAwait(false);
                throw;
            }
        }
    }
}
