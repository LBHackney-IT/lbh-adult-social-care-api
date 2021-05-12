using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareApproveCommercialBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApproveCommercialUseCase.Interfaces
{
    public interface IGetNursingCareApproveCommercialUseCase
    {
        public Task<NursingCareApproveCommercialResponse> Execute(Guid nursingCarePackageId);
    }
}
