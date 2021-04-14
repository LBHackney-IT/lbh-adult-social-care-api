using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageOpportunityDomains;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Interfaces
{
    public interface ICreateDayCarePackageOpportunityUseCase
    {
        Task<Guid> Execute(DayCarePackageOpportunityForCreationDomain dayCarePackageOpportunityForCreationDomain);
    }
}
