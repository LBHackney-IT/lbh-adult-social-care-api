using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.Core;
using LBH.AdultSocialCare.Data.Constants.Enums;

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
                .GetPackageAsync(packageId, PackageFields.Details | PackageFields.Reclaims, true)
                .EnsureExistsAsync($"Care package {packageId} not found");

            package.Status = PackageStatus.Cancelled;

            var reclaims = package.Reclaims.Where(r => r.Status.In(ReclaimStatus.Active, ReclaimStatus.Pending));
            var today = DateTimeOffset.UtcNow.Date;

            foreach (var reclaim in reclaims)
            {
                reclaim.Status = ReclaimStatus.Cancelled;
                reclaim.EndDate = today;

                package.AddHistoryEntry($"{reclaim.SubType.GetDisplayName()} cancelled");
            }

            foreach (var detail in package.Details)
            {
                // mark all details as updated to be refunded by invoice generator. Alternatives would be
                // - add smth. like CarePackageDetail.IsCancelled / Status column  to DB
                // - handle cancelled packages separately in invoicing,
                //   need to update DB schema to avoid processing -all- cancelled packages at each generator run
                detail.Version++;

                if (detail.EndDate == null || detail.EndDate.Value > today)
                {
                    detail.EndDate = today;

                    if (detail.Type is PackageDetailType.AdditionalNeed) // core cost represents package itself
                    {
                        package.AddHistoryEntry(
                            $"Additional Need {detail.StartDate:yyyy-MM-dd} - {detail.EndDate:yyyy-MM-dd} cancelled");
                    }
                }
            }

            package.AddHistoryEntry(HistoryStatus.Cancelled.GetDisplayName(), HistoryStatus.Cancelled, notes);

            await _dbManager.SaveAsync();
        }
    }
}
