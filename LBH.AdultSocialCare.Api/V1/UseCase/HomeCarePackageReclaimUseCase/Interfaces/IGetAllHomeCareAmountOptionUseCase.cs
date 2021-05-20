using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCarePackageReclaimBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCarePackageReclaimUseCase.Interfaces
{
    public interface IGetAllHomeCareAmountOptionUseCase
    {
        public Task<IEnumerable<HomeCarePackageReclaimAmountOptionResponse>> GetAllAsync();
    }
}
