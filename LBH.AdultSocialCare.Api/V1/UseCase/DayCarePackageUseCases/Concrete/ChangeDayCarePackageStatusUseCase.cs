using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Concrete
{
    public class ChangeDayCarePackageStatusUseCase : IChangeDayCarePackageStatusUseCase
    {
        private readonly IDayCarePackageGateway _dayCarePackageGateway;
        private readonly ICreateDayCarePackageHistoryUseCase _createDayCarePackageHistoryUseCase;

        public ChangeDayCarePackageStatusUseCase(IDayCarePackageGateway dayCarePackageGateway, ICreateDayCarePackageHistoryUseCase createDayCarePackageHistoryUseCase)
        {
            _dayCarePackageGateway = dayCarePackageGateway;
            _createDayCarePackageHistoryUseCase = createDayCarePackageHistoryUseCase;
        }

        public async Task<Guid> ChangeDayCarePackageStatus(Guid dayCarePackageId, int newStatusId)
        {
            var res = newStatusId switch
            {
                PackageStatusConstants.ApprovePackageId => await ApproveDayCarePackageDetails(dayCarePackageId)
                    .ConfigureAwait(false),
                PackageStatusConstants.RejectPackageId => await RejectDayCarePackageDetails(dayCarePackageId)
                    .ConfigureAwait(false),
                PackageStatusConstants.BrokerageNewId => await DayCarePackageBrokerageNew(dayCarePackageId)
                    .ConfigureAwait(false),
                PackageStatusConstants.BrokerageAssignedId => await DayCarePackageBrokerageAssigned(dayCarePackageId)
                    .ConfigureAwait(false),
                PackageStatusConstants.BrokerageQueryingId => await DayCarePackageBrokerageQuerying(dayCarePackageId)
                    .ConfigureAwait(false),
                PackageStatusConstants.BrokerageSupplierSourcedId =>
                    await DayCarePackageBrokerageSupplierSourced(dayCarePackageId).ConfigureAwait(false),
                PackageStatusConstants.BrokeragePricingAgreedId =>
                    await DayCarePackageBrokeragePricingAgreed(dayCarePackageId).ConfigureAwait(false),
                PackageStatusConstants.BrokerageSubmittedForApprovalId => await
                    DayCarePackageBrokerageSubmittedForApproval(dayCarePackageId).ConfigureAwait(false),
                PackageStatusConstants.BrokeredDealApprovedId =>
                    await DayCarePackageBrokeredDealApproved(dayCarePackageId).ConfigureAwait(false),
                PackageStatusConstants.BrokeredDealRejectedId =>
                    await DayCarePackageBrokeredDealRejected(dayCarePackageId).ConfigureAwait(false),
                PackageStatusConstants.PackageContractedId => await DayCarePackagePackageContracted(dayCarePackageId)
                    .ConfigureAwait(false),
                _ => throw new EntityNotFoundException($"Package status with id {newStatusId} not found")
            };

            return res;
        }

        public async Task<Guid> ApproveDayCarePackageDetails(Guid dayCarePackageId)
        {
            var res = await ChangeDayCarePackageStatus(dayCarePackageId, PackageStatusConstants.ApprovePackage,
                "Package contents approved by ", null).ConfigureAwait(false);

            // Move package to brokerage new
            await DayCarePackageBrokerageNew(dayCarePackageId).ConfigureAwait(false);

            return res;
        }

        public async Task<Guid> RejectDayCarePackageDetails(Guid dayCarePackageId)
        {
            var res = await ChangeDayCarePackageStatus(dayCarePackageId, PackageStatusConstants.RejectPackage,
                "Package rejected by ", null).ConfigureAwait(false);

            return res;
        }

        public async Task<Guid> RequestMoreInformationDayCarePackageDetails(Guid dayCarePackageId, string informationText)
        {
            var res = await ChangeDayCarePackageStatus(dayCarePackageId, PackageStatusConstants.RequestMoreInformation,
                "Further information requested by ", informationText).ConfigureAwait(false);

            return res;
        }

        public async Task<Guid> DayCarePackageBrokerageNew(Guid dayCarePackageId)
        {
            var res = await ChangeDayCarePackageStatus(dayCarePackageId, PackageStatusConstants.BrokerageNew,
                "Package moved to brokerage by ", null).ConfigureAwait(false);

            return res;
        }

        public async Task<Guid> DayCarePackageBrokerageAssigned(Guid dayCarePackageId)
        {
            var res = await ChangeDayCarePackageStatus(dayCarePackageId, PackageStatusConstants.BrokerageAssigned,
                "Brokering - Package moved to assigned by ", null).ConfigureAwait(false);

            return res;
        }

        public async Task<Guid> DayCarePackageBrokerageQuerying(Guid dayCarePackageId)
        {
            var res = await ChangeDayCarePackageStatus(dayCarePackageId, PackageStatusConstants.BrokerageQuerying,
                "Brokering - Package moved to querying by ", null).ConfigureAwait(false);

            return res;
        }

        public async Task<Guid> DayCarePackageBrokerageSupplierSourced(Guid dayCarePackageId)
        {
            var res = await ChangeDayCarePackageStatus(dayCarePackageId, PackageStatusConstants.BrokerageSupplierSourced,
                "Brokering - Package moved to supplier sourced by ", null).ConfigureAwait(false);

            return res;
        }

        public async Task<Guid> DayCarePackageBrokeragePricingAgreed(Guid dayCarePackageId)
        {
            var res = await ChangeDayCarePackageStatus(dayCarePackageId, PackageStatusConstants.BrokeragePricingAgreed,
                "Brokering - Package moved to pricing agreed by ", null).ConfigureAwait(false);

            return res;
        }

        public async Task<Guid> DayCarePackageBrokerageSubmittedForApproval(Guid dayCarePackageId)
        {
            var res = await ChangeDayCarePackageStatus(dayCarePackageId, PackageStatusConstants.BrokerageSubmittedForApproval,
                "Brokering - Package submitted for approval by ", null).ConfigureAwait(false);

            return res;
        }

        public async Task<Guid> DayCarePackageBrokeredDealApproved(Guid dayCarePackageId)
        {
            var res = await ChangeDayCarePackageStatus(dayCarePackageId, PackageStatusConstants.BrokeredDealApproved,
                "Package commercials approved by ", null).ConfigureAwait(false);

            return res;
        }

        public async Task<Guid> DayCarePackageBrokeredDealRejected(Guid dayCarePackageId)
        {
            var res = await ChangeDayCarePackageStatus(dayCarePackageId, PackageStatusConstants.BrokeredDealRejected,
                "Package commercials rejected by ", null).ConfigureAwait(false);

            return res;
        }

        public async Task<Guid> DayCarePackageBrokeredDealRequestMoreInformation(Guid dayCarePackageId, string informationText)
        {
            var res = await ChangeDayCarePackageStatus(dayCarePackageId, PackageStatusConstants.BrokeredDealRequestMoreInformation,
                "Package commercials - Further information requested by ", informationText).ConfigureAwait(false);

            return res;
        }

        public async Task<Guid> DayCarePackagePackageContracted(Guid dayCarePackageId)
        {
            var res = await ChangeDayCarePackageStatus(dayCarePackageId, PackageStatusConstants.PackageContracted,
                "Package contracted by ", null).ConfigureAwait(false);

            return res;
        }

        private async Task<Guid> ChangeDayCarePackageStatus(Guid dayCarePackageId, string statusName, string logText,
            string logSubText = null)
        {
            // Get the day care package with details
            var dayCarePackage = await _dayCarePackageGateway.GetDayCarePackage(dayCarePackageId).ConfigureAwait(false);

            // Get status id
            var newStatusId = await _dayCarePackageGateway.GetDayCareStatusByName(statusName).ConfigureAwait(false);

            // Change day care package status
            await _dayCarePackageGateway.UpdateDayCarePackageStatus(dayCarePackage.DayCarePackageId, newStatusId).ConfigureAwait(false);

            // Record history only if status has changed. Old > New
            if (dayCarePackage.StatusId.Equals(newStatusId)) return dayCarePackageId;

            // Record in day care package history
            var newPackageHistory = new DayCareApprovalHistoryForCreationDomain
            {
                DayCarePackageId = dayCarePackageId,
                CreatorId = dayCarePackage.CreatorId,
                PackageStatusId = newStatusId,
                LogText = $"{logText} {dayCarePackage.CreatorName}",
                LogSubText = logSubText,
                CreatorRole = dayCarePackage.CreatorRole
            };
            await _createDayCarePackageHistoryUseCase.Execute(newPackageHistory).ConfigureAwait(false);

            return dayCarePackageId;
        }
    }
}
