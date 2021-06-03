using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareApprovalHistoryGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Concrete
{
    public class ChangeStatusResidentialCarePackageUseCase : IChangeStatusResidentialCarePackageUseCase
    {
        private readonly IResidentialCarePackageGateway _gateway;
        private readonly IResidentialCareApprovalHistoryGateway _residentialCareApprovalHistoryGateway;
        private readonly IUsersGateway _usersGateway;
        public ChangeStatusResidentialCarePackageUseCase(IResidentialCarePackageGateway residentialCarePackageGateway,
            IResidentialCareApprovalHistoryGateway residentialCareApprovalHistoryGateway,
            IUsersGateway usersGateway)
        {
            _gateway = residentialCarePackageGateway;
            _residentialCareApprovalHistoryGateway = residentialCareApprovalHistoryGateway;
            _usersGateway = usersGateway;
        }

        public async Task<ResidentialCarePackageResponse> UpdateAsync(Guid residentialCarePackageId, int statusId)
        {
            var residentialCarePackageDomain = await _gateway.ChangeStatusAsync(residentialCarePackageId, statusId).ConfigureAwait(false);
            var userId = new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8");
            var user = await _usersGateway.GetAsync(userId).ConfigureAwait(false);
            var logText = ApprovalHistoryConstants.GetLogText(statusId);
            var newPackageHistory = new ResidentialCareApprovalHistoryDomain()
            {
                ResidentialCarePackageId = residentialCarePackageId,
                ApprovedDate = DateTimeOffset.Now,
                LogText = $"{logText} {user.FirstName} {user.MiddleName} {user.LastName} - {user.Role.RoleName}"
            };
            await _residentialCareApprovalHistoryGateway.CreateAsync(newPackageHistory.ToDb()).ConfigureAwait(false);
            return residentialCarePackageDomain.ToResponse();
        }
    }
}
