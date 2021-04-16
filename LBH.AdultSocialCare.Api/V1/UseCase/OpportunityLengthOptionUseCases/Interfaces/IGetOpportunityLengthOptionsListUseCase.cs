using LBH.AdultSocialCare.Api.V1.Boundary.OpportunityLengthOptionBoundary.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.OpportunityLengthOptionUseCases.Interfaces
{
    public interface IGetOpportunityLengthOptionsListUseCase
    {
        Task<IEnumerable<OpportunityLengthOptionResponse>> Execute();
    }
}
