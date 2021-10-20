using System;
using System.Threading.Tasks;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class ChangeCarePackageReclaimsStatusUseCase : IChangeCarePackageReclaimsStatusUseCase
    {
        private readonly ICarePackageReclaimGateway _gateway;
        private readonly IDatabaseManager _dbManager;

        public ChangeCarePackageReclaimsStatusUseCase(ICarePackageReclaimGateway gateway, IDatabaseManager dbManager)
        {
            _gateway = gateway;
            _dbManager = dbManager;
        }

        public async Task<CarePackageReclaimDomain> ExecuteAsync(Guid reclaimId, ReclaimStatus status)
        {
            var reclaim = await _gateway
                .GetAsync(reclaimId)
                .EnsureExistsAsync($"Care package reclaim {reclaimId} not found");

            reclaim.Status = status;
            await _dbManager.SaveAsync();

            return reclaim.ToDomain();
        }
    }
}