using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Data;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Common;

namespace LBH.AdultSocialCare.Api.Tests.V1.DataGenerators
{
    public class DatabaseTestDataGenerator
    {
        private readonly DatabaseContext _context;

        public DatabaseTestDataGenerator(DatabaseContext context)
        {
            _context = context;
        }

        public CarePackage CreateCarePackage(PackageType type = PackageType.ResidentialCare, PackageStatus status = PackageStatus.New)
        {
            var serviceUser = CreateServiceUser();

            var carePackage = TestDataHelper.CreateCarePackage(
                serviceUserId: serviceUser?.Id,
                packageType: type,
                status: status);

            carePackage.SupplierId = _context.Suppliers.FirstOrDefault()?.Id;

            _context.CarePackages.Add(carePackage);
            _context.SaveChanges();

            return carePackage;
        }

        public List<CarePackageDetail> CreateCarePackageDetails(CarePackage package, int count, PackageDetailType type)
        {
            var faker = new Bogus.Faker();
            var costPeriod = type switch
            {
                PackageDetailType.CoreCost => PaymentPeriod.Weekly,
                PackageDetailType.AdditionalNeed => faker.PickRandom(PaymentPeriod.Weekly, PaymentPeriod.OneOff),
                _ => PaymentPeriod.Weekly
            };
            var details = TestDataHelper.CreateCarePackageDetails(count, type, costPeriod);

            package.Details.AddRange(details);
            _context.SaveChanges();

            return details;
        }

        public CarePackageSettings CreateCarePackageSettings(Guid carePackageId)
        {
            var packageSettings = new CarePackageSettings
            {
                CarePackageId = carePackageId,
                HasRespiteCare = false,
                HasDischargePackage = false,
                HospitalAvoidance = false,
                IsReEnablement = false,
                IsS117Client = false
            };

            _context.CarePackageSettings.Add(packageSettings);
            _context.SaveChanges();

            return packageSettings;
        }

        public CarePackageReclaim CreateCarePackageReclaim(
            CarePackage package, ClaimCollector collector,
            ReclaimType type, ReclaimSubType subType = ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks)
        {
            var reclaim = TestDataHelper.CreateCarePackageReclaim(package.Id, collector, type, subType);

            _context.CarePackageReclaims.Add(reclaim);
            _context.SaveChanges();

            return reclaim;
        }

        public CarePackageSettings CreateCarePackageSettingsForS117Client(Guid carePackageId, bool s117Client)
        {
            var packageSettings = new CarePackageSettings
            {
                CarePackageId = carePackageId,
                IsS117Client = s117Client
            };

            _context.CarePackageSettings.Add(packageSettings);
            _context.SaveChanges();

            return packageSettings;
        }

        public ServiceUser CreateServiceUser()
        {
            var serviceUser = TestDataHelper.CreateServiceUser();

            _context.ServiceUsers.Add(serviceUser);
            _context.SaveChanges();

            return serviceUser;
        }
    }
}
