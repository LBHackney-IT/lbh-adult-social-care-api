using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ApprovedPackagesUseCases.Interfaces
{
    public interface IGetApprovedPackagesUseCase
    {
        Task<PagedApprovedPackagesResponse> GetApprovedPackages(ApprovedPackagesParameters parameters, int statusId);
    }
}
