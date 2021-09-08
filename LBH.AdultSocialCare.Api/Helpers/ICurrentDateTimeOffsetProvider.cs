using System;

namespace LBH.AdultSocialCare.Api.Helpers
{
    public interface ICurrentDateTimeOffsetProvider
    {
        public DateTimeOffset Now { get; }
        public DateTimeOffset UtcNow { get; }
    }
}
