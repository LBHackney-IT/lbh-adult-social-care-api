using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageOpportunityDomains;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Interfaces
{
    public interface IUpdateDayCarePackageOpportunityUseCase
    {
        Task<DayCarePackageOpportunityResponse> Execute(DayCarePackageOpportunityForUpdateDomain dayCarePackageOpportunityForUpdateDomain);
    }
}
