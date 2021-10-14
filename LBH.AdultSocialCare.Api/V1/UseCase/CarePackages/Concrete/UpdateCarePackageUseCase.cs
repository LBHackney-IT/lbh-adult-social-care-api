using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class UpdateCarePackageUseCase : IUpdateCarePackageUseCase
    {
        private readonly IMapper _mapper;
        private readonly IDatabaseManager _dbManager;
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly ICarePackageSettingsGateway _carePackageSettings;

        public UpdateCarePackageUseCase(IMapper mapper, IDatabaseManager dbManager, ICarePackageGateway carePackageGateway, ICarePackageSettingsGateway carePackageSettings)
        {
            _mapper = mapper;
            _dbManager = dbManager;
            _carePackageGateway = carePackageGateway;
            _carePackageSettings = carePackageSettings;
        }

        public async Task<CarePackagePlainResponse> UpdateAsync(Guid carePackageId, CarePackageUpdateDomain carePackageUpdateDomain)
        {
            var package = await _carePackageGateway.GetPackagePlainAsync(carePackageId, true).EnsureExistsAsync($"Care package with id {carePackageId} not found");
            var packageSettings = await _carePackageSettings.GetPackageSettingsPlainAsync(carePackageId, true)
                .EnsureExistsAsync($"Package settings for package with id {carePackageId} not found");

            var allowedPackageStatuses = new[] { PackageStatus.New, PackageStatus.InProgress };

            if (package.PackageType != carePackageUpdateDomain.PackageType && !allowedPackageStatuses.Contains(package.Status))
            {
                throw new ApiException(
                    $"Failed to update package. Package type cannot be changed for package with status {package.Status.GetDisplayName()}", HttpStatusCode.BadRequest);
            }

            if (package.PackageType != carePackageUpdateDomain.PackageType && carePackageUpdateDomain.PackageType == PackageType.ResidentialCare)
            {
                // Delete funded nursing care if added to package
                await _carePackageGateway.DeleteReclaimsForPackage(carePackageId, ReclaimType.Fnc);
            }

            // Update values
            _mapper.Map(carePackageUpdateDomain, package);
            package.Status = PackageStatus.InProgress; // Change status of package to in-progress
            _mapper.Map(carePackageUpdateDomain, packageSettings);

            // Save values
            await _dbManager.SaveAsync($"Failed to update care package with id {carePackageId}");
            return package.ToPlainDomain().ToResponse();
        }
    }
}
