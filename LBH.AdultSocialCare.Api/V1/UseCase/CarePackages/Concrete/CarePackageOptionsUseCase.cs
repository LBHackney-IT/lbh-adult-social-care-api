using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class CarePackageOptionsUseCase : ICarePackageOptionsUseCase
    {
        public IEnumerable<CarePackageSchedulingOptionResponse> GetCarePackageSchedulingOptions()
        {
            return Enum.GetValues(typeof(PackageScheduling))
                .OfType<PackageScheduling>()
                .Select(ps =>
                    new CarePackageSchedulingOptionResponse()
                    {
                        Id = ps,
                        OptionName = ps.GetDisplayName(),
                        OptionPeriod = ps.ToDescription()
                    })
                .ToList();
        }

        public IEnumerable<CarePackageStatusOptionResponse> GetCarePackageStatusOptions()
        {
            return Enum.GetValues(typeof(PackageStatus))
                .OfType<PackageStatus>()
                .Select(ps =>
                    new CarePackageStatusOptionResponse
                    {
                        Id = ps,
                        StatusName = ps.GetDisplayName()
                    })
                .ToList();
        }
    }
}
