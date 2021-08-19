using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Interfaces
{
    public interface ICreateDayCarePackageOpportunityUseCase
    {
        Task<Guid> Execute(DayCarePackageOpportunityForCreationDomain dayCarePackageOpportunityForCreationDomain);
    }
}
