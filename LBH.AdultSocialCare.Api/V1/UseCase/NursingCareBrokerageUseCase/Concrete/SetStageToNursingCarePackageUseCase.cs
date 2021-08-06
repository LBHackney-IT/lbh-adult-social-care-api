using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCareApprovalHistoryGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCareBrokerageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.IdentityHelperUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareBrokerageUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareBrokerageUseCase.Concrete
{
    public class SetStageToNursingCarePackageUseCase : ISetStageToNursingCarePackageUseCase
    {
        private readonly INursingCareBrokerageGateway _nursingCareBrokerageGateway;
        private readonly INursingCareApprovalHistoryGateway _nursingCareApprovalHistoryGateway;
        private readonly IUsersGateway _usersGateway;
        private readonly IIdentityHelperUseCase _identityHelperUseCase;

        public SetStageToNursingCarePackageUseCase(INursingCareBrokerageGateway nursingCareBrokerageGateway,
            INursingCareApprovalHistoryGateway nursingCareApprovalHistoryGateway,
            IUsersGateway usersGateway,
            IIdentityHelperUseCase identityHelperUseCase)
        {
            _nursingCareBrokerageGateway = nursingCareBrokerageGateway;
            _nursingCareApprovalHistoryGateway = nursingCareApprovalHistoryGateway;
            _usersGateway = usersGateway;
            _identityHelperUseCase = identityHelperUseCase;
        }

        public async Task<bool> UpdatePackage(Guid nursingCarePackageId, int stageId)
        {
            var stageChanged = await _nursingCareBrokerageGateway.SetStage(nursingCarePackageId, stageId).ConfigureAwait(false);

            if (stageChanged)
            {
                var userId = _identityHelperUseCase.GetUserId();
                var user = await _usersGateway.GetAsync(userId).ConfigureAwait(false);
                var stageText = PackageStageConstants.GetStageText(stageId);
                var newPackageHistory = new NursingCareApprovalHistoryDomain()
                {
                    NursingCarePackageId = nursingCarePackageId,
                    ApprovedDate = DateTimeOffset.Now,
                    LogText = $"{stageText} {user.Name}",
                    UserId = user.Id
                };
                await _nursingCareApprovalHistoryGateway.CreateAsync(newPackageHistory.ToDb()).ConfigureAwait(false);
            }

            return stageChanged;
        }
    }
}
