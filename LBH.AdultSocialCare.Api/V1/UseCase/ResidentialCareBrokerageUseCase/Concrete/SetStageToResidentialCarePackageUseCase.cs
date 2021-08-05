using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareApprovalHistoryGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareBrokerageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.IdentityHelperUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareBrokerageUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareBrokerageUseCase.Concrete
{
    public class SetStageToResidentialCarePackageUseCase : ISetStageToResidentialCarePackageUseCase
    {
        private readonly IResidentialCareBrokerageGateway _residentialCareBrokerageGateway;
        private readonly IResidentialCareApprovalHistoryGateway _residentialCareApprovalHistoryGateway;
        private readonly IUsersGateway _usersGateway;
        private readonly IIdentityHelperUseCase _identityHelperUseCase;


        public SetStageToResidentialCarePackageUseCase(IResidentialCareBrokerageGateway residentialCareBrokerageGateway,
            IResidentialCareApprovalHistoryGateway residentialCareApprovalHistoryGateway,
            IUsersGateway usersGateway,
            IIdentityHelperUseCase identityHelperUseCase)
        {
            _residentialCareBrokerageGateway = residentialCareBrokerageGateway;
            _residentialCareApprovalHistoryGateway = residentialCareApprovalHistoryGateway;
            _usersGateway = usersGateway;
            _identityHelperUseCase = identityHelperUseCase;
        }

        public async Task<bool> UpdatePackage(Guid residentialCarePackageId, int stageId)
        {
            var result = await _residentialCareBrokerageGateway.SetStage(residentialCarePackageId, stageId).ConfigureAwait(false);
            var userId = _identityHelperUseCase.GetUserId();
            var user = await _usersGateway.GetAsync(userId).ConfigureAwait(false);
            var stageText = PackageStageConstants.GetStageText(stageId);
            var newPackageHistory = new ResidentialCareApprovalHistoryDomain()
            {
                ResidentialCarePackageId = residentialCarePackageId,
                ApprovedDate = DateTimeOffset.Now,
                LogText = $"{stageText} {user.Name}",
                UserId = user.Id
            };
            await _residentialCareApprovalHistoryGateway.CreateAsync(newPackageHistory.ToDb()).ConfigureAwait(false);
            return result;
        }
    }
}
