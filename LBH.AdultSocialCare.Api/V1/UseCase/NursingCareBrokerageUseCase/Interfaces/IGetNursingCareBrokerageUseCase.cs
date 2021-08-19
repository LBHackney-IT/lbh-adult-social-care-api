using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareBrokerageUseCase.Interfaces
{
    public interface IGetNursingCareBrokerageUseCase
    {
        Task<NursingCareBrokerageInfoResponse> Execute(Guid nursingCarePackageId);
    }
}
