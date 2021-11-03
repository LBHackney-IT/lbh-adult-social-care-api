using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface ICarePackageOptionsUseCase
    {
        IEnumerable<CarePackageSchedulingOptionResponse> GetCarePackageSchedulingOptions();

        IEnumerable<CarePackageStatusOptionResponse> GetCarePackageStatusOptions();
    }
}
