using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareApprovalHistoryGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Interfaces;
using System;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.BusinessRules;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.UseCase.IdentityHelperUseCases.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Concrete
{
    public class ChangeStatusResidentialCarePackageUseCase : IChangeStatusResidentialCarePackageUseCase
    {
        private readonly IResidentialCarePackageGateway _gateway;
        private readonly IResidentialCareApprovalHistoryGateway _residentialCareApprovalHistoryGateway;
        private readonly IUsersGateway _usersGateway;
        private readonly IIdentityHelperUseCase _identityHelperUseCase;


        public ChangeStatusResidentialCarePackageUseCase(IResidentialCarePackageGateway residentialCarePackageGateway,
            IResidentialCareApprovalHistoryGateway residentialCareApprovalHistoryGateway,
            IUsersGateway usersGateway,
            IIdentityHelperUseCase identityHelperUseCase)
        {
            _gateway = residentialCarePackageGateway;
            _residentialCareApprovalHistoryGateway = residentialCareApprovalHistoryGateway;
            _usersGateway = usersGateway;
            _identityHelperUseCase = identityHelperUseCase;
        }

        public async Task<ResidentialCarePackageResponse> UpdateAsync(Guid residentialCarePackageId, int statusId, string requestMoreInformation = null)
        {
            var package = await _gateway.GetAsync(residentialCarePackageId).ConfigureAwait(false);

            if (!PackageStatusTransitions.CanChangeStatus(package.StatusId, statusId))
            {
                throw new ApiException(
                    "Cannot change status of nursing care package",
                    detail: $"Cannot set status of the package {residentialCarePackageId} to '{ApprovalHistoryConstants.GetLogText(statusId)}' as it is already in status '{ApprovalHistoryConstants.GetLogText(package.StatusId)}'");
            }

            var residentialCarePackageDomain = await _gateway.ChangeStatusAsync(residentialCarePackageId, statusId).ConfigureAwait(false);
            var userId = _identityHelperUseCase.GetUserId();
            var user = await _usersGateway.GetAsync(userId).ConfigureAwait(false);
            var logText = ApprovalHistoryConstants.GetLogText(statusId);
            var newPackageHistory = new ResidentialCareApprovalHistoryDomain()
            {
                ResidentialCarePackageId = residentialCarePackageId,
                StatusId = statusId,
                ApprovedDate = DateTimeOffset.Now,
                LogText = $"{logText} {user.Name}",
                LogSubText = requestMoreInformation,
                UserId = user.Id
            };
            await _residentialCareApprovalHistoryGateway.CreateAsync(newPackageHistory.ToDb()).ConfigureAwait(false);
            return residentialCarePackageDomain.ToResponse();
        }
    }
}
