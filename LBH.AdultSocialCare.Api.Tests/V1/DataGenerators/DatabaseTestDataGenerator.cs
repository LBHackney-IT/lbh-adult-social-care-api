using System;
using System.Collections.Generic;
using System.Linq;
using LBH.AdultSocialCare.Api.Tests.Extensions;
using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Api.Tests.V1.DataGenerators
{
    public class DatabaseTestDataGenerator
    {
        private readonly DatabaseContext _context;

        public DatabaseTestDataGenerator(DatabaseContext context)
        {
            _context = context;

            NursingCare = new NursingCareGenerator(context);
            ResidentialCare = new ResidentialCareGenerator(context);
            CareCharge = new CareChargeGenerator(context);
        }

        #region Legacy

        public NursingCareGenerator NursingCare { get; }
        public ResidentialCareGenerator ResidentialCare { get; }
        public CareChargeGenerator CareCharge { get; }

        #endregion

        public CarePackage CreateCarePackage(PackageType type = PackageType.ResidentialCare)
        {
            var serviceUser = _context.Clients.FirstOrDefault();

            var carePackage = TestDataHelper.CreateCarePackage(
                serviceUserId: serviceUser?.Id,
                packageType: type,
                status: PackageStatus.New);

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
                IsImmediate = false,
                IsReEnablement = false,
                IsS117Client = false
            };

            _context.CarePackageSettings.Add(packageSettings);
            _context.SaveChanges();

            return packageSettings;
        }
    }
}
