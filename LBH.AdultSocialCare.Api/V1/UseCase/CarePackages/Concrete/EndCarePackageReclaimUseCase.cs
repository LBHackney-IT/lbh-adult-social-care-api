using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request;
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
    public class EndCarePackageReclaimUseCase : IEndCarePackageReclaimUseCase
    {
        private readonly ICarePackageReclaimGateway _gateway;
        private readonly IDatabaseManager _dbManager;
        private readonly ICarePackageHistoryGateway _carePackageHistoryGateway;
        private readonly ICarePackageGateway _carePackageGateway;

        public EndCarePackageReclaimUseCase(ICarePackageReclaimGateway gateway, IDatabaseManager dbManager
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
                .GetAsync(reclaimId, true)
                .EnsureExistsAsync($"Care package reclaim {reclaimId} not found");

            reclaim.Status = ReclaimStatus.Ended;
            reclaim.EndDate = request.EndDate?.Date;

            var carePackage = await _carePackageGateway
                .GetPackageAsync(reclaim.CarePackageId, PackageFields.Reclaims, true);

            await EndCareChargeWithoutPropertyThirteenPlusWeeks(reclaim, carePackage);

            var history = new CarePackageHistory
            {
                CarePackageId = reclaim.CarePackageId,
                Description = $"{reclaim.Type.GetDisplayName()} {ReclaimStatus.Ended}",
            };

            _carePackageHistoryGateway.Create(history);

            await _dbManager.SaveAsync();

            return reclaim.ToDomain();
        }

        private async Task EndCareChargeWithoutPropertyThirteenPlusWeeks(CarePackageReclaim carePackageReclaim, CarePackage carePackage)
        {
            // check existing reclaims in status Active and Pending
            var existingReclaims = carePackage.Reclaims
                .Where(r => r.Status.In(ReclaimStatus.Active, ReclaimStatus.Pending));

            // if user end CareChargeWithoutPropertyOneToTwelveWeeks end CareChargeWithoutPropertyThirteenPlusWeeks as well
            if (carePackageReclaim.SubType == ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks)
            {
                var existingCareChargeWithoutPropertyThirteenPlusWeeks =
                    existingReclaims.FirstOrDefault(r => r.SubType == ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks);

                if (existingCareChargeWithoutPropertyThirteenPlusWeeks != null)
                {
                    var reclaim = await _gateway
                        .GetAsync(existingCareChargeWithoutPropertyThirteenPlusWeeks.Id);

                    reclaim.Status = ReclaimStatus.Ended;
                    reclaim.EndDate = carePackageReclaim.EndDate?.Date;
                }
            }
        }
    }
}
