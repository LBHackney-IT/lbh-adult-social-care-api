using Bogus;
using Common.Extensions;
using HttpServices.Models.Responses;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Data.Constants;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Common;
using LBH.AdultSocialCare.Data.Entities.Payments;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LBH.AdultSocialCare.Api.Tests.V1.Helper
{
    public static class TestDataHelper
    {
        public static CarePackage CreateCarePackage(PackageType? packageType = null,
            PackageStatus? status = PackageStatus.New, Guid? serviceUserId = null, int? supplierId = null)
        {
            var package = new Faker<CarePackage>()
                .RuleFor(cp => cp.Id, Guid.NewGuid())
                .RuleFor(cp => cp.PackageType, f => packageType ?? f.PickRandom<PackageType>())
                .RuleFor(cp => cp.SupplierId, f => supplierId)
                .RuleFor(cp => cp.PackageScheduling, f => f.PickRandom<PackageScheduling>())
                .RuleFor(cp => cp.PrimarySupportReasonId, f => f.PickRandom(1, 2))
                .RuleFor(cp => cp.Status, f => status ?? f.PickRandom<PackageStatus>())
                .Generate();

            if (serviceUserId.HasValue)
            {
                package.ServiceUserId = serviceUserId.Value;
            }
            else
            {
                package.ServiceUser = CreateServiceUser();
                package.ServiceUserId = package.ServiceUser.Id;
            }

            return package;
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

        public static CarePackageForCreationRequest CarePackageCreationRequest(PackageType? packageType = null,
            Guid? serviceUserId = null, PackageStatus? status = null, Guid? settingId = null,
            Guid? carePackageId = null)
        {
            var carePackage = CreateCarePackage(packageType, status, serviceUserId);
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

        public static CarePackageUpdateRequest CarePackageUpdateRequest(CarePackage carePackage,
            CarePackageSettings carePackageSettings)
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

        public static CarePackageReclaim CreateCarePackageReclaim(Guid packageId, ClaimCollector collector,
            ReclaimType type, ReclaimSubType subType)
        {
            return new Faker<CarePackageReclaim>()
                .RuleFor(r => r.CarePackageId, packageId)
                .RuleFor(r => r.Cost,
                    f => Math.Round(f.Random.Decimal(0m, 1000m), 2)) // Workaround to avoid precision loss in SQLite)
                .RuleFor(r => r.StartDate, f => f.Date.Past().Date)
                .RuleFor(r => r.EndDate, f => f.Date.Future().Date)
                .RuleFor(r => r.Description, f => f.Lorem.Paragraph())
                .RuleFor(r => r.ClaimCollector, collector)
                .RuleFor(r => r.Type, type)
                .RuleFor(r => r.Status, ReclaimStatus.Active)
                .RuleFor(r => r.SubType, subType);
        }

        public static CarePackageReclaim CreateCarePackageReclaim(
            Guid packageId, ReclaimType type, ReclaimSubType subType, ClaimCollector? collector,
            decimal? cost, DateTimeOffset? startDate, DateTimeOffset? endDate)
        {
            return new Faker<CarePackageReclaim>()
                .RuleFor(r => r.Id, Guid.NewGuid)
                .RuleFor(r => r.CarePackageId, packageId)
                .RuleFor(r => r.Cost, f => cost ?? f.Random.Decimal(0m, 1000m).Round(2))
                .RuleFor(r => r.StartDate, f => startDate ?? f.Date.Past(1, DateTime.Now.AddDays(-1)).Date)
                .RuleFor(d => d.EndDate,
                    f => endDate != DateTimeOffset.MaxValue // use DateTimeOffset.MaxValue to create an ongoing reclaim
                        ? endDate ?? f.Date.Future(1, DateTime.Now.AddDays(1)).Date
                        : null as DateTimeOffset?)
                .RuleFor(r => r.Description, f => f.Lorem.Paragraph())
                .RuleFor(r => r.ClaimCollector, f => collector ?? f.PickRandom<ClaimCollector>())
                .RuleFor(r => r.Type, type)
                .RuleFor(r => r.Status, ReclaimStatus.Active)
                .RuleFor(r => r.SubType, subType);
        }

        public static CarePackageDetail CreateCarePackageDetail(
            Guid packageId, PackageDetailType type, decimal? cost = null,
            DateTimeOffset? startDate = null, DateTimeOffset? endDate = null, PaymentPeriod? costPeriod = null)
        {
            return new Faker<CarePackageDetail>()
                .RuleFor(r => r.Id, Guid.NewGuid)
                .RuleFor(r => r.CarePackageId, packageId)
                .RuleFor(r => r.Cost, f => cost ?? f.Random.Decimal(100m, 1000m).Round(2))
                .RuleFor(d => d.CostPeriod,
                    f => costPeriod ?? (type == PackageDetailType.CoreCost
                        ? PaymentPeriod.Weekly
                        : f.PickRandom(PaymentPeriod.Weekly, PaymentPeriod.OneOff)))
                .RuleFor(d => d.StartDate, f => startDate ?? f.Date.Past(1, DateTime.Now.AddDays(-1)).Date)
                .RuleFor(d => d.EndDate,
                    f => endDate != DateTimeOffset.MaxValue // use DateTimeOffset.MaxValue to create an ongoing detail
                        ? endDate ?? f.Date.Future(1, DateTime.Now.AddDays(1)).Date
                        : null as DateTimeOffset?)
                .RuleFor(d => d.Type, type);
        }

        public static List<CarePackageDetail> CreateCarePackageDetails(int count, PackageDetailType type,
            PaymentPeriod costPeriod = PaymentPeriod.Weekly)
        {
            return new Faker<CarePackageDetail>()
                .RuleFor(r => r.Cost,
                    f => Math.Round(f.Random.Decimal(100m, 1000m), 2)) // Workaround to avoid precision loss in SQLite)
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
                .RuleFor(r => r.Address,
                    f => new AddressResponse { Address = f.Address.FullAddress(), Postcode = f.Address.ZipCode() });
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

        public static Supplier CreateSupplier()
        {
            return new Faker<Supplier>()
                .RuleFor(u => u.SupplierName, f => f.Name.FullName())
                .RuleFor(u => u.Address, f => f.Address.FullAddress())
                .RuleFor(u => u.Postcode, f => f.Address.CountryCode())
                .RuleFor(u => u.Postcode, f => f.Random.String(8))
                .RuleFor(u => u.CedarReferenceNumber, f => f.Random.String(8))
                .RuleFor(u => u.DateCreated, f => f.Date.Past(1, DateTime.Now));
        }

        public static Payrun CreatePayRun(PayrunType? type = null, PayrunStatus? status = null,
            DateTimeOffset? paidUpToDate = null, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null)
        {
            return new Faker<Payrun>()
                .RuleFor(p => p.Id, f => f.Random.Uuid())
                .RuleFor(p => p.Number, f => f.Random.Uuid().ToString())
                .RuleFor(p => p.Type, f => type ?? f.PickRandom<PayrunType>())
                .RuleFor(p => p.Status, f => status ?? f.PickRandom<PayrunStatus>())
                .RuleFor(p => p.PaidUpToDate, paidUpToDate ?? PayrunConstants.DefaultStartDate)
                .RuleFor(p => p.StartDate, startDate ?? PayrunConstants.DefaultStartDate)
                .RuleFor(p => p.EndDate, endDate ?? PayrunConstants.DefaultStartDate.AddDays(28));
        }

        public static Invoice CreateInvoice(CarePackage package, decimal totalCost, decimal grossTotal,
            decimal netTotal)
        {
            return new Faker<Invoice>()
                .RuleFor(inv => inv.Id, f => f.Random.Uuid())
                .RuleFor(inv => inv.Number, f => f.Random.String(8))
                .RuleFor(inv => inv.SupplierId, package.SupplierId)
                .RuleFor(inv => inv.ServiceUserId, package.ServiceUserId)
                .RuleFor(inv => inv.PackageId, package.Id)
                .RuleFor(inv => inv.TotalCost, totalCost.Round(2))
                .RuleFor(inv => inv.GrossTotal, grossTotal.Round(2))
                .RuleFor(inv => inv.NetTotal, netTotal.Round(2));
        }

        public static InvoiceItem CreateInvoiceItem(Invoice invoice, DateTimeOffset fromDate, DateTimeOffset toDate,
            decimal weeklyCost = 2m, decimal quantity = 1m, ClaimCollector claimCollector = ClaimCollector.Hackney,
            PriceEffect priceEffect = PriceEffect.Add)
        {
            return new Faker<InvoiceItem>()
                .RuleFor(invItem => invItem.Id, f => f.Random.Uuid())
                .RuleFor(invItem => invItem.Name, f => f.Random.Words(3))
                .RuleFor(invItem => invItem.InvoiceId, invoice.Id)
                .RuleFor(invItem => invItem.WeeklyCost, weeklyCost)
                .RuleFor(invItem => invItem.Quantity, quantity)
                .RuleFor(invItem => invItem.FromDate, fromDate)
                .RuleFor(invItem => invItem.ToDate, toDate)
                .RuleFor(invItem => invItem.ClaimCollector, claimCollector)
                .RuleFor(invItem => invItem.PriceEffect, priceEffect);
        }

        public static PayrunInvoice CreatePayrunInvoice(Guid? payRunId, Invoice invoice,
            InvoiceStatus invoiceStatus = InvoiceStatus.Accepted)
        {
            return new Faker<PayrunInvoice>()
                .RuleFor(pInv => pInv.Id, f => f.Random.Uuid())
                .RuleFor(pInv => pInv.PayrunId, f => payRunId ?? f.Random.Uuid())
                .RuleFor(pInv => pInv.InvoiceId, f => invoice.Id)
                .RuleFor(pInv => pInv.InvoiceStatus, f => invoiceStatus);
        }
    }
}
