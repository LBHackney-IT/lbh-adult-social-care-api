using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request;
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
    public class EndCareChargeUseCase : IEndCareChargeUseCase
    {
        private readonly ICarePackageReclaimGateway _gateway;
        private readonly IDatabaseManager _dbManager;
        private readonly ICarePackageHistoryGateway _carePackageHistoryGateway;
        private readonly ICarePackageGateway _carePackageGateway;

        public EndCareChargeUseCase(ICarePackageReclaimGateway gateway, IDatabaseManager dbManager
            , ICarePackageHistoryGateway carePackageHistoryGateway, ICarePackageGateway carePackageGateway)
        {
            _gateway = gateway;
            _dbManager = dbManager;
            _carePackageHistoryGateway = carePackageHistoryGateway;
            _carePackageGateway = carePackageGateway;
        }

        public async Task<CarePackageReclaimDomain> ExecuteAsync(Guid reclaimId, CarePackageReclaimEndRequest request)
        {
            var reclaim = await _gateway
                .GetAsync(reclaimId, false)
                .EnsureExistsAsync($"Care package reclaim {reclaimId} not found");

            // Throw if reclaim is not a care charge
            if (reclaim.Type != ReclaimType.CareCharge)
            {
                throw new ApiException($"Not allowed. Reclaim not a care charge",
                    HttpStatusCode.BadRequest);
            }

            // Throw if reclaim already ended
            if (reclaim.Status == ReclaimStatus.Ended)
            {
                throw new ApiException($"Care charge with id {reclaim.Id} already cancelled",
                    HttpStatusCode.BadRequest);
            }

            var carePackage = await _carePackageGateway
                .GetPackageAsync(reclaim.CarePackageId, PackageFields.Reclaims, true);

            var currentReclaim = carePackage.Reclaims.First(r => r.Id == reclaim.Id);
            currentReclaim.Status = ReclaimStatus.Ended;
            currentReclaim.EndDate = DateTimeOffset.Now.Date;
            carePackage.Histories.Add(new CarePackageHistory
            {
                Status = HistoryStatus.PackageInformation,
                Description = $"{currentReclaim.SubType.GetDisplayName()} Ended",
            });

            // If reclaim is active/pending cancel future reclaims
            if (currentReclaim.Status.In(ReclaimStatus.Active, ReclaimStatus.Pending))
            {
                var futureCareCharges = carePackage.Reclaims.Where(r =>
                    r.Type == ReclaimType.CareCharge && r.StartDate.Date < reclaim.StartDate.Date &&
                    r.Status.In(ReclaimStatus.Active, ReclaimStatus.Ended, ReclaimStatus.Pending));

                foreach (var careCharge in futureCareCharges)
                {
                    careCharge.Status = ReclaimStatus.Cancelled;
                    carePackage.Histories.Add(new CarePackageHistory
                    {
                        Status = HistoryStatus.PackageInformation,
                        Description = $"{careCharge.SubType.GetDisplayName()} Cancelled",
                    });
                }
            }

            await _dbManager.SaveAsync();

            return currentReclaim.ToDomain();
        }
    }
}
