using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareApprovalHistoryGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareBrokerageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareBrokerageUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareBrokerageUseCase.Concrete
{
    public class SetStageToResidentialCarePackageUseCase : ISetStageToResidentialCarePackageUseCase
    {
        private readonly IResidentialCareBrokerageGateway _residentialCareBrokerageGateway;
        private readonly IResidentialCareApprovalHistoryGateway _residentialCareApprovalHistoryGateway;
        private readonly IUsersGateway _usersGateway;

        public SetStageToResidentialCarePackageUseCase(IResidentialCareBrokerageGateway residentialCareBrokerageGateway,
            IResidentialCareApprovalHistoryGateway residentialCareApprovalHistoryGateway,
            IUsersGateway usersGateway)
        {
            _residentialCareBrokerageGateway = residentialCareBrokerageGateway;
            _residentialCareApprovalHistoryGateway = residentialCareApprovalHistoryGateway;
            _usersGateway = usersGateway;
        }

        public async Task<bool> UpdatePackage(Guid residentialCarePackageId, int stageId)
        {
            var stageChanged = await _residentialCareBrokerageGateway.SetStage(residentialCarePackageId, stageId).ConfigureAwait(false);

            if (stageChanged)
            {
                var userId = new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8");
                var user = await _usersGateway.GetAsync(userId).ConfigureAwait(false);
                var stageText = PackageStageConstants.GetStageText(stageId);
                var newPackageHistory = new ResidentialCareApprovalHistoryDomain()
                {
                    ResidentialCarePackageId = residentialCarePackageId,
                    ApprovedDate = DateTimeOffset.Now,
                    LogText = $"{stageText} {user.Name}",
                    UserId = user.Id
                };
                await _residentialCareApprovalHistoryGateway.CreateAsync(newPackageHistory.ToDb())
                    .ConfigureAwait(false);
            }

            return stageChanged;
        }
    }
}
