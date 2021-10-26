using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class ApproveCarePackageUseCase : IApproveCarePackageUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IDatabaseManager _dbManager;

        public ApproveCarePackageUseCase(ICarePackageGateway carePackageGateway, IDatabaseManager dbManager)
        {
            _carePackageGateway = carePackageGateway;
            _dbManager = dbManager;
        }

        public async Task ExecuteAsync(Guid packageId, string notes)
        {
            var package = await _carePackageGateway
                .GetPackageAsync(packageId, PackageFields.None, true)
                .EnsureExistsAsync($"Care package {packageId} not found");

            package.Status = PackageStatus.Approved;

            package.Histories.Add(new CarePackageHistory
            {
                Status = HistoryStatus.PackageApproved,
                Description = HistoryStatus.PackageApproved.GetDisplayName(),
                RequestMoreInformation = notes
            });

            await _dbManager.SaveAsync();
        }
    }
}
