using System;
using LBH.AdultSocialCare.Api.Helpers;

namespace Common.Helpers
{
    public class CurrentDateProvider : ICurrentDateProvider
    {
        public DateTimeOffset Now => DateTimeOffset.UtcNow;
        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
    }
}
