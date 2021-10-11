using System;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
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

        public async Task ExecuteAsync(Guid packageId, CarePackageSubmissionDomain submissionInfo)
        {
            var package = await _carePackageGateway
                .GetPackageAsync(packageId, PackageFields.None)
                .EnsureExistsAsync($"Care package {packageId} not found");

            // TODO: VK: Add validation for double submission

            ValidatePackage(package);

            package.ApproverId = submissionInfo.ApproverId;
            package.Status = PackageStatus.SubmittedForApproval;

            package.Histories.Add(new CarePackageHistory
            {
                Status = HistoryStatus.SubmittedForApproval,
                Description = submissionInfo.Notes
            });

            await _dbManager.SaveAsync();
        }

        private static void ValidatePackage(CarePackage package)
        {
            if (package.SupplierId is null)
            {
                throw new ApiException("Supplier must be assigned to a package before submitting");
            }
        }
    }
}
