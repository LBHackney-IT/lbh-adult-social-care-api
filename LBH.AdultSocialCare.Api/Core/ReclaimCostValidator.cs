using System;
using System.Linq;
using System.Net;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

namespace LBH.AdultSocialCare.Api.Core
{
    public static class ReclaimCostValidator
    {
        public static void Validate(CarePackage package)
        {
            // ensure that reclaim cost doesn't exceed weekly cost at any date
            // [Core 1000...............]
            // [ANP 500]        [ANP 600]
            // [CC 300.....][CC 1800....] <- last one exceeds weekly cost, invalid

            // reclaim cost may also exceed weekly cost after ANP is ended
            // [Core 1000......]
            // [ANP 500] <- starting from here reclaim cost exceeds weekly cost, so validate day after ANP end
            // [CC 1300........]

            var datesToValidate = package.Reclaims
                .Where(reclaim => reclaim.Status != ReclaimStatus.Cancelled)
                .Select(reclaim => reclaim.StartDate)
                .Concat(package.Details
                    .Where(detail =>
                        detail.Type is PackageDetailType.AdditionalNeed &&
                        detail.CostPeriod is PaymentPeriod.Weekly &&
                        detail.EndDate.HasValue)
                    .Select(detail => detail.EndDate.Value.AddDays(1)))
                .Distinct();

            foreach (var date in datesToValidate)
            {
                ValidateReclaimCostsAtDate(package, date);
            }
        }

        private static void ValidateReclaimCostsAtDate(CarePackage package, DateTimeOffset targetDate)
        {
            var totalWeeklyCost = package.GetCoreCost() + package.GetAdditionalWeeklyCost(targetDate);
            var careChargesCost = package.GetCareChargesCost(null, targetDate);
            var fncCost = package.GetFncPaymentCost(targetDate);

            if (careChargesCost + fncCost > totalWeeklyCost)
            {
                throw new ApiException(
                    $"Reclaim total {decimal.Round(careChargesCost, 2)} at date {targetDate: yyyy-MM-dd} is greater that package cost of {decimal.Round(totalWeeklyCost, 2)}",
                    HttpStatusCode.BadRequest);
            }
        }
    }
}
