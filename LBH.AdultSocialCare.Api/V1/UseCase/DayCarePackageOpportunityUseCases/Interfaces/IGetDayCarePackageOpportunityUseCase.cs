using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Interfaces
{
    public interface IGetDayCarePackageOpportunityUseCase
    {
        Task<DayCarePackageOpportunityResponse> Execute(Guid dayCarePackageId, Guid dayCarePackageOpportunityId);
    }
}
