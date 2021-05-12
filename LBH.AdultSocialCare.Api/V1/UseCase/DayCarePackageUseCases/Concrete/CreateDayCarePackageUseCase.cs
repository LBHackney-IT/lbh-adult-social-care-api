using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Concrete
{
    public class CreateDayCarePackageUseCase : ICreateDayCarePackageUseCase
    {
        private readonly IDayCarePackageGateway _dayCarePackageGateway;
        private readonly ICreateDayCarePackageHistoryUseCase _createDayCarePackageHistoryUseCase;

        public CreateDayCarePackageUseCase(IDayCarePackageGateway dayCarePackageGateway, ICreateDayCarePackageHistoryUseCase createDayCarePackageHistoryUseCase)
        {
            _dayCarePackageGateway = dayCarePackageGateway;
            _createDayCarePackageHistoryUseCase = createDayCarePackageHistoryUseCase;
        }

        public async Task<DayCarePackageResponse> Execute(DayCarePackageForCreationDomain dayCarePackageForCreationDomain)
        {
            var dayCarePackageEntity = dayCarePackageForCreationDomain.ToDb();
            var id = await _dayCarePackageGateway.CreateDayCarePackage(dayCarePackageEntity).ConfigureAwait(false);

            // Get the day care package with details
            var dayCarePackage = await _dayCarePackageGateway.GetDayCarePackage(id).ConfigureAwait(false);

            // Create history entries
            // Package created - New package
            var newPackageHistory = new DayCareApprovalHistoryForCreationDomain
            {
                DayCarePackageId = id,
                CreatorId = dayCarePackageEntity.CreatorId,
                PackageStatusId = dayCarePackageEntity.StatusId,
                LogText = $"Package requested by {dayCarePackage.CreatorName}",
                LogSubText = null,
                CreatorRole = dayCarePackage.CreatorRole
            };
            await _createDayCarePackageHistoryUseCase.Execute(newPackageHistory).ConfigureAwait(false);

            // Move package to submitted for approval
            // TODO: Change fixed value to fetch status Id from DB
            newPackageHistory.PackageStatusId = 2;
            newPackageHistory.LogText = $"Package submitted for approval by {dayCarePackage.CreatorName}";
            await _createDayCarePackageHistoryUseCase.Execute(newPackageHistory).ConfigureAwait(false);

            // Record movement from new to submitted to approval
            await _dayCarePackageGateway.UpdateDayCarePackageStatus(dayCarePackage.DayCarePackageId, 2).ConfigureAwait(false);

            return dayCarePackage.ToResponse();
        }
    }
}
