using Bogus;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Request;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LBH.AdultSocialCare.Api.Tests.V1.Helper
{
    public static class TestDataHelper
    {
        public static CarePackage CreateCarePackage(PackageType? packageType = null, Guid? serviceUserId = null, PackageStatus? status = null, int? primarySupportReasonId = null)
        {
            var today = DateTimeOffset.Now;

            return new Faker<CarePackage>()
                .RuleFor(cp => cp.Id, f => f.Random.Guid())
                .RuleFor(cp => cp.PackageType, f => packageType ?? f.PickRandom<PackageType>())
                .RuleFor(cp => cp.ServiceUserId, f => serviceUserId ?? f.Random.Guid())
                .RuleFor(cp => cp.SupplierId, f => null)
                .RuleFor(cp => cp.PackageScheduling, f => f.PickRandom<PackageScheduling>())
                .RuleFor(cp => cp.PrimarySupportReasonId, f => primarySupportReasonId ?? f.PickRandom(1, 2))
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
                PrimarySupportReasonId = carePackage.PrimarySupportReasonId,
                PackageScheduling = carePackage.PackageScheduling,
                PackageType = carePackage.PackageType,
                HasRespiteCare = carePackageSettings.HasRespiteCare,
                HasDischargePackage = carePackageSettings.HasDischargePackage,
                IsImmediate = carePackageSettings.IsImmediate,
                IsReEnablement = carePackageSettings.IsReEnablement,
                IsS117Client = carePackageSettings.IsS117Client
            };
        }

        public static CarePackageUpdateRequest CarePackageUpdateRequest(CarePackage carePackage, CarePackageSettings carePackageSettings)
        {
            if (carePackage == null) throw new ArgumentNullException(nameof(carePackage));
            if (carePackageSettings == null) throw new ArgumentNullException(nameof(carePackageSettings));

            return new CarePackageUpdateRequest()
            {
                PrimarySupportReasonId = carePackage.PrimarySupportReasonId,
                PackageScheduling = carePackage.PackageScheduling,
                HasRespiteCare = carePackageSettings.HasRespiteCare,
                HasDischargePackage = carePackageSettings.HasDischargePackage,
                IsImmediate = carePackageSettings.IsImmediate,
                IsReEnablement = carePackageSettings.IsReEnablement,
                IsS117Client = carePackageSettings.IsS117Client
            };
        }

        public static PrimarySupportReason CreatePrimarySupportReason()
        {
            return new Faker<PrimarySupportReason>()
                .RuleFor(cp => cp.PrimarySupportReasonId, f => f.UniqueIndex)
                .RuleFor(cp => cp.PrimarySupportReasonName, f => f.Random.String(30, 50))
                .RuleFor(cp => cp.CederBudgetCode, f => f.Random.String(4, 10));
        }

        public static User CreateUser(Guid? userId = null)
        {
            var userEmail = Faker.Internet.Email();
            return new Faker<User>()
                .RuleFor(cp => cp.Id, f => userId ?? f.Random.Guid())
                .RuleFor(cp => cp.ConcurrencyStamp, f => f.Random.String(10, 30))
                .RuleFor(cp => cp.Email, f => userEmail)
                .RuleFor(cp => cp.EmailConfirmed, f => f.Random.Bool())
                .RuleFor(cp => cp.NormalizedEmail, f => userEmail.ToUpper(CultureInfo.InvariantCulture))
                .RuleFor(cp => cp.NormalizedUserName, f => userEmail.ToUpper(CultureInfo.InvariantCulture))
                .RuleFor(cp => cp.PasswordHash, f => f.Random.String(6, 8))
                .RuleFor(cp => cp.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(cp => cp.PhoneNumberConfirmed, f => f.Random.Bool())
                .RuleFor(cp => cp.TwoFactorEnabled, f => f.Random.Bool())
                .RuleFor(cp => cp.Name, f => f.Person.FullName)
                .RuleFor(cp => cp.UserName, f => userEmail);
        }

        public static CarePackageHistory CreateCarePackageHistory(Guid? carePackageId = null)
        {
            return new Faker<CarePackageHistory>()
                .RuleFor(cp => cp.Id, f => f.UniqueIndex)
                .RuleFor(cp => cp.CarePackageId, f => carePackageId ?? f.Random.Guid())
                .RuleFor(cp => cp.Description, f => f.Lorem.Paragraph(2))
                .RuleFor(cp => cp.RequestMoreInformation, f => f.Lorem.Paragraph(6))
                .RuleFor(cp => cp.StatusId, f => f.Random.Int(1, 10));
        }

        public static List<CarePackageDetail> CreateCarePackageDetailList(int count, PackageDetailType type)
        {
            return new Faker<CarePackageDetail>()
                .RuleFor(d => d.Cost, f => f.PickRandom(1.2m, 3.4m, 5.6m, 7.8m, 9.1m, 12.34m, 56.78m, 91.12m, 123.45m, 456.78m)) // Workaround to avoid precision loss in SQLite
                .RuleFor(d => d.CostPeriod, f => f.PickRandom(PaymentPeriod.Weekly, PaymentPeriod.OneOff))
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
