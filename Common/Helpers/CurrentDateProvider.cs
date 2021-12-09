using System;
using LBH.AdultSocialCare.Api.Helpers;

namespace Common.Helpers
{
    public class CurrentDateProvider : ICurrentDateProvider
    {
        public DateTimeOffset Now => DateTimeOffset.Now;
        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
    }
}
