using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Interfaces
{
    public interface IGetDayCarePackageOpportunityListUseCase
    {
        Task<IEnumerable<DayCarePackageOpportunityResponse>> Execute(Guid dayCarePackageId);
    }
}
