using System;
using System.Threading.Tasks;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class EndCarePackageReclaimUseCase : IEndCarePackageReclaimUseCase
    {
        private readonly ICarePackageReclaimGateway _gateway;
        private readonly IDatabaseManager _dbManager;

        public EndCarePackageReclaimUseCase(ICarePackageReclaimGateway gateway, IDatabaseManager dbManager)
        {
            _gateway = gateway;
            _dbManager = dbManager;
        }

        public async Task<CarePackageReclaimDomain> ExecuteAsync(Guid reclaimId, CarePackageReclaimEndRequest request)
        {
            var reclaim = await _gateway
                .GetAsync(reclaimId)
                .EnsureExistsAsync($"Care package reclaim {reclaimId} not found");

            reclaim.Status = ReclaimStatus.Ended;
            reclaim.EndDate = request.EndDate?.Date;

            await _dbManager.SaveAsync();
            return reclaim.ToDomain();
        }
    }
}