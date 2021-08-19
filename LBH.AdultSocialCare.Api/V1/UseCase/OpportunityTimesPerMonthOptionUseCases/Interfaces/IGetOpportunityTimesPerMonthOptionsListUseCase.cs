using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.OpportunityTimesPerMonthOptionUseCases.Interfaces
{
    public interface IGetOpportunityTimesPerMonthOptionsListUseCase
    {
        Task<IEnumerable<OpportunityTimesPerMonthOptionResponse>> Execute();
    }
}
