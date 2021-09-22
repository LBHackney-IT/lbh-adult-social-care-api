using Bogus;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using System;
using System.Linq;

namespace LBH.AdultSocialCare.Api.Tests.V1.Helper
{
    public static class TestDataHelper
    {
        public static CarePackage CreateCarePackage(PackageType? packageType = null, Guid? serviceUserId = null, PackageStatus? status = null, PackageStage? stage = null, DateTimeOffset? startDate = null)
        {
            var validPackageSchedulingOptions = Enum.GetValues(typeof(PackageScheduling))
                .Cast<PackageScheduling>()
                .Select(p => nameof(p))
                .ToArray();
            var today = DateTimeOffset.Now;

            return new Faker<CarePackage>()
                .RuleFor(cp => cp.Id, f => f.Random.Guid())
                .RuleFor(cp => cp.PackageType, f => packageType ?? f.PickRandom<PackageType>())
                .RuleFor(cp => cp.ServiceUserId, f => serviceUserId ?? f.Random.Guid())
                .RuleFor(cp => cp.SupplierId, f => f.UniqueIndex)
                .RuleFor(cp => cp.PrimarySupportReason, f => f.Lorem.Paragraph(3))
                .RuleFor(cp => cp.PackagingScheduling, f => f.PickRandom(validPackageSchedulingOptions))
                .RuleFor(cp => cp.StartDate,
                    f => startDate ?? f.Date.BetweenOffset(today.AddDays(-300), today.AddDays(-200)))
                .RuleFor(cp => cp.EndDate,
                    f => f.Date.BetweenOffset(today.AddDays(-100), today.AddDays(300)))
                .RuleFor(cp => cp.Status, f => status ?? f.PickRandom<PackageStatus>())
                .RuleFor(cp => cp.Stage, f => stage ?? f.PickRandom<PackageStage>());
        }
    }
}
