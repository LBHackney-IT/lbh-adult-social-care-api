using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces
{
    public interface IGetAllHomeCareApprovalHistoryUseCase
    {
        public Task<IEnumerable<HomeCareApprovalHistoryResponse>> GetAllAsync(Guid homeCarePackageId);
    }
}
