using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.OpportunityLengthOptionUseCases.Interfaces
{
    public interface IGetOpportunityLengthOptionsListUseCase
    {
        Task<IEnumerable<OpportunityLengthOptionResponse>> Execute();
    }
}
