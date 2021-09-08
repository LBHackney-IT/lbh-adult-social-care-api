using System;

namespace LBH.AdultSocialCare.Api.Helpers
{
    public class CurrentDateTimeProvider : ICurrentDateTimeProvider
    {
        public DateTimeOffset Now => DateTimeOffset.Now;
    }
}
