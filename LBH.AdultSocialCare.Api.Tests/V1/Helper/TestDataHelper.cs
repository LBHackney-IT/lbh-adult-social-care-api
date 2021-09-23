using Bogus;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Request;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using System;
using System.Linq;

namespace LBH.AdultSocialCare.Api.Tests.V1.Helper
{
    public static class TestDataHelper
    {
        public static CarePackage CreateCarePackage(PackageType? packageType = null, Guid? serviceUserId = null, PackageStatus? status = null, PackageStage? stage = null, string packageScheduling = null, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null)
        {
            var validPackageSchedulingOptions = Enum.GetValues(typeof(PackageScheduling))
                .Cast<PackageScheduling>()
                .Select(p => p.ToString())
                .ToArray();
            var today = DateTimeOffset.Now;

            return new Faker<CarePackage>()
                .RuleFor(cp => cp.Id, f => f.Random.Guid())
                .RuleFor(cp => cp.PackageType, f => packageType ?? f.PickRandom<PackageType>())
                .RuleFor(cp => cp.ServiceUserId, f => serviceUserId ?? f.Random.Guid())
                .RuleFor(cp => cp.SupplierId, f => f.UniqueIndex)
                .RuleFor(cp => cp.PrimarySupportReason, f => f.Lorem.Paragraph(3))
                .RuleFor(cp => cp.PackagingScheduling, f => packageScheduling ?? f.PickRandom(validPackageSchedulingOptions))
                .RuleFor(cp => cp.StartDate,
                    f => startDate ?? f.Date.BetweenOffset(today.AddDays(-300), today.AddDays(-200)))
                .RuleFor(cp => cp.EndDate,
                    f => endDate)
                .RuleFor(cp => cp.Status, f => status ?? f.PickRandom<PackageStatus>())
                .RuleFor(cp => cp.Stage, f => stage ?? f.PickRandom<PackageStage>());
        }

        public static ResidentialCarePackageSettings CreateResidentialCarePackageSettings(Guid? settingId = null, Guid? carePackageId = null)
        {
            return new Faker<ResidentialCarePackageSettings>()
                .RuleFor(cp => cp.Id, f => settingId ?? f.Random.Guid())
                .RuleFor(cp => cp.CarePackageId, f => carePackageId ?? f.Random.Guid())
                .RuleFor(cp => cp.HasRespiteCare, f => f.Random.Bool())
                .RuleFor(cp => cp.HasDischargePackage, f => f.Random.Bool())
                .RuleFor(cp => cp.IsImmediate, f => f.Random.Bool())
                .RuleFor(cp => cp.IsReEnablement, f => f.Random.Bool())
                .RuleFor(cp => cp.IsS117Client, f => f.Random.Bool());
        }

        public static ResidentialCarePackageForCreationRequest ResidentialCarePackageCreationRequest(PackageType? packageType = null, Guid? serviceUserId = null, PackageStatus? status = null, PackageStage? stage = null, string packageScheduling = null, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null, Guid? settingId = null, Guid? carePackageId = null)
        {
            var carePackage = CreateCarePackage(packageType, serviceUserId, status, stage, packageScheduling, startDate, endDate);
            var carePackageSettings = CreateResidentialCarePackageSettings(settingId, carePackageId);
            return new ResidentialCarePackageForCreationRequest
            {
                ServiceUserId = carePackage.ServiceUserId,
                PrimarySupportReason = carePackage.PrimarySupportReason,
                PackagingScheduling = carePackage.PackagingScheduling,
                StartDate = carePackage.StartDate,
                EndDate = carePackage.EndDate,
                HasRespiteCare = carePackageSettings.HasRespiteCare,
                HasDischargePackage = carePackageSettings.HasDischargePackage,
                IsImmediate = carePackageSettings.IsImmediate,
                IsReEnablement = carePackageSettings.IsReEnablement,
                IsS117Client = carePackageSettings.IsS117Client
            };
        }
    }
}
