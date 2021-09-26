using Bogus;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Request;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;

namespace LBH.AdultSocialCare.Api.Tests.V1.Helper
{
    public static class TestDataHelper
    {
        public static CarePackage CreateCarePackage(PackageType? packageType = null, Guid? serviceUserId = null, PackageStatus? status = null)
        {
            var today = DateTimeOffset.Now;

            return new Faker<CarePackage>()
                .RuleFor(cp => cp.Id, f => f.Random.Guid())
                .RuleFor(cp => cp.PackageType, f => packageType ?? f.PickRandom<PackageType>())
                .RuleFor(cp => cp.ServiceUserId, f => serviceUserId ?? f.Random.Guid())
                .RuleFor(cp => cp.SupplierId, f => f.UniqueIndex)
                .RuleFor(cp => cp.PrimarySupportReason, f => f.Lorem.Paragraph(3))
                /*.RuleFor(cp => cp.StartDate,
                    f => startDate ?? f.Date.BetweenOffset(today.AddDays(-300), today.AddDays(-200)))*/
                .RuleFor(cp => cp.Status, f => status ?? f.PickRandom<PackageStatus>());
        }

        public static CarePackageSettings CreateCarePackageSettings(Guid? settingId = null, Guid? carePackageId = null)
        {
            return new Faker<CarePackageSettings>()
                .RuleFor(cp => cp.Id, f => settingId ?? f.Random.Guid())
                .RuleFor(cp => cp.CarePackageId, f => carePackageId ?? f.Random.Guid())
                .RuleFor(cp => cp.HasRespiteCare, f => f.Random.Bool())
                .RuleFor(cp => cp.HasDischargePackage, f => f.Random.Bool())
                .RuleFor(cp => cp.IsImmediate, f => f.Random.Bool())
                .RuleFor(cp => cp.IsReEnablement, f => f.Random.Bool())
                .RuleFor(cp => cp.IsS117Client, f => f.Random.Bool());
        }

        public static CarePackageForCreationRequest CarePackageCreationRequest(PackageType? packageType = null, Guid? serviceUserId = null, PackageStatus? status = null, Guid? settingId = null, Guid? carePackageId = null)
        {
            var carePackage = CreateCarePackage(packageType, serviceUserId, status);
            var carePackageSettings = CreateCarePackageSettings(settingId, carePackageId);
            return new CarePackageForCreationRequest
            {
                ServiceUserId = carePackage.ServiceUserId,
                PrimarySupportReason = carePackage.PrimarySupportReason,
                PackageType = carePackage.PackageType,
                HasRespiteCare = carePackageSettings.HasRespiteCare,
                HasDischargePackage = carePackageSettings.HasDischargePackage,
                IsImmediate = carePackageSettings.IsImmediate,
                IsReEnablement = carePackageSettings.IsReEnablement,
                IsS117Client = carePackageSettings.IsS117Client
            };
        }

        public static List<CarePackageDetail> CreateCarePackageDetailList(int count, PackageDetailType type)
        {
            return new Faker<CarePackageDetail>()
                .RuleFor(d => d.Cost, f => f.PickRandom(1.2m, 3.4m, 5.6m, 7.8m, 9.1m, 12.34m, 56.78m, 91.12m, 123.45m, 456.78m)) // Workaround to avoid precision loss in SQLite
                .RuleFor(d => d.StartDate, f => f.Date.Past().Date)
                .RuleFor(d => d.EndDate, f => f.Date.Future().Date)
                .RuleFor(d => d.Type, type)
                .Generate(count);
        }

        public static List<CarePackageDetailDomain> CreateCarePackageDetailDomainList(int count, PackageDetailType type)
        {
            var result = CreateCarePackageDetailList(count, type).ToDomain().ToList();

            result.ForEach(detail => detail.Id = null);

            return result;
        }
    }
}
