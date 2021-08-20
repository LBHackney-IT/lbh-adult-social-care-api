using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Interfaces
{
    public interface IUpdateDayCarePackageOpportunityUseCase
    {
        Task<DayCarePackageOpportunityResponse> Execute(DayCarePackageOpportunityForUpdateDomain dayCarePackageOpportunityForUpdateDomain);
    }
}
