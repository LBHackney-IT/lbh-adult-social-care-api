using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
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
                .GetPackageAsync(packageId, PackageFields.None, true)
                .EnsureExistsAsync($"Care package {packageId} not found");

            ValidatePackage(package);

            package.ApproverId = submissionInfo.ApproverId;
            package.Status = PackageStatus.SubmittedForApproval;

            package.Histories.Add(new CarePackageHistory
            {
                Status = HistoryStatus.SubmittedForApproval,
                Description = HistoryStatus.SubmittedForApproval.GetDisplayName(),
                RequestMoreInformation = submissionInfo.Notes
            });

            await _dbManager.SaveAsync();
        }

        private static void ValidatePackage(CarePackage package)
        {
            if (package.SupplierId is null)
            {
                throw new ApiException("Supplier must be assigned to a package before submitting");
            }

            if (package.Status.NotIn(PackageStatus.New, PackageStatus.InProgress))
            {
                throw new ApiException("Package has been approved already");
            }
        }
    }
}
