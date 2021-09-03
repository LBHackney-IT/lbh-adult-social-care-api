using System;
using LBH.AdultSocialCare.Api.Helpers;

namespace LBH.AdultSocialCare.Api.Tests
{
    public class MockCurrentDateTimeProvider : ICurrentDateTimeProvider
    {
        public DateTimeOffset Now { get; set; }
    }
}
