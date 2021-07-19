using LBH.AdultSocialCare.Api.V1.Boundary.HomeCareApprovePackageBoundary.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApprovePackageUseCase.Interfaces
{
    public interface IGetHomeCareApprovePackageUseCase
    {
        public Task<HomeCareApprovePackageResponse> Execute(Guid homeCarePackageId);
    }
}
