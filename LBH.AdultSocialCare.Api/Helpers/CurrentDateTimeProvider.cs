using System;

namespace LBH.AdultSocialCare.Api.Helpers
{
    public class CurrentDateTimeProvider : ICurrentDateTimeProvider
    {
        public DateTimeOffset Now
        {
            get
            {
                return DateTimeOffset.Now;
            }
        }
    }
}
