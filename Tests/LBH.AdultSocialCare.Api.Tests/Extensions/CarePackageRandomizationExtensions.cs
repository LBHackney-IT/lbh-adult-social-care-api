using System;
using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Data;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.TestFramework;
using LBH.AdultSocialCare.TestFramework.Extensions;

namespace LBH.AdultSocialCare.Api.Tests.Extensions
{
    public static class CarePackageRandomizationExtensions
    {
        #region Details

        public static CarePackage AddCoreCost(this CarePackage package, decimal? cost = null, string startDate = null, string endDate = null)
        {
            package.AddCoreCost(cost, startDate.ToUtcDate(), endDate.ToUtcDate());
            return package;
        }

        public static CarePackage AddCoreCost(this CarePackage package, decimal? cost = null, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null)
        {
            package.Details.Add(TestDataHelper.CreateCarePackageDetail(package.Id, PackageDetailType.CoreCost, cost, startDate, endDate, PaymentPeriod.Weekly));
            return package;
        }

        public static CarePackage AddWeeklyNeed(this CarePackage package, decimal? cost = null, string startDate = null, string endDate = null)
        {
            package.AddWeeklyNeed(cost, startDate?.ToUtcDate(), endDate?.ToUtcDate());
            return package;
        }

        public static CarePackage AddWeeklyNeed(this CarePackage package, decimal? cost = null, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null)
        {
            package.Details.Add(TestDataHelper.CreateCarePackageDetail(package.Id, PackageDetailType.AdditionalNeed, cost, startDate, endDate, PaymentPeriod.Weekly));
            return package;
        }

        public static CarePackage AddOneOffNeed(this CarePackage package, decimal? cost = null, string startDate = null, string endDate = null)
        {
            package.AddWeeklyNeed(cost, startDate?.ToUtcDate(), endDate?.ToUtcDate());
            return package;
        }

        public static CarePackage AddOneOffNeed(this CarePackage package, decimal? cost = null, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null)
        {
            package.Details.Add(TestDataHelper.CreateCarePackageDetail(package.Id, PackageDetailType.AdditionalNeed, cost, startDate, endDate, PaymentPeriod.OneOff));
            return package;
        }

        #endregion Details

        #region Care Charges

        public static CarePackage AddCareChargeProvisional(this CarePackage package, decimal? cost = null, ClaimCollector? collector = null, string startDate = null, string endDate = null)
        {
            package.AddCareChargeProvisional(cost, collector, startDate?.ToUtcDate(), endDate?.ToUtcDate());
            return package;
        }

        public static CarePackage AddCareChargeProvisional(this CarePackage package, decimal? cost = null, ClaimCollector? collector = null, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null)
        {
            package.Reclaims.Add(TestDataHelper.CreateCarePackageReclaim(package.Id, ReclaimType.CareCharge, ReclaimSubType.CareChargeProvisional, collector, cost, startDate, endDate));
            return package;
        }

        public static CarePackage AddCareChargeFor12Weeks(this CarePackage package, decimal? cost = null, ClaimCollector? collector = null, string startDate = null, string endDate = null)
        {
            package.AddCareChargeFor12Weeks(cost, collector, startDate?.ToUtcDate(), endDate?.ToUtcDate());
            return package;
        }

        public static CarePackage AddCareChargeFor12Weeks(this CarePackage package, decimal? cost = null, ClaimCollector? collector = null, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null)
        {
            package.Reclaims.Add(TestDataHelper.CreateCarePackageReclaim(package.Id, ReclaimType.CareCharge, ReclaimSubType.CareCharge1To12Weeks, collector, cost, startDate, endDate));
            return package;
        }

        public static CarePackage AddCareChargeFor13PlusWeeks(this CarePackage package, decimal? cost = null, ClaimCollector? collector = null, string startDate = null, string endDate = null)
        {
            package.AddCareChargeFor12Weeks(cost, collector, startDate?.ToUtcDate(), endDate?.ToUtcDate());
            return package;
        }

        public static CarePackage AddCareChargeFor13PlusWeeks(this CarePackage package, decimal? cost = null, ClaimCollector? collector = null, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null)
        {
            package.Reclaims.Add(TestDataHelper.CreateCarePackageReclaim(package.Id, ReclaimType.CareCharge, ReclaimSubType.CareCharge13PlusWeeks, collector, cost, startDate, endDate));
            return package;
        }

        #endregion CareCharges

        #region FNC

        public static CarePackage AddFncPayment(this CarePackage package, decimal? cost = null, ClaimCollector? collector = null, string startDate = null, string endDate = null)
        {
            package.AddFncPayment(cost, collector, startDate?.ToUtcDate(), endDate?.ToUtcDate());
            return package;
        }

        public static CarePackage AddFncPayment(this CarePackage package, decimal? cost = null, ClaimCollector? collector = null, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null)
        {
            package.Reclaims.Add(TestDataHelper.CreateCarePackageReclaim(package.Id, ReclaimType.Fnc, ReclaimSubType.FncPayment, collector, cost, startDate, endDate));
            return package;
        }

        public static CarePackage AddFncReclaim(this CarePackage package, decimal? cost = null, ClaimCollector? collector = null, string startDate = null, string endDate = null)
        {
            package.AddFncReclaim(cost, collector, startDate?.ToUtcDate(), endDate?.ToUtcDate());
            return package;
        }

        public static CarePackage AddFncReclaim(this CarePackage package, decimal? cost = null, ClaimCollector? collector = null, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null)
        {
            package.Reclaims.Add(TestDataHelper.CreateCarePackageReclaim(package.Id, ReclaimType.Fnc, ReclaimSubType.FncReclaim, collector, cost, startDate, endDate));
            return package;
        }

        #endregion FNC

        #region Utils

        public static CarePackage SetCurrentDate(this CarePackage package, string date)
        {
            foreach (var reclaim in package.Reclaims)
            {
                reclaim.CurrentDateProvider = new MockCurrentDateProvider { UtcNow = date.ToUtcDate() };
            }

            return package;
        }

        public static CarePackage Save(this CarePackage package, DatabaseContext databaseContext)
        {
            databaseContext.CarePackages.Add(package);
            databaseContext.SaveChanges();

            return package;
        }

        #endregion
    }
}
