using Bogus;
using HttpServices.Models.Responses;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Common;

namespace LBH.AdultSocialCare.Api.Tests.V1.Helper
{
    public static class TestDataHelper
    {
        public static CarePackage CreateCarePackage(PackageType? packageType = null, Guid? serviceUserId = null, PackageStatus? status = null, int? primarySupportReasonId = null)
        {
            return new Faker<CarePackage>()
                .RuleFor(cp => cp.Id, f => f.Random.Guid())
                .RuleFor(cp => cp.PackageType, f => packageType ?? f.PickRandom<PackageType>())
                .RuleFor(cp => cp.ServiceUserId, f => serviceUserId ?? f.Random.Guid())
                .RuleFor(cp => cp.SupplierId, f => null)
                .RuleFor(cp => cp.PackageScheduling, f => f.PickRandom<PackageScheduling>())
                .RuleFor(cp => cp.PrimarySupportReasonId, f => primarySupportReasonId ?? f.PickRandom(1, 2))
                .RuleFor(cp => cp.Status, f => status ?? f.PickRandom<PackageStatus>());
        }

        public static CarePackageSettings CreateCarePackageSettings(Guid? settingId = null, Guid? carePackageId = null)
        {
            return new Faker<CarePackageSettings>()
                .RuleFor(cp => cp.Id, f => settingId ?? f.Random.Guid())
                .RuleFor(cp => cp.CarePackageId, f => carePackageId ?? f.Random.Guid())
                .RuleFor(cp => cp.HasRespiteCare, f => f.Random.Bool())
                .RuleFor(cp => cp.HasDischargePackage, f => f.Random.Bool())
                .RuleFor(cp => cp.HospitalAvoidance, f => f.Random.Bool())
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
                HospitalAvoidance = carePackageSettings.HospitalAvoidance,
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
                HospitalAvoidance = carePackageSettings.HospitalAvoidance,
                IsReEnablement = carePackageSettings.IsReEnablement,
                IsS117Client = carePackageSettings.IsS117Client,
                PackageType = carePackage.PackageType,
                SocialWorkerCarePlanFileId = Guid.NewGuid()
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
                .RuleFor(cp => cp.Status, f => f.PickRandom<HistoryStatus>());
        }

        public static CarePackageReclaim CreateCarePackageReclaim(Guid packageId, ClaimCollector collector, ReclaimType type, ReclaimSubType subType)
        {
            return new Faker<CarePackageReclaim>()
                .RuleFor(r => r.CarePackageId, packageId)
                .RuleFor(r => r.Cost, f => Math.Round(f.Random.Decimal(0m, 1000m), 2)) // Workaround to avoid precision loss in SQLite)
                .RuleFor(r => r.StartDate, f => f.Date.Past().Date)
                .RuleFor(r => r.EndDate, f => f.Date.Future().Date)
                .RuleFor(r => r.Description, f => f.Lorem.Paragraph())
                .RuleFor(r => r.ClaimCollector, collector)
                .RuleFor(r => r.Type, type)
                .RuleFor(r => r.Status, ReclaimStatus.Active)
                .RuleFor(r => r.SubType, subType);
        }

        public static CarePackageReclaim CreateCarePackageReclaim(
            ReclaimType type, ReclaimSubType subType, ClaimCollector? collector,
            decimal? cost, DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            return new Faker<CarePackageReclaim>()
                .RuleFor(r => r.Cost, f => cost ?? Math.Round(f.Random.Decimal(0m, 1000m), 2)) // Workaround to avoid precision loss in SQLite)
                .RuleFor(r => r.StartDate, f => startDate ?? f.Date.Past(1, DateTime.Now).AddDays(-1).Date)
                .RuleFor(r => r.EndDate, f => endDate ?? f.Date.Future(1, DateTime.Now).AddDays(1).Date)
                .RuleFor(r => r.Description, f => f.Lorem.Paragraph())
                .RuleFor(r => r.ClaimCollector, f => collector ?? f.PickRandom<ClaimCollector>())
                .RuleFor(r => r.Type, type)
                .RuleFor(r => r.Status, ReclaimStatus.Active)
                .RuleFor(r => r.SubType, subType);
        }

        public static CarePackageDetail CreateCarePackageDetail(
            PackageDetailType type, decimal? cost = null,
            DateTimeOffset? startDate = null, DateTimeOffset? endDate = null, PaymentPeriod? costPeriod = null)
        {
            return new Faker<CarePackageDetail>()
                .RuleFor(r => r.Cost, f => cost ?? Math.Round(f.Random.Decimal(100m, 1000m), 2))
                .RuleFor(d => d.CostPeriod,
                    f => costPeriod ?? (type == PackageDetailType.CoreCost
                        ? PaymentPeriod.Weekly
                        : f.PickRandom(PaymentPeriod.Weekly, PaymentPeriod.OneOff)))
                .RuleFor(d => d.StartDate, f => startDate ?? f.Date.Past(1, DateTime.Now).AddDays(-1).Date)
                .RuleFor(d => d.EndDate, f => endDate ?? f.Date.Future(1, DateTime.Now).AddDays(1).Date)
                .RuleFor(d => d.Type, type)
                .Generate();
        }

        public static List<CarePackageDetail> CreateCarePackageDetails(int count, PackageDetailType type, PaymentPeriod costPeriod = PaymentPeriod.Weekly)
        {
            return new Faker<CarePackageDetail>()
                .RuleFor(r => r.Cost, f => Math.Round(f.Random.Decimal(100m, 1000m), 2)) // Workaround to avoid precision loss in SQLite)
                /*.RuleFor(d => d.CostPeriod, f => type == PackageDetailType.CoreCost
                    ? PaymentPeriod.Weekly
                    : f.PickRandom(PaymentPeriod.Weekly, PaymentPeriod.OneOff))*/
                .RuleFor(d => d.CostPeriod, costPeriod)
                .RuleFor(d => d.StartDate, f => f.Date.Past().Date)
                .RuleFor(d => d.EndDate, f => f.Date.Future().Date)
                .RuleFor(d => d.Type, type)
                .Generate(count);
        }

        public static List<CarePackageDetailDomain> CreateCarePackageDetailDomainList(int count, PackageDetailType type)
        {
            var result = CreateCarePackageDetails(count, type).ToDomain().ToList();
            result.ForEach(detail => detail.Id = null);

            return result;
        }

        public static ResidentResponse CreateResidentResponse()
        {
            return new Faker<ResidentResponse>()
                .RuleFor(r => r.FirstName, f => f.Name.FirstName())
                .RuleFor(r => r.LastName, f => f.Name.LastName())
                .RuleFor(r => r.EmailAddress, f => f.Internet.Email())
                .RuleFor(r => r.DateOfBirth, f => f.Date.Past(100))
                .RuleFor(r => r.Address, f => new AddressResponse
                {
                    Address = f.Address.FullAddress(),
                    Postcode = f.Address.ZipCode()
                });
        }

        public static ServiceUser CreateServiceUser()
        {
            return new Faker<ServiceUser>()
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.AddressLine1, f => f.Address.FullAddress())
                .RuleFor(u => u.DateOfBirth, f => f.Date.Past(60, DateTime.Now).AddYears(-60))
                .RuleFor(u => u.HackneyId, f => f.Random.Int());
        }
    }
}
