using LBH.AdultSocialCare.Api.V1.Boundary.OpportunityTimesPerMonthOptionBoundary.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.OpportunityTimesPerMonthOptionUseCases.Interfaces
{
    public interface IGetOpportunityTimesPerMonthOptionsListUseCase
    {
        Task<IEnumerable<OpportunityTimesPerMonthOptionResponse>> Execute();
    }
}
