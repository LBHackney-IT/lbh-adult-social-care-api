using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareBrokerageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareBrokerageDomains;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareBrokerageUseCase.Interfaces
{
    public interface ICreateNursingCareBrokerageUseCase
    {
        Task<NursingCareBrokerageInfoResponse> ExecuteAsync(NursingCareBrokerageInfoCreationDomain nursingCareBrokerageInfoCreationDomain);
    }
}
