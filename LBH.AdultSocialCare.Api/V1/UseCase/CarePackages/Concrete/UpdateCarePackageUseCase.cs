using AutoMapper;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class UpdateCarePackageUseCase : IUpdateCarePackageUseCase
    {
        private readonly IMapper _mapper;
        private readonly IDatabaseManager _dbManager;
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly ICarePackageSettingsGateway _carePackageSettings;
        private readonly IEnsureSingleActivePackageTypePerUserUseCase _ensureSingleActivePackageTypePerUserUseCase;
        private readonly ICreatePackageResourceUseCase _createPackageResourceUseCase;

        public UpdateCarePackageUseCase(IMapper mapper, IDatabaseManager dbManager, ICarePackageGateway carePackageGateway,
            ICarePackageSettingsGateway carePackageSettings, IEnsureSingleActivePackageTypePerUserUseCase ensureSingleActivePackageTypePerUserUseCase,
            ICreatePackageResourceUseCase createPackageResourceUseCase)
        {
            _mapper = mapper;
            _dbManager = dbManager;
            _carePackageGateway = carePackageGateway;
            _carePackageSettings = carePackageSettings;
            _ensureSingleActivePackageTypePerUserUseCase = ensureSingleActivePackageTypePerUserUseCase;
            _createPackageResourceUseCase = createPackageResourceUseCase;
        }

        public async Task<CarePackagePlainResponse> UpdateAsync(Guid carePackageId, CarePackageUpdateDomain carePackageUpdateDomain)
        {
            var package = await _carePackageGateway.GetPackagePlainAsync(carePackageId, true).EnsureExistsAsync($"Care package with id {carePackageId} not found");
            await _ensureSingleActivePackageTypePerUserUseCase.ExecuteAsync(package.ServiceUserId, carePackageUpdateDomain.PackageType, package.Id);

            var packageSettings = await _carePackageSettings.GetPackageSettingsPlainAsync(carePackageId, true) ?? new CarePackageSettings
            {
                CarePackageId = package.Id,
                HasRespiteCare = false,
                HasDischargePackage = false,
                HospitalAvoidance = false,
                IsReEnablement = false,
                IsS117Client = false,
                IsS117ClientConfirmed = false
            };

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

            if (carePackageUpdateDomain.SocialWorkerCarePlanFileId == null && carePackageUpdateDomain.SocialWorkerCarePlanFile != null)
            {
                await _createPackageResourceUseCase.CreateFileAsync(carePackageId, PackageResourceType.CarePlanFile, carePackageUpdateDomain.SocialWorkerCarePlanFile);
            }

            // Update values
            _mapper.Map(carePackageUpdateDomain, package);
            package.Status = PackageStatus.InProgress; // Change status of package to in-progress
            _mapper.Map(carePackageUpdateDomain, packageSettings);
            package.Settings = packageSettings;

            // Save values
            await _dbManager.SaveAsync($"Failed to update care package with id {carePackageId}");
            return package.ToPlainDomain().ToResponse();
        }
    }
}
