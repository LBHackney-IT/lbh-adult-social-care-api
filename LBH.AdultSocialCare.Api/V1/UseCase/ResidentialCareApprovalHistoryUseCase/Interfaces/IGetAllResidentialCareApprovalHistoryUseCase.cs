using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareApprovalHistoryBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareApprovalHistoryUseCase.Interfaces
{
    public interface IGetAllResidentialCareApprovalHistoryUseCase
    {
        public Task<IEnumerable<ResidentialCareApprovalHistoryResponse>> GetAllAsync(Guid residentialCarePackageId);
    }
}
