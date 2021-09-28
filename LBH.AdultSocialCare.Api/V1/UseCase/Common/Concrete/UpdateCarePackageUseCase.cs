using AutoMapper;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
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
            // var package = await Ensure.ExistsAsync(() => _carePackageGateway.GetPackagePlainAsync(carePackageId, true), $"Care package with id {carePackageId} not found");
            var packageSettings = await _carePackageSettings.GetPackageSettingsPlainAsync(carePackageId, true)
                .EnsureExistsAsync($"Package settings for package with id {carePackageId} not found");

            // Update values
            _mapper.Map(carePackageUpdateDomain, package);
            _mapper.Map(carePackageUpdateDomain, packageSettings);

            // Save values
            await _dbManager.SaveAsync($"Failed to update care package with id {carePackageId}");
            return package.ToPlainDomain().ToResponse();
        }
    }
}