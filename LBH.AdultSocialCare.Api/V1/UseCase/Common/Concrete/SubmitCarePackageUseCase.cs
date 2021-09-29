using System;
using System.Threading.Tasks;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class SubmitCarePackageUseCase : ISubmitCarePackageUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IDatabaseManager _dbManager;

        public SubmitCarePackageUseCase(ICarePackageGateway carePackageGateway, IDatabaseManager dbManager)
        {
            _carePackageGateway = carePackageGateway;
            _dbManager = dbManager;
        }

        public async Task ExecuteAsync(Guid packageId, CarePackageSubmissionDomain packageSubmission)
        {
            var package = await _carePackageGateway
                .GetPackageAsync(packageId)
                .EnsureExistsAsync($"Care package {packageId} not found");

            package.Status = PackageStatus.SubmittedForApproval;
            package.Histories.Add(new CarePackageHistory
            {
                Status = HistoryStatus.SubmittedForApproval,
                Description = packageSubmission.Notes
            });

            await _dbManager.SaveAsync();
        }
    }
}
