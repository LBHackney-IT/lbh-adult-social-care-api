using System;
using System.Collections.Generic;
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
            var validatedDates = new HashSet<DateTimeOffset>();

            var reclaims = package.Reclaims.Where(r => r.Status != ReclaimStatus.Cancelled);
            foreach (var reclaim in reclaims)
            {
                // ensure that reclaim cost doesn't exceed weekly cost at any date
                // [Core 1000...............]
                // [ANP 500]        [ANP 600]
                // [CC 300.....][CC 1800....] <- last one exceeds weekly cost, invalid
                if (!validatedDates.Contains(reclaim.StartDate))
                {
                    ValidateReclaimCostsAtDate(package, reclaim.StartDate);
                    validatedDates.Add(reclaim.StartDate);
                }

                // [Core 1000......]
                // [ANP 500] <- starting from here reclaim cost exceeds weekly cost, so validate end dates too
                // [CC 1300........]
                if (reclaim.EndDate.HasValue)
                {
                    var dateToValidate = reclaim.EndDate.Value.AddDays(1);
                    if (!validatedDates.Contains(dateToValidate))
                    {
                        ValidateReclaimCostsAtDate(package, dateToValidate);
                        validatedDates.Add(dateToValidate);
                    }

                }
            }
        }

        private static void ValidateReclaimCostsAtDate(CarePackage package, DateTimeOffset targetDate)
        {
            var totalWeeklyCost = package.GetCoreCost() + package.GetAdditionalWeeklyCost(targetDate);
            var careChargesCost = package.GetCareChargesCost(null, targetDate);
            var fncCost = package.GetFncCost(targetDate);

            if (careChargesCost + fncCost > totalWeeklyCost)
            {
                throw new ApiException(
                    $"Reclaim total {decimal.Round(careChargesCost, 2)} at date {targetDate: yyyy-MM-dd} is greater that package cost of {decimal.Round(totalWeeklyCost, 2)}",
                    HttpStatusCode.BadRequest);
            }
        }
    }
}
