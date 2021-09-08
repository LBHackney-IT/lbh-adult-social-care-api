using System;

namespace LBH.AdultSocialCare.Api.Helpers
{
    public class CurrentDateTimeOffsetProvider : ICurrentDateTimeOffsetProvider
    {
        public DateTimeOffset Now => DateTimeOffset.Now;
        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
        public static CurrentDateTimeOffsetProvider DateTimeOffset => new CurrentDateTimeOffsetProvider();
    }
}
