using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApprovalHistoryUseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCareApprovalHistoryGateways;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApprovalHistoryUseCase.Concrete
{
    public class GetAllHomeCareApprovalHistoryUseCase : IGetAllHomeCareApprovalHistoryUseCase
    {
        private readonly IHomeCareApprovalHistoryGateway _approvalHistoryGateway;

        public GetAllHomeCareApprovalHistoryUseCase(IHomeCareApprovalHistoryGateway approvalHistoryGateway)
        {
            _approvalHistoryGateway = approvalHistoryGateway;
        }

        public async Task<IEnumerable<HomeCareApprovalHistoryResponse>> GetAllAsync(Guid homeCarePackageId)
        {
            var homeCareApprovalHistory = await _approvalHistoryGateway.ListAsync(homeCarePackageId).ConfigureAwait(false);
            return homeCareApprovalHistory.ToResponse();
        }
    }
}
