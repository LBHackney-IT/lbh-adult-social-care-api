using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Extensions;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class CreateCarePackageUseCase : ICreateCarePackageUseCase
    {
        private readonly IDatabaseManager _dbManager;
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IServiceUserGateway _serviceUserGateway;

        public CreateCarePackageUseCase(IDatabaseManager dbManager, ICarePackageGateway carePackageGateway, IServiceUserGateway serviceUserGateway)
        {
            _dbManager = dbManager;
            _carePackageGateway = carePackageGateway;
            _serviceUserGateway = serviceUserGateway;
        }

        public async Task<CarePackagePlainResponse> CreateAsync(
            CarePackageForCreationDomain carePackageForCreation)
        {
            var validPackageTypes = new[] { PackageType.ResidentialCare, PackageType.NursingCare };
            if (!validPackageTypes.Contains(carePackageForCreation.PackageType))
            {
                throw new ApiException($"Please select a valid package type.",
                    StatusCodes.Status422UnprocessableEntity);
            }

            var carePackageEntity = carePackageForCreation.ToEntity();
            var carePackageSettingsEntity = carePackageForCreation.ToSettings();
            var histories = new List<CarePackageHistory>()
            {
                new CarePackageHistory
                {
                    Description = HistoryStatus.NewPackage.GetDisplayName(),
                    RequestMoreInformation = "",
                    Status = HistoryStatus.NewPackage
                }
            };

            // Get and set random client on package
            var randomClient = await _serviceUserGateway.GetRandomAsync().ConfigureAwait(false);
            carePackageEntity.ServiceUserId = randomClient.Id;
            carePackageEntity.Status = PackageStatus.New;

            carePackageEntity.Settings = carePackageSettingsEntity;
            carePackageEntity.Histories = histories;
            _carePackageGateway.Create(carePackageEntity);

            // TODO: Create record in package history?

            await _dbManager.SaveAsync("Failed to create care package").ConfigureAwait(false);
            return carePackageEntity.ToPlainDomain().ToResponse();
        }
    }
}
