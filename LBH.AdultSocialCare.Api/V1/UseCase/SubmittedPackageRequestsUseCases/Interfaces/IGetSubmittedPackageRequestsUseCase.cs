using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.SubmittedPackageRequestsBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;

namespace LBH.AdultSocialCare.Api.V1.UseCase.SubmittedPackageRequestsUseCases.Interfaces
{
    public interface IGetSubmittedPackageRequestsUseCase
    {
        Task<PagedSubmittedPackageRequestsResponse> GetSubmittedPackageRequests(SubmittedPackageRequestParameters parameters);
    }
}
