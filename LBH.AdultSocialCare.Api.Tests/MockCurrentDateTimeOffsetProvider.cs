using System;
using LBH.AdultSocialCare.Api.Helpers;

namespace LBH.AdultSocialCare.Api.Tests
{
    public class MockCurrentDateTimeOffsetProvider : ICurrentDateTimeOffsetProvider
    {
        public DateTimeOffset Now { get; set; }
        public DateTimeOffset UtcNow { get; set; }
    }
}
