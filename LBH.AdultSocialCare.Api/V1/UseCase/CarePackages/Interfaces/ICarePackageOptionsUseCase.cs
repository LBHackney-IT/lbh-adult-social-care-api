using System.Collections.Generic;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface ICarePackageOptionsUseCase
    {
        IEnumerable<CarePackageSchedulingOptionResponse> GetCarePackageSchedulingOptions();

        IEnumerable<CarePackageStatusOptionResponse> GetCarePackageStatusOptions();
    }
}
