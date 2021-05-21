using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCarePackageReclaimBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.PackageReclaimsBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ReclaimUseCase.Interfaces
{
    public interface IGetAllAmountOptionUseCase
    {
        public Task<IEnumerable<ReclaimAmountOptionResponse>> GetAllAsync();
    }
}
