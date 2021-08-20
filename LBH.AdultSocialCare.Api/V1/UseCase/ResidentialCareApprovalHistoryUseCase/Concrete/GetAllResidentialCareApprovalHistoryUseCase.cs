using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareApprovalHistoryUseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareApprovalHistoryUseCase.Concrete
{
    public class GetAllResidentialCareApprovalHistoryUseCase : IGetAllResidentialCareApprovalHistoryUseCase
    {
        private readonly IResidentialCareApprovalHistoryGateway _residentialCareApprovalHistoryGateway;

        public GetAllResidentialCareApprovalHistoryUseCase(IResidentialCareApprovalHistoryGateway residentialCareApprovalHistoryGateway)
        {
            _residentialCareApprovalHistoryGateway = residentialCareApprovalHistoryGateway;
        }

        public async Task<IEnumerable<ResidentialCareApprovalHistoryResponse>> GetAllAsync(Guid residentialCarePackageId)
        {
            var residentialCareApprovalHistory = await _residentialCareApprovalHistoryGateway.ListAsync(residentialCarePackageId).ConfigureAwait(false);
            return residentialCareApprovalHistory.ToResponse();
        }
    }
}
