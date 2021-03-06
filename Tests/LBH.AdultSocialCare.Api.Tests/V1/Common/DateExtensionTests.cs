using Common.Extensions;
using System;
using System.Collections.Generic;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.Common
{
    public class DateExtensionTests
    {
        [Theory]
        [MemberData(nameof(AgeTestData))]
        public void AgeCalculationForLeapYearIsCorrect(int expected, DateTime birthDate, DateTime endDate)
        {
            var age = birthDate.GetAge(endDate);
            Assert.Equal(expected, age);
        }

        [Fact]
        public void DateTimeConversionToISOIsCorrect()
        {
            var testDate = new DateTime(2021, 09, 08, 0, 0, 0, DateTimeKind.Utc);
            var res = testDate.DateTimeToISOString();
            Assert.Equal("2021-09-08T00:00:00Z", res);
        }

        [Fact]
        public void DateTimeOffsetConversionToISOIsCorrect()
        {
            var testDate = new DateTimeOffset(2021, 09, 08, 0, 0, 0, TimeSpan.Zero);
            var res = testDate.DateTimeOffsetToISOString();
            Assert.Equal("2021-09-08T00:00:00Z", res);
        }

        [Theory]
        [MemberData(nameof(DateTimeOffsetInRangeTestData))]
        public void DateTimeOffsetInRangeEvaluationIsCorrect(bool expected, DateTimeOffset dateToCheck, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            var res = dateToCheck.IsInRange(startDate, endDate);
            Assert.Equal(expected, res);
        }

        public static IEnumerable<object[]> AgeTestData()
        {
            yield return new object[] { 39, new DateTime(1980, 02, 29, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 03, 01, 0, 0, 0, DateTimeKind.Utc) };
            yield return new object[] { 38, new DateTime(1980, 02, 29, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 02, 28, 0, 0, 0, DateTimeKind.Utc) };
        }

        public static IEnumerable<object[]> DateTimeOffsetInRangeTestData()
        {
            yield return new object[] { false, new DateTimeOffset(2021, 09, 08, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2022, 09, 08, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2023, 09, 08, 0, 0, 0, TimeSpan.Zero) };
            yield return new object[] { true, new DateTimeOffset(2021, 09, 08, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2020, 09, 08, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2023, 09, 08, 0, 0, 0, TimeSpan.Zero) };
        }
    }
}
