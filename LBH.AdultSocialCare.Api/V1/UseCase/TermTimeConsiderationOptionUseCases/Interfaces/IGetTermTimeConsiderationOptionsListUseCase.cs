using LBH.AdultSocialCare.Api.V1.Boundary.TermTimeConsiderationOptionBoundary.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.TermTimeConsiderationOptionUseCases.Interfaces
{
    public interface IGetTermTimeConsiderationOptionsListUseCase
    {
        Task<IEnumerable<TermTimeConsiderationOptionResponse>> Execute();
    }
}
