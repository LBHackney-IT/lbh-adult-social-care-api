using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCareApprovalHistoryGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCareBrokerageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareBrokerageUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareBrokerageUseCase.Concrete
{
    public class SetStageToNursingCarePackageUseCase : ISetStageToNursingCarePackageUseCase
    {
        private readonly INursingCareBrokerageGateway _nursingCareBrokerageGateway;
        private readonly INursingCareApprovalHistoryGateway _nursingCareApprovalHistoryGateway;
        private readonly IUsersGateway _usersGateway;

        public SetStageToNursingCarePackageUseCase(INursingCareBrokerageGateway nursingCareBrokerageGateway,
            INursingCareApprovalHistoryGateway nursingCareApprovalHistoryGateway,
            IUsersGateway usersGateway)
        {
            _nursingCareBrokerageGateway = nursingCareBrokerageGateway;
            _nursingCareApprovalHistoryGateway = nursingCareApprovalHistoryGateway;
            _usersGateway = usersGateway;
        }

        public async Task<bool> UpdatePackage(Guid nursingCarePackageId, int stageId)
        {
            var result = await _nursingCareBrokerageGateway.SetStage(nursingCarePackageId, stageId).ConfigureAwait(false);
            var userId = new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8");
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
            return result;
        }
    }
}
