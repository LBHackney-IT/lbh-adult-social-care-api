using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareApprovalHistoryBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApprovalHistoryUseCase.Interfaces
{
    public interface IGetAllNursingCareApprovalHistoryUseCase
    {
        public Task<IEnumerable<NursingCareApprovalHistoryResponse>> GetAllAsync(Guid nursingCarePackageId);
    }
}
