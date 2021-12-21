using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Data.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IGetCarePackageReclaimsUseCase
    {
        Task<CarePackageReclaimResponse> GetFundedNursingCare(Guid carePackageId);

        Task<IEnumerable<CarePackageReclaimDomain>> GetListAsync(Guid carePackageId, ReclaimType? reclaimType, ReclaimSubType? reclaimSubType);

        Task<CarePackageReclaimResponse> GetProvisionalCareCharge(Guid carePackageId);

        Task<FinancialAssessmentViewResponse> GetFinancialAssessmentDetailsAsync(Guid carePackageId);
    }
}
