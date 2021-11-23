using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

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
                .GetAsync(reclaimId)
                .EnsureExistsAsync($"Care package reclaim {reclaimId} not found");

            reclaim.Status = ReclaimStatus.Cancelled;

            var carePackage = await _carePackageGateway
                .GetPackageAsync(reclaim.CarePackageId, PackageFields.Reclaims, true);

            ValidateCareCharge(reclaim, carePackage);

            var history = new CarePackageHistory
            {
                CarePackageId = reclaim.CarePackageId,
                Description = $"{reclaim.Type.GetDisplayName()} {ReclaimStatus.Cancelled}",
            };

            _carePackageHistoryGateway.Create(history);
            await _dbManager.SaveAsync();

            return reclaim.ToDomain();
        }

        private static void ValidateCareCharge(CarePackageReclaim carePackageReclaim, CarePackage carePackage)
        {
            var existingReclaims = carePackage.Reclaims
                .Where(r => r.Status.In(ReclaimStatus.Active, ReclaimStatus.Pending));

            // Check existing CareChargeWithoutPropertyThirteenPlusWeeks when cancel CareChargeWithoutPropertyOneToTwelveWeeks type
            if (carePackageReclaim.SubType == ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks)
            {
                var existingCareChargeWithoutPropertyThirteenPlusWeeks =
                    existingReclaims.FirstOrDefault(r => r.SubType == ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks);

                if (existingCareChargeWithoutPropertyThirteenPlusWeeks != null)
                {
                    throw new ApiException(
                        $"There is a existing {existingCareChargeWithoutPropertyThirteenPlusWeeks.Status.GetDisplayName()} {ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks.GetDisplayName()}, to avoid the overlap cancel it first",
                        HttpStatusCode.BadRequest);
                }
            }
        }
    }
}
