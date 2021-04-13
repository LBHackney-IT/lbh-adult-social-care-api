using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageOpportunityBoundary.Response;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Interfaces
{
    public interface IGetDayCarePackageOpportunityUseCase
    {
        Task<DayCarePackageOpportunityResponse> Execute(Guid dayCarePackageOpportunityId);
    }
}
