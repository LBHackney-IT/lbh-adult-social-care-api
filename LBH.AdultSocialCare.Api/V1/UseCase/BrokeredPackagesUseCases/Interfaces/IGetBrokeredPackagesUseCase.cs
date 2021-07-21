using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.BrokeredPackagesBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;

namespace LBH.AdultSocialCare.Api.V1.UseCase.BrokeredPackagesUseCases.Interfaces
{
    public interface IGetBrokeredPackagesUseCase
    {
        Task<PagedBrokeredPackagesResponse> GetBrokeredPackages(BrokeredPackagesParameters parameters, int statusId);
    }
}
