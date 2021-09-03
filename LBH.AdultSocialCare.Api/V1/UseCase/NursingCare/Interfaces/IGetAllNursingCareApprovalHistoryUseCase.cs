using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces
{
    public interface IGetAllNursingCareApprovalHistoryUseCase
    {
        public Task<IEnumerable<NursingCareApprovalHistoryResponse>> GetAllAsync(Guid nursingCarePackageId);
    }
}
