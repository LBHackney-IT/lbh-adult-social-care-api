using System.Linq;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class CreateCarePackageUseCase : ICreateCarePackageUseCase
    {
        private readonly IDatabaseManager _dbManager;
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IClientsGateway _clientsGateway;

        public CreateCarePackageUseCase(IDatabaseManager dbManager, ICarePackageGateway carePackageGateway, IClientsGateway clientsGateway)
        {
            _dbManager = dbManager;
            _carePackageGateway = carePackageGateway;
            _clientsGateway = clientsGateway;
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

            // Get and set random client on package
            var randomClient = await _clientsGateway.GetRandomAsync().ConfigureAwait(false);
            carePackageEntity.ServiceUserId = randomClient.Id;
            carePackageEntity.Status = PackageStatus.New;

            carePackageEntity.Settings = carePackageSettingsEntity;
            _carePackageGateway.Create(carePackageEntity);

            // TODO: Create record in package history?

            await _dbManager.SaveAsync("Failed to create care package").ConfigureAwait(false);
            return carePackageEntity.ToPlainDomain().ToResponse();
        }
    }
}
