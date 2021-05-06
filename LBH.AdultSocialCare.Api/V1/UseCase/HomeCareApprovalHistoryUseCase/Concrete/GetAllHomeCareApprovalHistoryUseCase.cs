using LBH.AdultSocialCare.Api.V1.Boundary.HomeCareApprovalHistoryBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ApprovalHistoryGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApprovalHistoryUseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApprovalHistoryUseCase.Concrete
{
    public class GetAllHomeCareApprovalHistoryUseCase : IGetAllHomeCareApprovalHistoryUseCase
    {
        private readonly IApprovalHistoryGateway _approvalHistoryGateway;

        public GetAllHomeCareApprovalHistoryUseCase(IApprovalHistoryGateway approvalHistoryGateway)
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
