using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface ICarePackageOptionsUseCase
    {
        IEnumerable<CarePackageSchedulingOptionResponse> GetCarePackageSchedulingOptions();
    }
}
