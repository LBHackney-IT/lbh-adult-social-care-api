using System;
using Common.Helpers;

namespace LBH.AdultSocialCare.TestFramework
{
    public class MockCurrentDateProvider : ICurrentDateProvider
    {
        public DateTimeOffset Now { get; set; }
        public DateTimeOffset UtcNow { get; set; }
    }
}
