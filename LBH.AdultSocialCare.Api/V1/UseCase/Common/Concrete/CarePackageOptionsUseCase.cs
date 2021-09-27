using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class CarePackageOptionsUseCase : ICarePackageOptionsUseCase
    {
        public IEnumerable<CarePackageSchedulingOptionResponse> GetCarePackageSchedulingOptions()
        {
            return Enum.GetValues(typeof(PackageScheduling))
                .OfType<PackageScheduling>()
                .Select(x =>
                    new CarePackageSchedulingOptionResponse()
                    {
                        Id = x,
                        OptionName = x.GetDisplayName(),
                        OptionPeriod = x.ToDescription()
                    })
                .ToList();
        }
    }
}
