using LBH.AdultSocialCare.Api.Tests.Extensions;
using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;

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
            var serviceUser = _context.ServiceUsers.FirstOrDefault();

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
            var details = TestDataHelper.CreateCarePackageDetails(count, type);

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

        public CarePackageReclaim CreateCarePackageReclaim(CarePackage package, ReclaimType type, ClaimCollector collector)
        {
            var reclaim = TestDataHelper.CreateCarePackageReclaim(package.Id, type, collector);

            _context.CarePackageReclaims.Add(reclaim);
            _context.SaveChanges();

            return reclaim;
        }
    }
}
