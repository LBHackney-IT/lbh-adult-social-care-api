using System;
using System.Collections.Generic;
using FluentAssertions;
using LBH.AdultSocialCare.Api.Tests.V1.DataGenerators;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Concrete;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.Gateways.CarePackages
{
    public class CarePackageReclaimGatewayTests : BaseInMemoryDatabaseTest
    {
        private readonly DatabaseTestDataGenerator _generator;
        private readonly CarePackageReclaimGateway _gateway;

        public CarePackageReclaimGatewayTests()
        {
            _gateway = new CarePackageReclaimGateway(Context, Mapper);
            _generator = new DatabaseTestDataGenerator(Context);
        }

        [Theory]
        [MemberData(nameof(ReclaimStatusExpectations))]
        public void ShouldReturnCorrectStatus(ReclaimStatus currentStatus, DateTimeOffset startDate, ReclaimStatus expectedStatus)
        {
            var package = _generator.CreateCarePackage();
            var reclaim = _generator.CreateCarePackageReclaim(package, ReclaimType.CareCharge, ClaimCollector.Supplier);

            reclaim.Status = currentStatus;
            reclaim.StartDate = startDate;
            Context.SaveChanges();

            _gateway.GetAsync(package.Id, ReclaimType.CareCharge);

            reclaim.Status.Should().Be(expectedStatus);
        }

        public static IEnumerable<object[]> ReclaimStatusExpectations() =>
            new List<object[]>
            {
                new object[] { ReclaimStatus.Cancelled, DateTimeOffset.Now.AddDays(100), ReclaimStatus.Cancelled },
                new object[] { ReclaimStatus.Ended, DateTimeOffset.Now.AddDays(100), ReclaimStatus.Ended },
                new object[] { ReclaimStatus.Future, DateTimeOffset.Now.AddDays(-50), ReclaimStatus.Active },
                new object[] { ReclaimStatus.Active, DateTimeOffset.Now.AddDays(50), ReclaimStatus.Future },
                new object[] { ReclaimStatus.Future, DateTimeOffset.Now.AddDays(50), ReclaimStatus.Future },
                new object[] { ReclaimStatus.Active, DateTimeOffset.Now.AddDays(-50), ReclaimStatus.Active }
            };
    }
}
