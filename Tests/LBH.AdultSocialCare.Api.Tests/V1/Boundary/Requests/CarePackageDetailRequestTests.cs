using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LBH.AdultSocialCare.Data.Constants.Enums;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.Boundary.Requests
{
    public class CarePackageDetailRequestTests
    {
        [Fact]
        public void ShouldFailOnMissedOneOffEndDate()
        {
            var request = new CarePackageDetailRequest
            {
                Type = PackageDetailType.AdditionalNeed,
                CostPeriod = PaymentPeriod.OneOff,
                Cost = 12.34m,
                StartDate = DateTimeOffset.UtcNow
            };

            var validationContext = new ValidationContext(request);
            var results = request.Validate(validationContext).ToList();

            results.Count.Should().Be(1);
            results.First().MemberNames.Should().ContainSingle(m => m == nameof(CarePackageDetailRequest.EndDate));
        }

        [Fact]
        public void ShouldFailWhenStartDateLaterThanEndDate()
        {
            var request = new CarePackageDetailRequest
            {
                Type = PackageDetailType.AdditionalNeed,
                CostPeriod = PaymentPeriod.OneOff,
                Cost = 12.34m,
                StartDate = DateTimeOffset.UtcNow,
                EndDate = DateTimeOffset.UtcNow.AddDays(-100)
            };

            var validationContext = new ValidationContext(request);
            var results = request.Validate(validationContext).ToList();

            results.Count.Should().Be(1);
            results.First().MemberNames.Count().Should().Be(2);
            results.First().MemberNames.Should().ContainSingle(m => m == nameof(CarePackageDetailRequest.StartDate));
            results.First().MemberNames.Should().ContainSingle(m => m == nameof(CarePackageDetailRequest.EndDate));
        }
    }
}
