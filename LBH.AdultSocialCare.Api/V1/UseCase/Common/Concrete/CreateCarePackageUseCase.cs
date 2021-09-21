using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<CarePackagePlainResponse> ResidentialAsync(
            ResidentialCarePackageForCreationDomain residentialCarePackageForCreation)
        {
            var validPackageSchedulingOptions = new[] { "Interim", "Temporary", "LongTerm" };

            if (!validPackageSchedulingOptions.Contains(residentialCarePackageForCreation.PackagingScheduling, StringComparer.OrdinalIgnoreCase))
            {
                throw new ApiException(
                    $"Package scheduling option {residentialCarePackageForCreation.PackagingScheduling} is not valid");
            }

            var carePackageEntity = residentialCarePackageForCreation.ToEntity();
            var carePackageSettingsEntity = residentialCarePackageForCreation.ToSettings();

            // Get and set random client on package
            var randomClient = await _clientsGateway.GetRandomAsync().ConfigureAwait(false);
            carePackageEntity.ServiceUserId = randomClient.Id;
            carePackageEntity.PackageType = (int) PackageTypeEnum.ResidentialCare;
            carePackageEntity.Status = PackageStatusEnum.New;

            carePackageEntity.ResidentialCareSettings = carePackageSettingsEntity;
            _carePackageGateway.Create(carePackageEntity);

            // Set package status and record the change in package history
            //Change status of package
            /*await _changeStatusResidentialCarePackageUseCase
                .UpdateAsync(residentialCarePackageResponse.Id, ApprovalHistoryConstants.NewPackageId)
                .ConfigureAwait(false);

            await _changeStatusResidentialCarePackageUseCase
                .UpdateAsync(residentialCarePackageResponse.Id, ApprovalHistoryConstants.SubmittedForApprovalId)
                .ConfigureAwait(false);*/

            await _dbManager.SaveAsync("Failed to create residential care package").ConfigureAwait(false);
            return carePackageEntity.ToPlainDomain().ToResponse();
        }
    }
}
