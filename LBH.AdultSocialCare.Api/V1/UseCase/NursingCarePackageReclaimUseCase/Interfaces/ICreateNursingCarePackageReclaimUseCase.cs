using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageReclaimDomains;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCarePackageReclaimUseCase.Interfaces
{
    public interface ICreateNursingCarePackageReclaimUseCase
    {
        Task<NursingCarePackageClaimResponse> ExecuteAsync(NursingCarePackageClaimCreationDomain nursingCarePackageClaimCreationDomain);
    }
}
