using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Concrete
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
