using System;

namespace LBH.AdultSocialCare.Api.Tests.V1.Constants
{
    public static class CarePackageConstants
    {
        public static readonly DateTimeOffset PackageEndDateDefault = new DateTimeOffset(new DateTime(2090, 12, 31, 0, 0, 0, DateTimeKind.Utc)).ToOffset(TimeSpan.Zero);
    }
}
