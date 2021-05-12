using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareApprovalHistoryBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCareApprovalHistoryGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCareApprovalHistoryGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApprovalHistoryUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApprovalHistoryUseCase.Concrete
{
    public class GetAllNursingCareApprovalHistoryUseCase : IGetAllNursingCareApprovalHistoryUseCase
    {
        private readonly INursingCareApprovalHistoryGateway _nursingCareApprovalHistoryGateway;

        public GetAllNursingCareApprovalHistoryUseCase(INursingCareApprovalHistoryGateway nursingCareApprovalHistoryGateway)
        {
            _nursingCareApprovalHistoryGateway = nursingCareApprovalHistoryGateway;
        }

        public async Task<IEnumerable<NursingCareApprovalHistoryResponse>> GetAllAsync(Guid nursingCarePackageId)
        {
            var nursingCareApprovalHistory = await _nursingCareApprovalHistoryGateway.ListAsync(nursingCarePackageId).ConfigureAwait(false);
            return nursingCareApprovalHistory.ToResponse();
        }
    }
}
