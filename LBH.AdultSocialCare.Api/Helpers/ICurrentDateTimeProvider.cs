using System;

namespace LBH.AdultSocialCare.Api.Helpers
{
    public interface ICurrentDateTimeProvider
    {
        public DateTimeOffset Now { get; }
    }
}
