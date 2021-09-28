#nullable enable

using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using System.Linq;

namespace LBH.AdultSocialCare.Api.Tests.V1.Helper
{
    public static class DatabaseDataHelper
    {
        public static (CarePackage, CarePackageSettings?) SaveCarePackageToDatabase(DatabaseContext dbContext,
            bool withCarePackageSettings = false)
        {
            var serviceUser = dbContext.Clients.FirstOrDefault();
            var carePackage = TestDataHelper.CreateCarePackage(serviceUserId: serviceUser?.Id, packageType: PackageType.ResidentialCare, status: PackageStatus.New);
            dbContext.CarePackages.Add(carePackage);
            dbContext.SaveChanges();

            if (!withCarePackageSettings) return (carePackage, null);

            // var packageSettings = TestDataHelper.CreateCarePackageSettings(carePackageId: carePackage.Id);
            var packageSettings = new CarePackageSettings
            {
                CarePackageId = carePackage.Id,
                HasRespiteCare = false,
                HasDischargePackage = false,
                IsImmediate = false,
                IsReEnablement = false,
                IsS117Client = false
            };

            dbContext.CarePackageSettings.Add(packageSettings);
            dbContext.SaveChanges();

            return (carePackage, packageSettings);
        }
    }
}
