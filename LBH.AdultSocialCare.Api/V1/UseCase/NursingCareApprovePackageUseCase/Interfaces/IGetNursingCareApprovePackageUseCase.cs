using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApprovePackageUseCase.Interfaces
{
    public interface IGetNursingCareApprovePackageUseCase
    {
        public Task<NursingCareApprovePackageResponse> Execute(Guid nursingCarePackageId);
    }
}
