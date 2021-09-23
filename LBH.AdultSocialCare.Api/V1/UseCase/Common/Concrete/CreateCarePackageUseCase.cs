using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Http;
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
            var validPackageSchedulingOptions = Enum.GetValues(typeof(PackageScheduling))
                .Cast<PackageScheduling>()
                .Select(p => p.ToString())
                .ToArray();

            if (!validPackageSchedulingOptions.Contains(residentialCarePackageForCreation.PackagingScheduling, StringComparer.OrdinalIgnoreCase))
            {
                throw new ApiException(
                    $"Package scheduling option {residentialCarePackageForCreation.PackagingScheduling} is not valid");
            }

            switch (residentialCarePackageForCreation.PackagingScheduling)
            {
                // Check valid date range
                case nameof(PackageScheduling.Interim) when residentialCarePackageForCreation.EndDate == null || residentialCarePackageForCreation.EndDate > residentialCarePackageForCreation.StartDate.AddDays(42):
                    throw new ApiException("End date value expected to be under 6 weeks", StatusCodes.Status422UnprocessableEntity);
                case nameof(PackageScheduling.Temporary) when residentialCarePackageForCreation.EndDate == null || residentialCarePackageForCreation.EndDate > residentialCarePackageForCreation.StartDate.AddDays(365):
                    throw new ApiException("End date value expected to be under 52 weeks", StatusCodes.Status422UnprocessableEntity);
                case nameof(PackageScheduling.LongTerm) when residentialCarePackageForCreation.EndDate != null && residentialCarePackageForCreation.StartDate.AddDays(365) > residentialCarePackageForCreation.EndDate:
                    throw new ApiException("End date value expected to be null or over 52 weeks", StatusCodes.Status422UnprocessableEntity);
            }

            var carePackageEntity = residentialCarePackageForCreation.ToEntity();
            var carePackageSettingsEntity = residentialCarePackageForCreation.ToSettings();

            // Get and set random client on package
            var randomClient = await _clientsGateway.GetRandomAsync().ConfigureAwait(false);
            carePackageEntity.ServiceUserId = randomClient.Id;
            carePackageEntity.PackageType = PackageType.ResidentialCare;
            carePackageEntity.Status = PackageStatus.New;

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
