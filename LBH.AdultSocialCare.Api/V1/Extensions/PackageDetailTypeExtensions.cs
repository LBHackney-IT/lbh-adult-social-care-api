using System;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Extensions
{
    public static class PackageDetailTypeExtensions
    {
        public static PaymentPeriod ToPaymentPeriod(this PackageDetailType detailType)
        {
            return detailType switch
            {
                PackageDetailType.CoreCost => PaymentPeriod.Weekly,
                PackageDetailType.AdditionalNeedOneOff => PaymentPeriod.OneOff,
                PackageDetailType.AdditionalNeedWeekly => PaymentPeriod.Weekly,
                _ => throw new InvalidOperationException($"Unsupported care package detail type {detailType}")
            };
        }
    }
}
