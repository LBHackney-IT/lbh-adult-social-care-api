using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class CancelCarePackageReclaimsUseCase : ICancelCarePackageReclaimsUseCase
    {
        private readonly ICarePackageReclaimGateway _gateway;
        private readonly IDatabaseManager _dbManager;
        private readonly ICarePackageHistoryGateway _carePackageHistoryGateway;
        private readonly ICarePackageGateway _carePackageGateway;

        public CancelCarePackageReclaimsUseCase(ICarePackageReclaimGateway gateway, IDatabaseManager dbManager
            , ICarePackageHistoryGateway carePackageHistoryGateway, ICarePackageGateway carePackageGateway)
        {
            _gateway = gateway;
            _dbManager = dbManager;
            _carePackageHistoryGateway = carePackageHistoryGateway;
            _carePackageGateway = carePackageGateway;
        }

        public async Task<CarePackageReclaimDomain> ExecuteAsync(Guid reclaimId)
        {
            var reclaim = await _gateway
                .GetAsync(reclaimId, false)
                .EnsureExistsAsync($"Care package reclaim {reclaimId} not found");

            // Throw if reclaim already cancelled
            if (reclaim.Status == ReclaimStatus.Cancelled)
            {
                throw new ApiException($"Reclaim with id {reclaimId} already cancelled", HttpStatusCode.BadRequest);
            }

            var carePackage = await _carePackageGateway
                .GetPackageAsync(reclaim.CarePackageId, PackageFields.Reclaims, true);

            // Cancel current reclaim
            var currentReclaim = carePackage.Reclaims.Single(r => r.Id == reclaim.Id);
            currentReclaim.Status = ReclaimStatus.Cancelled;

            carePackage.Histories.Add(new CarePackageHistory
            {
                Status = HistoryStatus.PackageInformation,
                Description = $"{currentReclaim.Type.GetDisplayName()} cancelled"
            });

            // Get and cancel active/pending reclaims starting after the cancelled reclaim
            var reclaimsToBeCancelled = carePackage.Reclaims.Where(r =>
                r.Type == ReclaimType.CareCharge && r.StartDate.Date > reclaim.StartDate &&
                r.Status.In(ReclaimStatus.Active, ReclaimStatus.Pending)).ToList();

            foreach (var packageReclaim in reclaimsToBeCancelled)
            {
                packageReclaim.Status = ReclaimStatus.Cancelled;
                carePackage.Histories.Add(new CarePackageHistory
                {
                    Status = HistoryStatus.PackageInformation,
                    Description = $"{packageReclaim.Type.GetDisplayName()} cancelled"
                });
            }

            await _dbManager.SaveAsync();

            return reclaim.ToDomain();
        }
    }
}
