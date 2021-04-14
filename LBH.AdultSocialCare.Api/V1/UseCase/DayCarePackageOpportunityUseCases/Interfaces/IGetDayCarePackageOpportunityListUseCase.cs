using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageOpportunityBoundary.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Interfaces
{
    public interface IGetDayCarePackageOpportunityListUseCase
    {
        Task<IEnumerable<DayCarePackageOpportunityResponse>> Execute(Guid dayCarePackageId);
    }
}
