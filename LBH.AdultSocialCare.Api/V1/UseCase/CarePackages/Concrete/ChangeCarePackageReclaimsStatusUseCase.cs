using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class CancelCarePackageReclaimsUseCase : ICancelCarePackageReclaimsUseCase
    {
        private readonly ICarePackageReclaimGateway _gateway;
        private readonly IDatabaseManager _dbManager;
        private readonly ICarePackageHistoryGateway _carePackageHistoryGateway;

        public CancelCarePackageReclaimsUseCase(ICarePackageReclaimGateway gateway, IDatabaseManager dbManager, ICarePackageHistoryGateway carePackageHistoryGateway)
        {
            _gateway = gateway;
            _dbManager = dbManager;
            _carePackageHistoryGateway = carePackageHistoryGateway;
        }

        public async Task<CarePackageReclaimDomain> ExecuteAsync(Guid reclaimId)
        {
            var reclaim = await _gateway
                .GetAsync(reclaimId)
                .EnsureExistsAsync($"Care package reclaim {reclaimId} not found");

            reclaim.Status = ReclaimStatus.Cancelled;

            await _dbManager.SaveAsync();

            var history = new CarePackageHistory
            {
                CarePackageId = reclaim.CarePackageId,
                Description = $"{reclaim.Type.GetDisplayName()} {ReclaimStatus.Cancelled}",
            };

            await _carePackageHistoryGateway.Create(history);

            return reclaim.ToDomain();
        }
    }
}
