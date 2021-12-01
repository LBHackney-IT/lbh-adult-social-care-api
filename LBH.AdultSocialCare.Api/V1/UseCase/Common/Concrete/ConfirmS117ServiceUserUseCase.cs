using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class ConfirmS117ServiceUserUseCase : IConfirmS117ServiceUserUseCase
    {
        private readonly ICarePackageSettingsGateway _carePackageSettingsGateway;
        private readonly IDatabaseManager _dbManager;

        public ConfirmS117ServiceUserUseCase(ICarePackageSettingsGateway carePackageSettingsGateway, IDatabaseManager dbManager)
        {
            _carePackageSettingsGateway = carePackageSettingsGateway;
            _dbManager = dbManager;
        }

        public async Task ExecuteAsync(Guid packageId)
        {
            var packageSettings = await _carePackageSettingsGateway
                .GetPackageSettingsPlainAsync(packageId, true)
                .EnsureExistsAsync($"Care package settings {packageId} not found");

            if (!packageSettings.IsS117Client)
            {
                throw new ApiException("Service user must be S117 to confirm S117 Service User");
            }

            packageSettings.IsS117ClientConfirmed = true;

            await _dbManager.SaveAsync();
        }
    }
}
