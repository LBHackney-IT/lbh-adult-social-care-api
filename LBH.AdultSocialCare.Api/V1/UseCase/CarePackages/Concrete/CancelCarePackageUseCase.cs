using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class CancelCarePackageUseCase : ICancelCarePackageUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IDatabaseManager _dbManager;

        public CancelCarePackageUseCase(ICarePackageGateway carePackageGateway, IDatabaseManager dbManager)
        {
            _carePackageGateway = carePackageGateway;
            _dbManager = dbManager;
        }

        public async Task ExecuteAsync(Guid packageId, string notes)
        {
            var package = await _carePackageGateway
                .GetPackageAsync(packageId, PackageFields.Reclaims, true)
                .EnsureExistsAsync($"Care package {packageId} not found");

            package.Status = PackageStatus.Cancelled;

            var reclaims = package.Reclaims.Where(r => r.Status.In(ReclaimStatus.Active, ReclaimStatus.Pending));

            foreach (var reclaim in reclaims)
            {
                reclaim.Status = ReclaimStatus.Ended;
                reclaim.EndDate = DateTimeOffset.Now;
            }

            package.Histories.Add(new CarePackageHistory
            {
                Status = HistoryStatus.Cancelled,
                Description = HistoryStatus.Cancelled.GetDisplayName(),
                RequestMoreInformation = notes
            });

            await _dbManager.SaveAsync();
        }
    }
}
