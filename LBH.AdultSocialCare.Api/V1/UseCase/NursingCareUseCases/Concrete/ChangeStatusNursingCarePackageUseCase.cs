using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareApprovePackageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCareApprovalHistoryGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.IdentityHelperUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Concrete
{
    public class ChangeStatusNursingCarePackageUseCase : IChangeStatusNursingCarePackageUseCase
    {
        private readonly INursingCarePackageGateway _gateway;
        private readonly INursingCareApprovalHistoryGateway _nursingCareApprovalHistoryGateway;
        private readonly IUsersGateway _usersGateway;
        private readonly IIdentityHelperUseCase _identityHelperUseCase;

        public ChangeStatusNursingCarePackageUseCase(INursingCarePackageGateway nursingCarePackageGateway,
            INursingCareApprovalHistoryGateway nursingCareApprovalHistoryGateway,
            IUsersGateway usersGateway,
            IIdentityHelperUseCase identityHelperUseCase)
        {
            _gateway = nursingCarePackageGateway;
            _nursingCareApprovalHistoryGateway = nursingCareApprovalHistoryGateway;
            _usersGateway = usersGateway;
            _identityHelperUseCase = identityHelperUseCase;
        }

        public async Task<NursingCarePackageResponse> UpdateAsync(Guid nursingCarePackageId, int statusId, string requestMoreInformation = null)
        {
            var nursingCarePackageDomain = await _gateway.ChangeStatusAsync(nursingCarePackageId, statusId).ConfigureAwait(false);
            var userId = _identityHelperUseCase.GetUserId();
            var user = await _usersGateway.GetAsync(userId).ConfigureAwait(false);
            var logText = ApprovalHistoryConstants.GetLogText(statusId);
            var newPackageHistory = new NursingCareApprovalHistoryDomain()
            {
                NursingCarePackageId = nursingCarePackageId,
                StatusId = statusId,
                ApprovedDate = DateTimeOffset.Now,
                LogText = $"{logText} {user.Name}",
                LogSubText = requestMoreInformation,
                UserId = user.Id
            };
            await _nursingCareApprovalHistoryGateway.CreateAsync(newPackageHistory.ToDb()).ConfigureAwait(false);
            return nursingCarePackageDomain.ToResponse();
        }


    }
}
