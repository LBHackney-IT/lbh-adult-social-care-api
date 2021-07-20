using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCare;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCareApprovalHistoryGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare
{
    public class ChangeStatusHomeCarePackageUseCase : IChangeStatusHomeCarePackageUseCase
    {
        private readonly IHomeCarePackageGateway _gateway;
        private readonly IHomeCareApprovalHistoryGateway _homeCareApprovalHistoryGateway;
        private readonly IUsersGateway _usersGateway;

        public ChangeStatusHomeCarePackageUseCase(IHomeCarePackageGateway homeCarePackageGateway,
            IHomeCareApprovalHistoryGateway homeCareApprovalHistoryGateway,
            IUsersGateway usersGateway)
        {
            _gateway = homeCarePackageGateway;
            _homeCareApprovalHistoryGateway = homeCareApprovalHistoryGateway;
            _usersGateway = usersGateway;
        }

        public async Task<HomeCarePackageDomain> UpdateAsync(Guid homeCarePackageId, int statusId, string requestMoreInformation = null)
        {
            var homeCarePackageEntity =
                await _gateway.ChangeStatusAsync(homeCarePackageId, statusId).ConfigureAwait(false);
            var userId = new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8");
            var user = await _usersGateway.GetAsync(userId).ConfigureAwait(false);
            var logText = ApprovalHistoryConstants.GetLogText(statusId);
            var newPackageHistory = new HomeCareApprovalHistoryDomain()
            {
                HomeCarePackageId = homeCarePackageId,
                StatusId = statusId,
                ApprovedDate = DateTimeOffset.Now,
                LogText = $"{logText} {user.FirstName} {user.MiddleName} {user.LastName} - {user.Role.RoleName}",
                CreatorRole = user.Role.RoleName,
                LogSubText = requestMoreInformation,
                UserId = user.Id
            };
            await _homeCareApprovalHistoryGateway.CreateAsync(newPackageHistory.ToDb()).ConfigureAwait(false);
            return homeCarePackageEntity.ToDomain();
        }
    }
}
